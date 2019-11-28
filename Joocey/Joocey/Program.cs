using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Board;
using Core;
using Pgn;
using UCI;


namespace Joocey
{
    class Program
    {
        static void Main(string[] args)
        {
            var processTask = RunOne();
            Task.WaitAll(processTask);
        }

        public static async Task RunOne()
        {
            var connectionString = @"Server=(localdb)\localJooce;Initial Catalog=jooce;Integrated Security=true";
            var pgnRepository = new PgnRepository(connectionString);
            var repository = new Repository(connectionString);


            //RunOne();
            //Console.ReadKey();
            //return;
            var player = "iojedi";
            var filePath = @"C:\Users\jlitfin\Desktop\lichess_iojedi_2019-11-20.pgn";
            var reader = new PgnReader(filePath);
            var gameCount = 0;
            Console.WriteLine($"Processing games from {filePath}");
            try
            {
                var now = DateTime.Now.ToString("yyyy.MM.dd");
                var logFilePath = $@"C:\Users\jlitfin\Documents\source\windows\Joocey\Logs\session_log_{now}.log";
                var sessionDataPath = $@"C:\Users\jlitfin\Documents\source\windows\Joocey\Data\session_log_{now}.data";

                using (var sw = new StreamWriter(sessionDataPath, true))
                {
                    var pgns = reader.SelectPGN();
                    foreach (var pgn in pgns)
                    {
                        pgn.Id = await pgnRepository.Save(pgn);

                        gameCount++;
                        ReWrite($"Processing game {gameCount}.", 1);

                        var board = new GameState();
                        board.Moves = pgn.MoveList;

                        var side = Side.White;
                        if (pgn.Headers.ContainsKey("Black") && pgn.Headers["Black"].Contains(player)) side = Side.Black;

                        Console.WriteLine(board.ToString());
                        sw.WriteLine(board.ToString());
                        var evalTask = board.Evaluate(side, logFilePath);

                        Task.WaitAll(evalTask);
                        foreach (var rec in evalTask.Result)
                        {
                            sw.WriteLine(rec.ToString());
                            sw.WriteLine($" --> {rec.EngineResult.Variations.First().Line}");
                        }
                        await repository.SaveEvaluation(pgn.Id, EvaluationType.Blunder, evalTask.Result);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine(ex.StackTrace);
            }
            Console.WriteLine();
            Console.WriteLine($"Completed reviewing {gameCount} games.");
            Console.ReadKey();
        }

        public static void ReWrite(string msg, int lineNumber)
        {
            //Console.SetCursorPosition(0, lineNumber);
            //Console.Write(new string(' ', Console.BufferWidth));
            //Console.SetCursorPosition(0, lineNumber);
            //Console.Write(msg);

            Console.WriteLine(msg);
        }
    }
}
