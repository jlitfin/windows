using System;
using System.IO;

namespace UCI
{
    public class Logger : IDisposable
    {
        private bool disposedValue = false;
        private StreamWriter _log;

        public Logger(string logFile)
        {
            if (!string.IsNullOrEmpty(logFile))
            {
                _log = new StreamWriter(logFile);
            }
        }

        public void Log(string msg)
        {
            if (_log == null) return;

            _log.WriteLine($"[{DateTime.Now.ToString("hh:mm:ss")}] INF: {msg}");
            _log.Flush();
        }

        public void LogSend(string msg)
        {
            if (_log == null) return;

            _log.WriteLine($"[{DateTime.Now.ToString("hh:mm:ss")}] SND: {msg}");
            _log.Flush();
        }

        public void LogRecv(string msg)
        {
            if (_log == null) return;

            _log.WriteLine($"[{DateTime.Now.ToString("hh:mm:ss")}] RCV: {msg}");
            _log.Flush();
        }

        public void LogError(string msg)
        {
            if (_log == null) return;

            _log.WriteLine($"[{DateTime.Now.ToString("hh:mm:ss")}] ERR: {msg}");
            _log.Flush();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _log?.Flush();
                    _log?.Close();
                    _log?.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
