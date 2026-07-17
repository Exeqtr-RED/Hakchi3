using com.clusterrr.hakchi_gui;
using com.clusterrr.ssh;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace com.clusterrr.hakchi_gui.SshClient
{
    // ИСПРАВЛЕНО: Использован основной конструктор (primary constructor)
    public class SshClientWrapper(
        string serviceName,
        string serviceType,
        string ipAddress,
        int? port,
        string username,
        string password) : ISystemShell, INetworkShell
    {
        public const ushort DEFAULT_SSH_PORT = 22;

        public event OnConnectedEventHandler OnConnected = delegate { };
        public event OnDisconnectedEventHandler OnDisconnected = delegate { };

        // ИСПРАВЛЕНО: Явно указан Renci.SshNet.SshClient, чтобы не путать с пространством имен
        private Renci.SshNet.SshClient sshClient;
        private Thread connectThread;
        private List<IListener> listeners;
        private CancellationTokenSource connectCts;

        private bool enabled;
        private bool hasConnected;
        private DateTime lastDisconnected = DateTime.Now.Subtract(TimeSpan.FromMilliseconds(3000));

        private int? currentPort = port;

        public bool AutoReconnect { get; set; }

        public bool Enabled
        {
            get => enabled;
            set
            {
                if (enabled == value) return;
                enabled = value;
                if (value)
                {
                    // ИСПРАВЛЕНО: Составной оператор назначения (??=)
                    listeners ??=
                    [
                        new MdnsListener(serviceName, serviceType),
                        new DnsListener(serviceName)
                    ];

                    if (connectThread == null)
                    {
                        connectCts = new CancellationTokenSource();
                        connectThread = new Thread(() => ConnectThreadLoop(connectCts.Token));
                        connectThread.Start();
                    }
                }
                else
                {
                    connectCts?.Cancel();
                    connectThread = null;

                    if (listeners != null)
                    {
                        listeners.ForEach(l => l.Dispose());
                        listeners.Clear();
                        listeners = null;
                    }
                    if (sshClient != null)
                    {
                        if (sshClient.IsConnected)
                        {
                            sshClient.Disconnect();
                        }
                        sshClient.Dispose();
                        sshClient = null;
                    }
                }
            }
        }

        public bool IsOnline => sshClient != null && sshClient.IsConnected;

        public ushort ShellPort => 23;

        public bool ShellEnabled
        {
            get => IsOnline;
            set { }
        }

        public string IPAddress { get; private set; } = ipAddress;

        public void Dispose()
        {
            Enabled = false;
            GC.SuppressFinalize(this);
        }

        public void Connect()
        {
            if (IsOnline || string.IsNullOrEmpty(IPAddress) || IPAddress == "0.0.0.0")
                return;

            try
            {
                if (sshClient == null)
                {
                    sshClient = new Renci.SshNet.SshClient(IPAddress, currentPort.Value, username, password);
                    sshClient.ErrorOccurred += SshClient_OnError;
                }
                if (!sshClient.IsConnected)
                {
                    sshClient.Connect();
                }
                Trace.WriteLine("SSH shell connected");
                Trace.WriteLine($"IP Address: {IPAddress}");
                Trace.WriteLine($"Encryption: {sshClient.ConnectionInfo.CurrentServerEncryption}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to connect to SSH server at {IPAddress}:{currentPort} ({ex.Message})");
                sshClient = null;
                IPAddress = null;
                currentPort = null;
                return;
            }

            listeners.ForEach(l => l.Cycle());
            hasConnected = true;
            OnConnected(this);
        }

        public void Disconnect()
        {
            if (sshClient == null) return;
            if (sshClient.IsConnected)
            {
                sshClient.Disconnect();
            }
        }

        private void ConnectThreadLoop(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        if (!IsOnline)
                        {
                            if (hasConnected)
                            {
                                Trace.WriteLine("SSH shell disconnected");
                                lastDisconnected = DateTime.Now;
                                if (sshClient != null)
                                {
                                    sshClient.Dispose();
                                    sshClient = null;
                                }
                                IPAddress = null;
                                hasConnected = false;
                                OnDisconnected();
                            }
                            else if (AutoReconnect)
                            {
                                if (DateTime.Now.Subtract(lastDisconnected).TotalMilliseconds > 3000)
                                {
                                    AttemptConnect();
                                }
                            }
                        }
                        token.WaitHandle.WaitOne(500);
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine("Error during connect loop: " + ex.Message + ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Critical error: " + ex.Message + ex.StackTrace);
            }
        }

        private void AttemptConnect()
        {
            foreach (IListener l in listeners)
            {
                foreach (var dev in l.Available)
                {
                    foreach (var a in dev.Addresses)
                    {
                        Trace.WriteLine($"Attempting to connect to {a}...");
                        IPAddress = a.ToString();
                        currentPort = dev.Port;
                        Connect();
                        if (IsOnline)
                        {
                            Trace.WriteLine("Success!");
                            return;
                        }
                        else
                            Trace.WriteLine("Failure.");
                    }
                }
            }
        }

        private int SendPing(string ip, bool verbose = false)
        {
            try
            {
                // ИСПРАВЛЕНО: Упрощенное выражение new
                using Ping pingSender = new();
                PingReply reply = pingSender.Send(ip, 500);
                if (reply != null && reply.Status.Equals(IPStatus.Success))
                {
                    if (verbose)
                        Trace.WriteLine($"Pinged {reply.Address}, {reply.RoundtripTime}ms");
                    IPAddress = reply.Address.ToString();
                    return (int)reply.RoundtripTime;
                }
            }
#pragma warning disable CS0168
            catch (Exception ex)
            {
#if VERY_DEBUG
                Debug.WriteLine($"Error during ping \"{IPAddress ?? serviceName}\": {(ex.InnerException ?? ex).Message}");
#endif
            }
#pragma warning restore CS0168
            return -1;
        }

        public int Ping()
        {
            if (IPAddress == "0.0.0.0")
                IPAddress = null;
            if (string.IsNullOrEmpty(IPAddress))
                return -1;
            return SendPing(IPAddress, true);
        }

        public string ExecuteSimple(string command, int timeout = 2000, bool throwOnNonZero = false)
        {
            SshCommand sshCommand = sshClient.CreateCommand(command);
            if (timeout > 0)
                sshCommand.CommandTimeout = TimeSpan.FromMilliseconds(timeout);

            string result = sshCommand.Execute();
            int exitCode = sshCommand.ExitStatus ?? 0;

            if (exitCode != 0 && throwOnNonZero)
            {
                throw new SshClientException($"Shell command \"{command}\" returned exit code {exitCode} {sshCommand.Error}");
            }

            Trace.WriteLine($"{command} # exit code {exitCode}");

            return result.Trim();
        }

        public int Execute(string command, Stream stdin = null, Stream stdout = null, Stream stderr = null, int timeout = 0, bool throwOnNonZero = false)
        {
            SshCommand sshCommand = sshClient.CreateCommand(command);
            if (timeout > 0)
                sshCommand.CommandTimeout = TimeSpan.FromMilliseconds(timeout);

            IAsyncResult execResult = sshCommand.BeginExecute(null, null);

            // Ввод через SshCommand в современном SSH.NET не поддерживается напрямую
            sshCommand.EndExecute(execResult);

            if (stdout != null && sshCommand.OutputStream != null)
            {
                sshCommand.OutputStream.CopyTo(stdout);
            }
            if (stderr != null && sshCommand.ExtendedOutputStream != null)
            {
                sshCommand.ExtendedOutputStream.CopyTo(stderr);
            }

            int exitCode = sshCommand.ExitStatus ?? 0;
            if (exitCode != 0 && throwOnNonZero)
            {
                throw new SshClientException($"Shell command \"{command}\" returned exit code {exitCode} {sshCommand.Error}");
            }

            Trace.WriteLine($"{command} # exit code {exitCode}");

            return exitCode;
        }

        public Task<string> ExecuteSimpleAsync(string command, int timeout = 2000, bool throwOnNonZero = false)
        {
            return Task.Run(() => ExecuteSimple(command, timeout, throwOnNonZero));
        }

        public Task<int> ExecuteAsync(string command, Stream stdin = null, Stream stdout = null, Stream stderr = null, int timeout = 0, bool throwOnNonZero = false)
        {
            return Task.Run(() => Execute(command, stdin, stdout, stderr, timeout, throwOnNonZero));
        }

        private void SshClient_OnError(object src, Renci.SshNet.Common.ExceptionEventArgs args)
        {
#if VERY_DEBUG
            Debug.WriteLine($"Error occurred on SSH client: {args.Exception.Message}\n{args.Exception.InnerException}\n{args.Exception.StackTrace}");
#endif
            Disconnect();
        }
    }
}