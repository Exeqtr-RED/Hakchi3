using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace com.clusterrr.clovershell
{
    internal class ExecConnection : IDisposable
    {
        internal readonly ClovershellConnection connection;
        internal readonly string command;
        internal Stream stdin;
        internal Int32 stdinPipeSize;
        internal Int32 stdinQueue;
        internal Stream stdout;
        internal Stream stderr;
        internal int id;
        internal bool finished;
        internal int result;
        internal bool stdinFinished;
        internal bool stdoutFinished;
        internal bool stderrFinished;
        internal Thread stdinThread;
        internal DateTime LastDataTime;

        public ExecConnection(ClovershellConnection connection, string command, Stream stdin, Stream stdout, Stream stderr)
        {
            this.connection = connection;
            this.command = command;
            id = -1;
            stdinPipeSize = 0;
            stdinQueue = 0;
            this.stdin = stdin;
            this.stdout = stdout;
            this.stderr = stderr;
            finished = false;
            stdinFinished = false;
            stdoutFinished = false;
            stderrFinished = false;
            LastDataTime = DateTime.Now;
        }

        public void stdinLoop()
        {
            try
            {
                if (stdin == null) return;
                if (stdin.CanSeek)
                    stdin.Seek(0, SeekOrigin.Begin);
                var buffer = new byte[8 * 1024];
                int l;
                while (connection.IsOnline)
                {
                    l = stdin.Read(buffer, 0, buffer.Length);
                    if (l > 0)
                        connection.WriteUsb(ClovershellConnection.ClovershellCommand.CMD_EXEC_STDIN, (byte)id, buffer, 0, l);
                    else
                        break;
                    LastDataTime = DateTime.Now;
                    if (stdinQueue > 32 * 1024 && connection.IsOnline)
                    {
                        Trace.WriteLine(string.Format("queue: {0} / {1}, {2}MB / {3}MB ({4}%)",
                            stdinQueue, stdinPipeSize, stdin.Position / 1024 / 1024, stdin.Length / 1024 / 1024, stdin.Length == 0 ? 100 : (100 * stdin.Position / stdin.Length)));
                        while (stdinQueue > 16 * 1024)
                        {
                            Thread.Sleep(50);
                            connection.WriteUsb(ClovershellConnection.ClovershellCommand.CMD_EXEC_STDIN_FLOW_STAT_REQ, (byte)id);
                        }
                    }
                }
                connection.WriteUsb(ClovershellConnection.ClovershellCommand.CMD_EXEC_STDIN, (byte)id); // eof
                if (stdinQueue > 0 && connection.IsOnline)
                {
                    Thread.Sleep(50);
                    connection.WriteUsb(ClovershellConnection.ClovershellCommand.CMD_EXEC_STDIN_FLOW_STAT_REQ, (byte)id);
                }
                stdinFinished = true;
            }
            // stdin.Close() from Dispose() unblocks stdin.Read() —
            // throws ObjectDisposedException (or returns 0 if stream is at
            // EOF, which exits the loop normally). IOException covers the
            // case where stdin is a FileStream and the underlying handle
            // is invalidated (e.g. on USB disconnect).
            catch (ObjectDisposedException) { }
            catch (IOException) { }
            catch (ClovershellException ex)
            {
                Trace.WriteLine("stdin error: " + ex.Message + ex.StackTrace);
            }
            finally
            {
                stdinThread = null;
            }
        }

        public void Dispose()
        {
            // Cooperative shutdown: close stdin to unblock stdin.Read() in
            // the worker thread, then Join with a short timeout so we don't
            // return while the worker is still in its finally block.
            //
            // Closing stdin is safe: callers pass File.OpenRead(...) without
            // keeping a reference (MainForm.cs:3363/3367/3399/3403), so this
            // is the only path that frees the file handle.
            var thread = stdinThread;
            if (stdin != null)
            {
                try { stdin.Close(); } catch { /* already closed */ }
            }
            // Join only if we're being called from a different thread —
            // otherwise we'd deadlock (worker thread calling Dispose on
            // itself, which doesn't happen today but is a defensive guard).
            if (thread != null && thread != Thread.CurrentThread)
                thread.Join(TimeSpan.FromSeconds(2));
        }
    }

}
