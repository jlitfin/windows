using System;

using Board;
using Pgn;
using UCI;


namespace Joocey
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunOne();
            //return;

            var sampleFilePath = @"C:\Users\jlitfin\Desktop\sample.pgn";
            var reader = new PgnReader(sampleFilePath);
            var gameCount = 0;
            Console.WriteLine($"Processing games from {sampleFilePath}");
            try
            {
                var logFilePath = $@"C:\Users\jlitfin\Documents\source\windows\Joocey\Logs\session_log_{DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss")}.log";
                using (var engine = new Engine(logFilePath))
                {
                    engine.Connect();
                    engine.Eval();

                    var pgns = reader.SelectPGN();
                    var board = new GameState();
                    foreach (var pgn in pgns)
                    {
                        gameCount++;
                        ReWrite($"Processing game {gameCount}.", 1);

                        board.StartPosition();
                        board.WhitePlayer = pgn.Headers["White"];
                        board.BlackPlayer = pgn.Headers["Black"];
                        board.Date = pgn.Headers["Date"];
                        board.Result = pgn.Headers["Result"];
                        board.MoveList = pgn.GetMoveListString();

                        foreach (var mv in pgn.MoveList)
                        {
                            if (!PgnReader.ResultOptions.Contains(mv.White))
                            {
                                board.Move(mv.White);
                            }
                            if (!PgnReader.ResultOptions.Contains(mv.Black))
                            {
                                board.Move(mv.Black);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine(ex.StackTrace);
            }
            Console.WriteLine($"Completed reviewing {gameCount} games.");
            Console.ReadKey();
        }

        public static void RunOne()
        {
            var fen = "8/4k1pp/4p3/p1p1Pp1P/PpB1K2P/5P2/1PP1P3/8 w - f6 0 26";
            var bd = new GameState();
            bd.StartPosition(fen);

            Console.WriteLine(bd.ToString());

            try
            {
                bd.Move("exf6", true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(bd.ToString());
            }

            Console.ReadKey();
        }

        public static void ReWrite(string msg, int lineNumber)
        {
            Console.SetCursorPosition(0, lineNumber);
            Console.Write(msg);
        }
    }
}
