using System;
using System.Collections.Generic;
using System.Text;

namespace UCI
{
    public class UCICommands
    {
        public const string FromFen = "position fen";
        public const string MakeMoves = "moves";
        public const string NewGame = "ucinewgame";
        public const string Position = "position";  // startpos, fen
        public const string Quit = "quit";
        public const string Ready = "isready";
        public const string Search = "go";
        public const string SearchMoves = "searchmoves";
        public const string Uci = "uci";
    }
}
