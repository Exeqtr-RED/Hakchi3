using com.clusterrr.hakchi_gui;
using LibUsbDotNet;
using LibUsbDotNet.LibUsb;
using LibUsbDotNet.Main;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace com.clusterrr.clovershell
{
    public class ClovershellConnection : IDisposable, ISystemShell
    {
        private const UInt16 Vid = 0x1F3A;
        private const UInt16 Pid = 0xEFE8;

        private UsbContext context = null;
        private IUsbDevice device = null;
        private UsbEndpointReader epReader = null;
        private UsbEndpointWriter epWriter = null;

        private Thread mainThread = null;
        private Thread shellListenerThread = null;
        private Thread epReaderThread = null;

        private CancellationTokenSource mainThreadCts;
        private CancellationTokenSource shellListenerCts;
        private CancellationTokenSource epReaderCts;

        private bool online = false;
        private ushort shellPort = 1023;
        private readonly Queue<ShellConnection> pendingShellConnections = new();
        private readonly List<ExecConnection> pendingExecConnections = new();
        internal ShellConnection[] shellConnections = new ShellConnection[256];
        internal ExecConnection[] execConnections = new ExecConnection[256];
        private bool enabled = false;
        private bool autoreconnect = false;
        private byte[] lastPingResponse = null;
        private DateTime lastAliveTime;

        public event OnConnectedEventHandler OnConnected = delegate { };
        public event OnDisconnectedEventHandler OnDisconnected = delegate { };

        internal enum ClovershellCommand
        {
            CMD_PING = 0, CMD_PONG = 1, CMD_SHELL_NEW_REQ = 2, CMD_SHELL_NEW_RESP = 3,
            CMD_SHELL_IN = 4, CMD_SHELL_OUT = 5, CMD_SHELL_CLOSED = 6, CMD_SHELL_KILL = 7,
            CMD_SHELL_KILL_ALL = 8, CMD_EXEC_NEW_REQ = 9, CMD_EXEC_NEW_RESP = 10,
            CMD_EXEC_PID = 11, CMD_EXEC_STDIN = 12, CMD_EXEC_STDOUT = 13, CMD_EXEC_STDERR = 14,
            CMD_EXEC_RESULT = 15, CMD_EXEC_KILL = 16, CMD_EXEC_KILL_ALL = 17,
            CMD_EXEC_STDIN_FLOW_STAT = 18, CMD_EXEC_STDIN_FLOW_STAT_REQ = 19
        }

        public bool Enabled
        {
            get => enabled;
            set
            {
                if (enabled == value) return;
                enabled = value;
                if (value)
                {
                    try { context = new UsbContext(); }
                    catch (Exception ex) { Trace.WriteLine("Failed to create USB Context: " + ex.Message); }

                    mainThreadCts = new CancellationTokenSource();
                    mainThread = new Thread(() => MainThreadLoop(mainThreadCts.Token));
                    mainThread.Start();
                }
                else
                {
                    mainThreadCts?.Cancel();
                    mainThread = null;
                    online = false;

                    StopUsbReader();

                    epWriter = null;

                    if (device != null)
                    {
                        device.Dispose();
                        device = null;
                    }
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                }
            }
        }

        public bool AutoReconnect { get => autoreconnect; set => autoreconnect = value; }
        public ushort ShellPort { get => shellPort; set { shellPort = value; if (ShellEnabled) { ShellEnabled = false; ShellEnabled = true; } } }

        private bool shellEnabled = false;
        public bool ShellEnabled
        {
            get => shellEnabled;
            set
            {
                if (shellEnabled == value) return;
                if (value)
                {
                    var server = new TcpListener(IPAddress.Any, shellPort);
                    Trace.WriteLine($"Listening port {shellPort}");
                    server.Start();
                    shellListenerCts = new CancellationTokenSource();
                    shellListenerThread = new Thread(() => ShellListenerThreadLoop(server, shellListenerCts.Token));
                    shellListenerThread.Start();
                }
                else
                {
                    shellListenerCts?.Cancel();
                    shellListenerThread = null;
                }
                for (var i = 0; i < shellConnections.Length; i++)
                    if (shellConnections[i] != null) { shellConnections[i].Dispose(); shellConnections[i] = null; }
                foreach (var pending in pendingShellConnections) pending.Dispose();
                pendingShellConnections.Clear();
                shellEnabled = value;
            }
        }

        public bool IsOnline => online;

        private void DropAll()
        {
            try { WriteUsb(ClovershellCommand.CMD_SHELL_KILL_ALL, 0); } catch { }
            try { WriteUsb(ClovershellCommand.CMD_EXEC_KILL_ALL, 0); } catch { }
            for (var i = 0; i < shellConnections.Length; i++)
                if (shellConnections[i] != null) { shellConnections[i].Dispose(); shellConnections[i] = null; }
            foreach (var pending in pendingShellConnections) pending.Dispose();
            pendingShellConnections.Clear();
            for (int i = 0; i < execConnections.Length; i++)
                if (execConnections[i] != null) { execConnections[i].Dispose(); execConnections[i] = null; }
            pendingExecConnections.Clear();
        }

        private void MainThreadLoop(CancellationToken token)
        {
            try
            {
                while (enabled && !token.IsCancellationRequested)
                {
                    online = false;
                    while (enabled && !token.IsCancellationRequested)
                    {
                        try
                        {
                            if (context == null)
                            {
                                token.WaitHandle.WaitOne(1000);
                                continue;
                            }

                            device = null;
                            foreach (var d in context.List())
                            {
                                if (d is UsbDevice ud && ud.Descriptor.VendorId == Vid && ud.Descriptor.ProductId == Pid)
                                {
                                    device = d;
                                    break;
                                }
                            }

                            if (device == null)
                            {
                                token.WaitHandle.WaitOne(1000);
                                continue;
                            }

                            device.Open();
                            device.SetConfiguration(1);
                            device.ClaimInterface(0);

                            int inEndp = -1;
                            int outEndp = -1;

                            foreach (var config in device.Configs)
                                foreach (var @interface in config.Interfaces)
                                    foreach (var endp in @interface.Endpoints)
                                    {
                                        if ((endp.EndpointAddress & 0x80) != 0)
                                            inEndp = endp.EndpointAddress;
                                        else
                                            outEndp = endp.EndpointAddress;
                                    }

                            if (inEndp != 0x81 || outEndp != 0x01)
                            {
                                device.Dispose();
                                device = null;
                                token.WaitHandle.WaitOne(1000);
                                continue;
                            }

                            epReader = device.OpenEndpointReader((ReadEndpointID)inEndp, 65536);
                            epWriter = device.OpenEndpointWriter((WriteEndpointID)outEndp);

                            Trace.WriteLine("clovershell connected");
                            KillAll();

                            var body = new byte[65536];
                            int len;
                            while (epReader.Read(body, 0, body.Length, 50, out len) == Error.Success && len > 0) ;

                            StartUsbReader();

                            lastAliveTime = DateTime.Now;
                            online = true;
                            OnConnected(this);

                            while (device.IsOpen && !token.IsCancellationRequested)
                            {
                                Thread.Sleep(100);
                                if ((IdleTime.TotalSeconds >= 10) && (Ping() < 0))
                                    throw new ClovershellException("no answer from device");
                            }
                            break;
                        }
                        catch (ClovershellException ex)
                        {
                            Trace.WriteLine(ex.Message + ex.StackTrace);
                            break;
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine("USB Connection error: " + ex.Message);
                            break;
                        }
                    }
                    if (online)
                    {
                        DropAll();
                        OnDisconnected();
                        Trace.WriteLine("clovershell disconnected");
                    }
                    online = false;

                    StopUsbReader();

                    if (device != null)
                    {
                        device.Dispose();
                        device = null;
                    }

                    if (!autoreconnect) Enabled = false;

                    if (!token.IsCancellationRequested)
                        token.WaitHandle.WaitOne(1000);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Critical error: " + ex.Message + ex.StackTrace);
            }
        }

        private void StartUsbReader()
        {
            epReaderCts = new CancellationTokenSource();
            epReaderThread = new Thread(() => EpReaderLoop(epReaderCts.Token));
            epReaderThread.IsBackground = true;
            epReaderThread.Start();
        }

        private void StopUsbReader()
        {
            if (epReaderCts != null) { epReaderCts.Cancel(); epReaderCts = null; }
            if (epReaderThread != null) { if (epReaderThread.IsAlive) epReaderThread.Join(500); epReaderThread = null; }
            epReader = null;
        }

        private void EpReaderLoop(CancellationToken token)
        {
            var buffer = new byte[65536];
            while (!token.IsCancellationRequested)
            {
                try
                {
                    int readLen;
                    var res = epReader.Read(buffer, 0, buffer.Length, 100, out readLen);
                    if (res == Error.Success && readLen > 0)
                    {
                        EpReaderDataReceived(buffer, readLen);
                    }
                    else if (res == Error.Timeout) continue;
                    else if (res != Error.Success)
                    {
                        Trace.WriteLine("USB Read error: " + res);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine("USB Read exception: " + ex.Message);
                    break;
                }
            }
        }

        private void EpReaderDataReceived(byte[] buffer, int count)
        {
#if VERY_DEBUG
            Debug.WriteLine("<-[CLV] " + BitConverter.ToString(buffer, 0, count));
#endif
            int pos = 0;
            while (count > 0)
            {
                var cmd = (ClovershellCommand)buffer[pos];
                var arg = buffer[pos + 1];
                var len = buffer[pos + 2] | (buffer[pos + 3] * 0x100);
                ProceedPacket(cmd, arg, buffer, pos + 4, len);
                count -= len + 4;
                pos += len + 4;
            }
        }

        private void ProceedPacket(ClovershellCommand cmd, byte arg, byte[] data, int pos, int len)
        {
            if (len < 0) len = data.Length;
#if VERY_DEBUG
            Debug.WriteLine($"<-[CLV] cmd={cmd}, arg={arg:X2}, len={len}, data={BitConverter.ToString(data, pos, len)}");
#endif
            lastAliveTime = DateTime.Now;
            switch (cmd)
            {
                case ClovershellCommand.CMD_PONG: lastPingResponse = new byte[len]; Array.Copy(data, pos, lastPingResponse, 0, len); break;
                case ClovershellCommand.CMD_SHELL_NEW_RESP: AcceptShellConnection(arg); break;
                case ClovershellCommand.CMD_SHELL_OUT: ShellOut(arg, data, pos, len); break;
                case ClovershellCommand.CMD_SHELL_CLOSED: ShellClosed(arg); break;
                case ClovershellCommand.CMD_EXEC_NEW_RESP: NewExecConnection(arg, Encoding.UTF8.GetString(data, pos, len)); break;
                case ClovershellCommand.CMD_EXEC_STDOUT: ExecOut(arg, data, pos, len); break;
                case ClovershellCommand.CMD_EXEC_STDERR: ExecErr(arg, data, pos, len); break;
                case ClovershellCommand.CMD_EXEC_RESULT: ExecResult(arg, data, pos); break;
                case ClovershellCommand.CMD_EXEC_STDIN_FLOW_STAT: ExecStdinStat(arg, data, pos); break;
            }
        }

        private void KillAll()
        {
            var buff = new byte[4];
            buff[0] = (byte)ClovershellCommand.CMD_SHELL_KILL_ALL; buff[1] = 0; buff[2] = 0; buff[3] = 0;
            var r = epWriter.Write(buff, 0, buff.Length, 1000, out int tLen);
            if (tLen != buff.Length) throw new ClovershellException("kill all shell: write error - " + r.ToString());
            buff[0] = (byte)ClovershellCommand.CMD_EXEC_KILL_ALL;
            r = epWriter.Write(buff, 0, buff.Length, 1000, out tLen);
            if (tLen != buff.Length) throw new ClovershellException("kill all exec: write error - " + r.ToString());
        }

        internal void WriteUsb(ClovershellCommand cmd, byte arg, byte[] data = null, int pos = 0, int l = -1)
        {
            if (!IsOnline) throw new ClovershellException("NES Mini is offline");
            if (epWriter == null) return;
            lock (epWriter)
            {
                var len = (l >= 0) ? l : ((data != null) ? (data.Length - pos) : 0);
#if VERY_DEBUG
                Debug.WriteLine($"->[CLV] cmd={cmd}, arg={arg:X2}, len={len}, data={(data != null ? BitConverter.ToString(data, pos, len) : "")}");
#endif
                var buff = new byte[len + 4];
                buff[0] = (byte)cmd; buff[1] = arg; buff[2] = (byte)(len & 0xFF); buff[3] = (byte)((len >> 8) & 0xFF);
                if (data != null) Array.Copy(data, pos, buff, 4, len);
                int tLen = 0; pos = 0; len += 4; int repeats = 0;
                while (pos < len)
                {
                    var res = epWriter.Write(buff, pos, len, 1000, out tLen);
#if VERY_DEBUG
                    Debug.WriteLine("->[CLV] " + BitConverter.ToString(buff, pos, len));
#endif
                    pos += tLen; len -= tLen;
                    if (res != Error.Success)
                    {
                        if (repeats >= 10) break;
                        repeats++;
                        Thread.Sleep(100);
                    }
                }
                if (len > 0) throw new ClovershellException("write error");
            }
        }

        private void ShellListenerThreadLoop(object o, CancellationToken token)
        {
            var server = o as TcpListener;
            try
            {
                while (!token.IsCancellationRequested)
                {
                    while (!server.Pending() && !token.IsCancellationRequested) Thread.Sleep(100);
                    if (token.IsCancellationRequested) return;

                    var connection = new ShellConnection(this, server.AcceptSocket());
                    Trace.WriteLine("Shell client connected");
                    try
                    {
                        if (!online) throw new ClovershellException("NES Mini is offline");
                        pendingShellConnections.Enqueue(connection);
                        WriteUsb(ClovershellCommand.CMD_SHELL_NEW_REQ, 0);
                        int t = 0;
                        while (connection.id < 0)
                        {
                            Thread.Sleep(50);
                            t++;
                            if (t >= 50) throw new ClovershellException("shell request timeout");
                            if (token.IsCancellationRequested) return;
                        }
                    }
                    catch (ClovershellException ex)
                    {
                        Trace.WriteLine(ex.Message + ex.StackTrace);
                        if (connection.socket.Connected)
                            connection.socket.Send(Encoding.ASCII.GetBytes("Error: " + ex.Message));
                        connection.Dispose();
                    }
                }
            }
            catch (ClovershellException ex) { Trace.WriteLine(ex.Message + ex.StackTrace); }
            finally { server.Stop(); }
            shellEnabled = false;
        }

        private void AcceptShellConnection(byte arg)
        {
            try
            {
                var connection = pendingShellConnections.Dequeue();
                if (connection is null) return;
                connection.id = arg;
                shellConnections[connection.id] = connection;
                connection.shellConnectionThread = new Thread(connection.shellConnectionLoop);
                connection.shellConnectionThread.Start();
            }
            catch (ClovershellException ex) { Trace.WriteLine("shell error: " + ex.Message + ex.StackTrace); }
        }

        private void NewExecConnection(byte arg, string command)
        {
            try
            {
                var connection = (from c in pendingExecConnections where c.command == command select c).Last();
                pendingExecConnections.Remove(connection);
                connection.id = arg;
                execConnections[arg] = connection;
                if (connection.stdin != null) { connection.stdinThread = new Thread(connection.stdinLoop); connection.stdinThread.Start(); }
            }
            catch (ClovershellException ex) { Trace.WriteLine("exec error: " + ex.Message); }
            catch (InvalidOperationException ex) { Trace.WriteLine("critical error during exec: " + ex.Message + "\n" + ex.StackTrace); throw new ClovershellException("clovershell is confused"); }
        }

        private void ExecOut(byte arg, byte[] data, int pos, int len)
        {
            var c = execConnections[arg];
            if (c is null) return;
            c.stdout?.Write(data, pos, len);
            c.LastDataTime = DateTime.Now;
            if (len == 0) c.stdoutFinished = true;
        }

        private void ExecErr(byte arg, byte[] data, int pos, int len)
        {
            var c = execConnections[arg];
            if (c is null) return;
            c.stderr?.Write(data, pos, len);
            c.LastDataTime = DateTime.Now;
            if (len == 0) c.stderrFinished = true;
        }

        private void ExecResult(byte arg, byte[] data, int pos)
        {
            var c = execConnections[arg];
            if (c is null) return;
            c.result = data[pos];
            Trace.WriteLine($"{c.command} # exit code: {c.result}");
            c.finished = true;
        }

        private void ExecStdinStat(byte arg, byte[] data, int pos)
        {
            var c = execConnections[arg];
            if (c is null) return;
            c.stdinQueue = data[pos] | data[pos + 1] * 0x100 | data[pos + 2] * 0x10000 | data[pos + 3] * 0x1000000;
            c.stdinPipeSize = data[pos + 4] | data[pos + 5] * 0x100 | data[pos + 6] * 0x10000 | data[pos + 7] * 0x1000000;
        }

        private void ShellOut(byte id, byte[] data, int pos, int len)
        {
            try { if (shellConnections[id] is null) return; shellConnections[id].Send(data, pos, len); }
            catch (ClovershellException ex) { Trace.WriteLine("Socket write error: " + ex.Message + ex.StackTrace); }
        }

        private void ShellClosed(byte id)
        {
            if (shellConnections[id] is null) return;
            shellConnections[id].Dispose();
            shellConnections[id] = null;
        }

        public void Dispose()
        {
            Enabled = false;
            ShellEnabled = false;
            GC.SuppressFinalize(this);
        }

        public TimeSpan IdleTime => DateTime.Now - lastAliveTime;

        public int Ping()
        {
            if (!IsOnline) throw new ClovershellException("NES Mini is offline");
            var rnd = new Random();
            var data = new byte[4];
            rnd.NextBytes(data);
            lastPingResponse = null;
            var start = DateTime.Now;
            WriteUsb(ClovershellCommand.CMD_PING, 0, data);
            int t = 100;
            while ((lastPingResponse is null || !lastPingResponse.SequenceEqual(data)) && (t > 0))
            {
                Thread.Sleep(10);
                t--;
            }
            if (t <= 0) return -1;
            return (int)(DateTime.Now - start).TotalMilliseconds;
        }

        public string ExecuteSimple(string command, int timeout = 2000, bool throwOnNonZero = false)
        {
            var stdOut = new MemoryStream();
            Execute(command, null, stdOut, null, timeout, throwOnNonZero);
            var buff = stdOut.ToArray();
            return Encoding.UTF8.GetString(buff).Trim();
        }

        public int Execute(string command, Stream stdin = null, Stream stdout = null, Stream stderr = null, int timeout = 0, bool throwOnNonZero = false)
        {
            if (!IsOnline) throw new ClovershellException("NES Mini is offline");
            if (throwOnNonZero && stderr is null) stderr = new MemoryStream();
            using var c = new ExecConnection(this, command, stdin, stdout, stderr);
            try
            {
                pendingExecConnections.Add(c);
                WriteUsb(ClovershellCommand.CMD_EXEC_NEW_REQ, 0, Encoding.UTF8.GetBytes(command));
                int t = 0;
                while (c.id < 0)
                {
                    Thread.Sleep(50);
                    t++;
                    if (t >= 50) throw new ClovershellException("exec request timeout");
                }
                while (!c.finished)
                {
                    Thread.Sleep(50);
                    if (!IsOnline) throw new ClovershellDisconnectedException("device goes offline");
                    if (!c.finished && timeout > 0 && (DateTime.Now - c.LastDataTime).TotalMilliseconds > timeout)
                        throw new ClovershellException("clovershell read timeout");
                }
                if (throwOnNonZero && c.result != 0)
                {
                    string errText = "";
                    if (stderr is MemoryStream)
                    {
                        stderr.Seek(0, SeekOrigin.Begin);
                        errText = ": " + new StreamReader(stderr).ReadToEnd();
                    }
                    throw new ClovershellException($"shell command \"{command}\" returned exit code {c.result}{errText}");
                }
                return c.result;
            }
            finally
            {
                if (c.id >= 0) execConnections[c.id] = null;
            }
        }

        public Task<string> ExecuteSimpleAsync(string command, int timeout = 2000, bool throwOnNonZero = false)
        {
            return Task.Run(() => ExecuteSimple(command, timeout, throwOnNonZero));
        }

        public Task<int> ExecuteAsync(string command, Stream stdin = null, Stream stdout = null, Stream stderr = null, int timeout = 0, bool throwOnNonZero = false)
        {
            return Task.Run(() => Execute(command, stdin, stdout, stderr, timeout, throwOnNonZero));
        }

        public void Connect()
        {
            if (Enabled) return;
            Enabled = true;
            while (Enabled && !online) Thread.Sleep(50);
            if (!online) throw new ClovershellException("no clovershell connection, make sure your NES Mini connected, turned on and clovershell mod installed");
        }

        public void Disconnect()
        {
            try { if (device != null) device.Dispose(); }
            catch { }
        }
    }
}