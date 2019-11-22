using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace UCI
{
    public class Engine : IDisposable
    {
        private const int SEARCH_TIME = 20000;
        private const int SEARCH_DEPTH = 24;
        private const int MULTI_PV = 3;

        private bool disposedValue = false;
        private bool engineExit = false;
        private object _lock = new Object();
        private Logger _log;
        private StreamWriter _stdIn;
        private State _state;
        private Queue<UCICommand> _sendq;

        private Process _proc = null;

        public Engine(string logFile = null)
        {
            _log = new Logger(logFile);

            var keys = (typeof(StateKeys)).GetFields().Select(f => f.Name);
            _state = new State(keys);
            _state.StateChanged += StateChanged;
            _state.Initialize(StateKeys.Buffer, new ConcurrentQueue<string>());

            _sendq = new Queue<UCICommand>();
        }

        public void Connect()
        {
            _log.Log("Connecting ..");
            _proc = new Process();

            _proc.StartInfo.FileName = @"C:\Users\jlitfin\Documents\source\windows\Joocey\engines\stockfish_10_x32.exe";
            _proc.StartInfo.CreateNoWindow = true;
            _proc.StartInfo.UseShellExecute = false;
            _proc.StartInfo.RedirectStandardInput = true;
            _proc.StartInfo.RedirectStandardOutput = true;
            _proc.StartInfo.RedirectStandardError = true;
            _proc.EnableRaisingEvents = true;

            _proc.OutputDataReceived += DataReceived;
            _proc.ErrorDataReceived += ErrorReceived;
            _proc.Exited += ExitRecevied;
            _proc.Start();
            _proc.BeginOutputReadLine();
            _proc.BeginErrorReadLine();

            _stdIn = _proc.StandardInput;
            InitializeEngine(true);
            Push(UCICommands.Uci, UCIResponses.UciOk, new StateKeyValue { Key = StateKeys.Connected, Value = true });
        }

        public void InitializeEngine(bool debug = false)
        {
            _log.Log("Initializing ..");
            SetOption(UCIOptions.UCI_AnalyseMode, "true");
            SetOption(UCIOptions.MultiPV, MULTI_PV);

            _state.Set(StateKeys.Initialized, true);
        }

        public void Eval()
        {
            Push(UCICommands.NewGame);
            Push(UCICommands.Position + " startpos moves e2e4 c7c5 b1c3");

            Search();
        }

        public void Search()
        {
            Push($"go depth {SEARCH_DEPTH}", UCIResponses.BestMove);
        }

        private void BufferChanged()
        {
            var buffer = (ConcurrentQueue<string>)_state.Get(StateKeys.Buffer);
            while (buffer.TryDequeue(out string result))
            {
                Console.WriteLine(result);
            }
        }

        public void StateChanged(object sender, StateChangeEventArgs e)
        {
            if (e.Keys.Contains(StateKeys.AwaitResponse) && e.Current[StateKeys.AwaitResponse] == null)
            {
                Send();
            }

            if (e.Keys.Contains(StateKeys.Buffer))
            {
                BufferChanged();
            }
        }


        public void DataReceived(object sender, DataReceivedEventArgs args)
        {
            _log.LogRecv(args.Data);

            var awaiting = _state.Get(StateKeys.AwaitResponse) as string;
            if (awaiting != null)
            {
                if (args.Data.StartsWith(awaiting))
                {
                    _state.Set(StateKeys.AwaitResponse, null);

                    var setKey = _state.Get(StateKeys.SetKey) as StateKeyValue;
                    if (setKey != null)
                    {
                        _state.Set(setKey.Key, setKey.Value);
                    }
                }
                var buffer = (ConcurrentQueue<string>)_state.Get(StateKeys.Buffer);
                buffer.Enqueue(args.Data);
                _state.Set(StateKeys.Buffer, buffer);
            }
        }

        public void ExitRecevied(object sender, EventArgs e)
        {
            _log.Log("Exit Received.");
            _proc.CancelOutputRead();

            engineExit = true;
        }

        public void ErrorReceived(object sender, DataReceivedEventArgs args)
        {
            _log.LogError(args.Data);
        }

        public void Push(string command, string awaitReply = null, StateKeyValue setKey = null)
        {
            lock (_lock)
            {
                _sendq.Enqueue(new UCICommand { Command = command, Reply = awaitReply });
                _sendq.Enqueue(new UCICommand { Command = UCICommands.Ready, Reply = UCIResponses.ReadyOk, SetKey = setKey });
            }
        }

        private void Send()
        {
            lock (_lock)
            {
                if (_state.Get(StateKeys.AwaitResponse) as string is null)
                {
                    if (_sendq.Any())
                    {
                        var command = _sendq.Dequeue();
                        if (!string.IsNullOrEmpty(command.Reply))
                        {
                            _state.Set(StateKeys.AwaitResponse, command.Reply);
                        }
                        _log.LogSend(command.Command);
                        _stdIn.WriteLine(command.Command);
                    }
                }
            }
        }

        public void SetOption(string option, string value)
        {
            lock (_lock)
            {
                _sendq.Enqueue(new UCICommand { Command = $"setoption name {option} value {value}" });
            }
        }

        public void SetOption(string option, int value)
        {
            SetOption(option, value.ToString());
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                    _stdIn.WriteLine(UCICommands.Quit);
                    _proc.WaitForExit();

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
