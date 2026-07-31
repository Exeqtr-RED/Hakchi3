using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace com.clusterrr.clovershell
{
    internal class ShellConnection : IDisposable
    {
        public readonly ClovershellConnection connection;
        internal Socket socket;
        internal int id;
        internal Thread shellConnectionThread;

        public ShellConnection(ClovershellConnection connection, Socket socket)
        {
            this.connection = connection;
            this.socket = socket;
            id = -1;
            socket.Send(new byte[] { 0xFF, 0xFD, 0x03 }); // Do Suppress Go Ahead
            socket.Send(new byte[] { 0xFF, 0xFB, 0x03 }); // Will Suppress Go Ahead
            socket.Send(new byte[] { 0xFF, 0xFB, 0x01 }); // Will Echo
        }

        internal void shellConnectionLoop()
        {
            try
            {
                var buff = new byte[1024];
                while (socket.Connected)
                {
                    var l = socket.Receive(buff);
                    if (l > 0)
                    {
                        int start = 0;
                        int pos = 0;
                        do
                        {
                            if ((pos + 1 < l) && (buff[pos] == '\r') && (buff[pos + 1] == '\n')) // New line?
                            {
                                // Hey, dot not send \r\n! I'll cut it to \n
                                buff[pos] = (byte)'\n';
                                connection.WriteUsb(ClovershellConnection.ClovershellCommand.CMD_SHELL_IN, (byte)id, buff, start, pos - start + 1);
                                pos += 2;
                                start = pos;
                            }
                            else if ((pos + 1 < l) && (buff[pos] == 0xFF)) // Telnet command?
                            {
                                if (buff[pos + 1] == 0xFF) // Or just 0xFF...
                                {
                                    connection.WriteUsb(ClovershellConnection.ClovershellCommand.CMD_SHELL_IN, (byte)id, buff, start, pos - start + 1);
                                    pos += 2;
                                    start = pos;
                                }
                                else if (pos + 2 < l)
                                {
                                    if (pos - start > 0)
                                        connection.WriteUsb(ClovershellConnection.ClovershellCommand.CMD_SHELL_IN, (byte)id, buff, start, pos - start);
                                    var cmd = buff[pos + 1]; // Telnet command code
                                    var opt = buff[pos + 2]; // Telnet option code
#if VERY_DEBUG
                                    Debug.WriteLine(string.Format("Telnet command: CMD={0:X2} ARG={1:X2}", cmd, opt));
#endif
                                    pos += 3;
                                    start = pos;
                                }
                            }
                            else pos++; // No, moving to next character
                            if ((pos == l) && (l - start > 0)) // End of packet
                            {
                                connection.WriteUsb(ClovershellConnection.ClovershellCommand.CMD_SHELL_IN, (byte)id, buff, start, l - start);
                            }
                        } while (pos < l);
                    }
                    else
                        break;
                }
            }
            // socket.Close() from Dispose() unblocks socket.Receive() with a
            // SocketException — caught here. ObjectDisposedException covers the
            // race where socket is closed between the Connected check and Send.
            catch (SocketException)
            {
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message + ex.StackTrace);
                try
                {
                    if (socket.Connected)
                        socket.Send(Encoding.ASCII.GetBytes("Error: " + ex.Message));
                }
                catch { /* socket already closed by Dispose() */ }
            }
            finally
            {
                shellConnectionThread = null;
                Trace.WriteLine(string.Format("Shell client {0} disconnected", id));
                if (socket != null)
                    socket.Close();
                connection.shellConnections[id] = null;
            }
        }

        public void Dispose()
        {
            // Cooperative shutdown: close the socket first to unblock
            // socket.Receive() in the worker thread, then Join with a short
            // timeout so we don't return while the worker is still in its
            // finally block (which clears shellConnections[id]).
            var thread = shellConnectionThread;
            try { if (socket != null) socket.Close(); }
            catch { /* already closed */ }
            socket = null;
            if (id > 0)
                connection.shellConnections[id] = null;
            // Join only if we're being called from a different thread —
            // otherwise we'd deadlock (worker thread calling Dispose on itself).
            if (thread != null && thread != Thread.CurrentThread)
                thread.Join(TimeSpan.FromSeconds(2));
        }

        internal void Send(byte[] data, int pos, int len)
        {
            socket.Send(data, pos, len, SocketFlags.None);
        }
    }

}
