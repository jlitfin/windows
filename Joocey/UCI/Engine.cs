using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Core;

namespace UCI
{
    public class Engine : IDisposable
    {
        public const int SEARCH_DEPTH = 20;
        private const int MULTI_PV = 1;
        private const string BOOK = @"C:\Users\jlitfin\Documents\source\windows\Joocey\Resources\komodo.bin";

        private bool disposedValue = false;
        private readonly object _lock = new Object();
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

            _proc.StartInfo.FileName = @"C:\Users\jlitfin\Documents\source\windows\Joocey\engines\Stockfish_Polyglot_10_x64.exe";
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
            Push(UCICommands.Uci, UCIResponses.UciOk, new StateKeyValue { Key = StateKeys.Connected, Value = true });

            InitializeEngine(true);
            _state.Set(StateKeys.Connected, true);
            
        }

        private void InitializeEngine(bool debug = false)
        {
            _log.Log("Initializing ..");
            SetOption(UCIOptions.BookFile, BOOK);
            SetOption(UCIOptions.UCI_AnalyseMode, "true");
            SetOption(UCIOptions.MultiPV, MULTI_PV);
            Push(UCICommands.NewGame);
            _state.Set(StateKeys.Initialized, true);
        }

        public void Eval(string fen)
        {
            Eval(fen, null);
        }

        public void Eval(string fen, string moves)
        {
            Push($"{UCICommands.FromFen} {fen}");
            Search(moves);
        }

        private void Search(string moves = null)
        {
            Push($"go depth {SEARCH_DEPTH} {(!string.IsNullOrEmpty(moves) ? UCICommands.SearchMoves : string.Empty)} {moves}", UCIResponses.BestMove);
        }

        public async Task<SearchResult> GetSearchResult()
        {
            var waiting = true;
            var buffer = (ConcurrentQueue<string>)_state.Get(StateKeys.Buffer);
            var searchSession = new Stack<string>();

            SearchResult retVal = null;
            while (waiting)
            {
                Send();
                if (!buffer.IsEmpty)
                {
                    buffer.TryDequeue(out string result);
                    if (!string.IsNullOrEmpty(result))
                    {
                        searchSession.Push(result);
                        if (result.Contains(UCIResponses.BestMove))
                        {
                            retVal = new SearchResult
                            {
                                BestMove = searchSession.Pop(),
                                Variations = new List<Variation>()
                            };
                            for (int i = 0; i < MULTI_PV; ++i)
                            {
                                if (searchSession.Any())
                                {
                                    retVal.Variations.Add(new Variation(searchSession.Pop()));
                                }
                                else
                                {
                                    break;
                                }
                            }
                            waiting = false;
                        }
                    }
                }
                else if (retVal == null)
                {
                    await Task.Delay(1);
                }
            }
            return retVal;
        }

        private void StateChanged(object sender, StateChangeEventArgs e)
        {
            if (e.Keys.Contains(StateKeys.AwaitResponse) && e.Current[StateKeys.AwaitResponse] == null)
            {
                Send();
            }
        }

        private void DataReceived(object sender, DataReceivedEventArgs args)
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

        private void ExitRecevied(object sender, EventArgs e)
        {
            _log.Log("Exit Received.");
            _proc.CancelOutputRead();
        }

        private void ErrorReceived(object sender, DataReceivedEventArgs args)
        {
            _log.LogError(args.Data);
        }

        private void Push(string command, string awaitReply = null, StateKeyValue setKey = null)
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

        private void SetOption(string option, string value)
        {
            lock (_lock)
            {
                _sendq.Enqueue(new UCICommand { Command = $"setoption name {option} value {value}" });
            }
        }

        private void SetOption(string option, int value)
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
