using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Board
{
    public class GameState
    {
        private int _fullMoveNumber;
        private int _halfMoveClock;
        private SQ _enPassantSquare;
        private char[] _castlingStatus;
        private Side _onMove;
        private Piece[] _b;

        public static readonly HashSet<string> Pieces = new HashSet<string>(new string[] { "R", "N", "B", "Q", "K", "O" }, StringComparer.OrdinalIgnoreCase);

        public readonly Dictionary<SQ, BoardIndex> BoardIndeces = new Dictionary<SQ, BoardIndex>();

        public Piece this[SQ sq]
        {
            get
            {
                if ((int)sq >= 0 && (int)sq < 64)
                {
                    return _b[(int)sq];
                }
                else
                {
                    throw new Exception($"Index out of range. ({(int)sq})");
                }
            }
        }

        public GameState()
        {
            WhitePlayer = "White Player";
            BlackPlayer = "Black Player";
            Date = DateTime.Now.ToString("yyyy.MM.dd");
            Result = "1/2-1/2";
            MoveList = string.Empty;

            var rank = 9;
            var file = 0;
            for (int i = 0; i < 64; ++i)
            {
                if (i % 8 == 0)
                {
                    --rank;
                    file = 0;
                }
                BoardIndeces.Add((SQ)i, new BoardIndex(++file, rank));
            }
        }

        public string WhitePlayer { get; set; }
        public string BlackPlayer { get; set; }
        public string Date { get; set; }
        public string Result { get; set; }
        public string MoveList { get; set; }

        public string CastlingStatus
        {
            get
            {
                if (_castlingStatus == null || _castlingStatus.Length == 0)
                {
                    return "-";
                }
                return new string(_castlingStatus);
            }
        }

        public SQ EnPassantSquare
        {
            get
            {
                return _enPassantSquare;
            }
        }

        public void StartPosition(string fen = null)
        {
            _b = new Piece[64];
            if (!string.IsNullOrEmpty(fen))
            {
                var tokens = fen.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length != 6)
                {
                    throw new Exception($"Invalid FEN format -> ( {fen} )");
                }

                _onMove = tokens[1] == "w" ? Side.White : Side.Black;
                _castlingStatus = tokens[2].ToArray();
                _enPassantSquare = tokens[3] == "-" ? SQ.xx : (SQ)Enum.Parse(typeof(SQ), tokens[3]);
                _halfMoveClock = int.Parse(tokens[4]);
                _fullMoveNumber = int.Parse(tokens[5]);

                var ids = tokens[0].ToArray();
                var j = 0;
                for (var i = 0;  i < ids.Length && j < 64; ++i)
                {
                    if (ids[i] == '/') continue;

                    if (int.TryParse(ids[i].ToString(), out var num))
                    {
                        while (num > 0 && j < 64)
                        {
                            _b[j] = new Empty(Constants.EmptyIdentifier, (SQ)j);
                            --num;
                            ++j;
                        }
                    }
                    else
                    {
                        switch (ids[i])
                        {
                            case 'p':
                            case 'P':
                                _b[j] = new Pawn(ids[i].ToString(), (SQ)j);
                                break;
                            case 'k':
                            case 'K':
                                _b[j] = new King(ids[i].ToString(), (SQ)j);
                                break;
                            case 'q':
                            case 'Q':
                                _b[j] = new Queen(ids[i].ToString(), (SQ)j);
                                break;
                            case 'r':
                            case 'R':
                                _b[j] = new Rook(ids[i].ToString(), (SQ)j);
                                break;
                            case 'b':
                            case 'B':
                                _b[j] = new Bishop(ids[i].ToString(), (SQ)j);
                                break;
                            case 'n':
                            case 'N':
                                _b[j] = new Knight(ids[i].ToString(), (SQ)j);
                                break;
                        }
                        ++j;
                    }
                }
            }
            else
            {
                _fullMoveNumber = 1;
                _halfMoveClock = 0;
                _castlingStatus = new char[] { 'K', 'Q', 'k', 'q' };
                _enPassantSquare = SQ.xx;
                _onMove = Side.White;

                _b[(int)SQ.a8] = new Rook("r", SQ.a8);
                _b[(int)SQ.b8] = new Knight("n", SQ.b8);
                _b[(int)SQ.c8] = new Bishop("b", SQ.c8);
                _b[(int)SQ.d8] = new Queen("q", SQ.d8);
                _b[(int)SQ.e8] = new King("k", SQ.e8);
                _b[(int)SQ.f8] = new Bishop("b", SQ.f8);
                _b[(int)SQ.g8] = new Knight("n", SQ.g8);
                _b[(int)SQ.h8] = new Rook("r", SQ.h8);

                for (int i = 8; i < 16; ++i)
                {
                    var sq = (SQ)i;
                    _b[(int)sq] = new Pawn("p", sq);
                }

                for (int i = 16; i < 48; ++i)
                {
                    var sq = (SQ)i;
                    _b[(int)sq] = new Empty(Constants.EmptyIdentifier, sq);
                }

                for (int i = 48; i < 56; ++i)
                {
                    var sq = (SQ)i;
                    _b[(int)sq] = new Pawn("P", sq);
                }

                _b[(int)SQ.a1] = new Rook("R", SQ.a1);
                _b[(int)SQ.b1] = new Knight("N", SQ.b1);
                _b[(int)SQ.c1] = new Bishop("B", SQ.c1);
                _b[(int)SQ.d1] = new Queen("Q", SQ.d1);
                _b[(int)SQ.e1] = new King("K", SQ.e1);
                _b[(int)SQ.f1] = new Bishop("B", SQ.f1);
                _b[(int)SQ.g1] = new Knight("N", SQ.g1);
                _b[(int)SQ.h1] = new Rook("R", SQ.h1);
            }
        }

        private bool IsAttacked(SQ toCheck, Side sideOnMove, bool debug = false)
        {
            if (debug)
            {
                Console.WriteLine($"Testing if {toCheck} is attacked when {sideOnMove} is moving.");
                Console.WriteLine(ToDebugString());
            }
            var pieces = _b.Where(p => p.Side == sideOnMove);
            var testMoves = pieces.SelectMany(p => p.GenMoves(this));
            var isAttacked = testMoves.Where(m => m.Destination == toCheck).Any();

            if (debug)
            {
                Console.WriteLine($"IsAttacked = {isAttacked}");
            }

            return isAttacked;
        }

        public void Move(Move move, bool debug = false)
        {
            if (debug)
            {
                Console.WriteLine();
                Console.WriteLine($"Simulating {move.MoveText}");
            }
            //
            // update board state related to pawn moves
            //
            if (move.Piece is Pawn)
            {
                if (move.IsCapture && move.Destination == EnPassantSquare)
                {
                    var bi = BoardIndeces[EnPassantSquare];
                    var setEmpty = bi.Rank == 6 ? new BoardIndex(bi.File, 5) : new BoardIndex(bi.File, 4);
                    _b[(int)setEmpty.Square] = new Empty(Constants.EmptyIdentifier, setEmpty.Square);
                }
                //
                // reset enpassant AFTER eval-ing it
                //
                var range = BoardIndeces[move.Destination].Rank - BoardIndeces[move.Piece.CurrentSquare].Rank;
                if (Math.Abs(range) > 1)
                {
                    _enPassantSquare = move.Piece.CurrentSquare + ((-range / 2) * 8);
                }
                else
                {
                    _enPassantSquare = SQ.xx;
                }
            }
            else
            {
                _enPassantSquare = SQ.xx;
            }
            //
            // update board state related to rook moves
            //
            if (move.Piece is Rook)
            {
                switch (move.Piece.CurrentSquare)
                {
                    case SQ.a1:
                        _castlingStatus = _castlingStatus.Where(c => c != 'Q').ToArray();
                        break;

                    case SQ.h1:
                        _castlingStatus = _castlingStatus.Where(c => c != 'K').ToArray();
                        break;

                    case SQ.a8:
                        _castlingStatus = _castlingStatus.Where(c => c != 'q').ToArray();
                        break;

                    case SQ.h8:
                        _castlingStatus = _castlingStatus.Where(c => c != 'k').ToArray();
                        break;
                }
            }
            //
            // update board state related to king moves
            //
            if (move.Piece is King)
            {
                switch (move.Piece.CurrentSquare)
                {
                    case SQ.e1:
                        _castlingStatus = _castlingStatus.Where(c => !Char.IsUpper(c)).ToArray();
                        break;

                    case SQ.e8:
                        _castlingStatus = _castlingStatus.Where(c => !Char.IsLower(c)).ToArray();
                        break;
                }
            }
            //
            // perform move
            //
            _b[(int)move.Piece.CurrentSquare] = new Empty(Constants.EmptyIdentifier, move.Piece.CurrentSquare); ;
            if (move.IsPromotion)
            {
                _b[(int)move.Destination] = move.PromotionPiece;
            }
            else
            {
                _b[(int)move.Destination] = PieceFactory.Create(move.Piece);
                _b[(int)move.Destination].CurrentSquare = move.Destination;
            }
            //
            // update board state related all pieces
            //
            if (move.IsCapture || move.IsPawnAdvance) _halfMoveClock = 0;
            //
            // update board state for completed move
            //
            if (_onMove == Side.Black) _fullMoveNumber++;
            _onMove = _onMove == Side.White ? Side.Black : Side.White;
        }

        public void Move(string move, bool debug = false)
        {
            move = ParseMove(move);

            var allMoves = _b.Where(p => p.Side == _onMove)
                .SelectMany(p => p.GenMoves(this));
            //
            // test for king exposure legality, this test is not complete but will filter out
            // dupe targets that trigger the origin tag incorrectly when the move is illegal,
            // (e.g. castling may be illegal and we won't catch that but we trust the pgn source)
            //
            // Test if moving a piece leaves the king in check
            //
            var legalMoves = new List<Move>();
            var testBoard = new GameState();
            foreach (var tm in allMoves)
            {
                testBoard.StartPosition(ToFen());
                if (tm.IsCastle)
                {
                    legalMoves.Add(tm);
                }
                else
                {
                    testBoard.Move(tm, debug);
                    var king = testBoard._b.Where(p => p.Identifier == (_onMove == Side.White ? "K" : "k")).Single();
                    if (!testBoard.IsAttacked(king.CurrentSquare, king.Side == Side.White ? Side.Black : Side.White, debug))
                    {
                        legalMoves.Add(tm);
                    }
                }
            }
            //
            // update move text for duped targets
            //
            var movesByPiece = legalMoves.ToLookup(k => k.Piece.Key);
            foreach (var kv in movesByPiece)
            {
                var dupeTargets = kv.Where(mv => !mv.MoveText.Contains("O-O")).GroupBy(k => k.Destination).Where(x => x.Count() > 1);
                foreach (var grp in dupeTargets)
                {
                    var byOriginFile = grp.GroupBy(m => m.Piece.CurrentFile).Where(x => x.Count() > 1);
                    var byOriginRank = grp.GroupBy(m => m.Piece.CurrentRank).Where(x => x.Count() > 1);
                    foreach (var f in byOriginFile.SelectMany(x => x))
                    {
                        f.IncludeOriginRank = true;
                    }
                    foreach (var f in grp)
                    {
                        f.IncludeOriginFile  = !f.IncludeOriginRank;
                    }
                }
            }

            var moves = movesByPiece.SelectMany(x => x).Where(x => x.MoveText == move);
            if (moves == null || !moves.Any())
                throw new Exception($"Illegal move detected ({move}){Environment.NewLine}{this.ToString()}{Environment.NewLine}{string.Join("\n", allMoves.Select(m => $"{m.MoveText}"))}");

            //
            // execute the moves
            //
            foreach (var mv in moves)
            {
                var moving = mv.Piece;
                //
                // update board state related to pawn moves
                //
                if (mv.Piece is Pawn)
                {
                    if (mv.IsCapture && mv.Destination == EnPassantSquare)
                    {
                        var bi = BoardIndeces[EnPassantSquare];
                        var setEmpty = bi.Rank == 6 ? new BoardIndex(bi.File, 5) : new BoardIndex(bi.File, 4);
                        _b[(int)setEmpty.Square] = new Empty(Constants.EmptyIdentifier, setEmpty.Square);
                    }
                    //
                    // reset enpassant AFTER eval-ing it
                    //
                    var range = BoardIndeces[mv.Destination].Rank - BoardIndeces[moving.CurrentSquare].Rank;
                    if (Math.Abs(range) > 1)
                    {
                        _enPassantSquare = moving.CurrentSquare + ((-range / 2) * 8);
                    }
                    else
                    {
                        _enPassantSquare = SQ.xx;
                    }
                }
                else
                {
                    _enPassantSquare = SQ.xx;
                }
                //
                // update board state related to rook moves
                //
                if (mv.Piece is Rook)
                {
                    switch (mv.Piece.CurrentSquare)
                    {
                        case SQ.a1:
                            _castlingStatus = _castlingStatus.Where(c => c != 'Q').ToArray();
                            break;

                        case SQ.h1:
                            _castlingStatus = _castlingStatus.Where(c => c != 'K').ToArray();
                            break;

                        case SQ.a8:
                            _castlingStatus = _castlingStatus.Where(c => c != 'q').ToArray();
                            break;

                        case SQ.h8:
                            _castlingStatus = _castlingStatus.Where(c => c != 'k').ToArray();
                            break;
                    }
                }
                //
                // update board state related to king moves
                //
                if (mv.Piece is King)
                {
                    switch (mv.Piece.CurrentSquare)
                    {
                        case SQ.e1:
                            _castlingStatus = _castlingStatus.Where(c => !Char.IsUpper(c)).ToArray();
                            break;

                        case SQ.e8:
                            _castlingStatus = _castlingStatus.Where(c => !Char.IsLower(c)).ToArray();
                            break;
                    }
                }
                //
                // perform move
                //
                _b[(int)moving.CurrentSquare] = new Empty(Constants.EmptyIdentifier, moving.CurrentSquare); ;
                if (mv.IsPromotion)
                {
                    _b[(int)mv.Destination] = mv.PromotionPiece;
                }
                else
                {
                    _b[(int)mv.Destination] = moving;
                    moving.CurrentSquare = mv.Destination;
                }
                //
                // update board state related all pieces
                //
                if (mv.IsCapture || mv.IsPawnAdvance) _halfMoveClock = 0;
            }
            //
            // update board state for completed move
            //
            if (_onMove == Side.Black) _fullMoveNumber++;
            _onMove = _onMove == Side.White ? Side.Black : Side.White;

        }

        public string ParseMove(string move)
        {
            if (move.EndsWith("+") || move.EndsWith("#"))
            {
                move = move.Substring(0, move.Length - 1);
            }
            return move;
        }

        public string ToFen()
        {
            var sb = new StringBuilder();
            var emptyCount = 0;
            for (int i = 0; i < 64; ++i)
            {
                if (i != 0 && i % 8 == 0)
                {
                    if (emptyCount > 0)
                    {
                        sb.Append(emptyCount);
                        emptyCount = 0;
                    }
                    sb.Append("/");
                }

                if (_b[i].Identifier == Constants.EmptyIdentifier)
                {
                    ++emptyCount;
                }
                else
                {
                    if (emptyCount > 0)
                    {
                        sb.Append(emptyCount);
                        emptyCount = 0;
                    }
                    sb.Append(_b[i].Identifier);
                }
            }
            if (emptyCount > 0)
                sb.Append(emptyCount);

            sb
            .Append(" ").Append((_onMove == Side.White ? "w" : "b"))
            .Append(" ").Append(CastlingStatus)
            .Append(" ").Append(_enPassantSquare == SQ.xx ? "-" : _enPassantSquare.ToString())
            .Append(" ").Append(_halfMoveClock)
            .Append(" ").Append(_fullMoveNumber);

            return sb.ToString();
        }

        public string GameKey
        {
            get
            {
                return Hashing.CombineHashCodes(
                    WhitePlayer.GetHashCode(),
                    BlackPlayer.GetHashCode(),
                    Date.GetHashCode(),
                    MoveList.GetHashCode()).ToString();
            }
        }

        public override int GetHashCode()
        {
            return Hashing.CombineHashCodes(
                    WhitePlayer.GetHashCode(),
                    BlackPlayer.GetHashCode(),
                    Date.GetHashCode(),
                    MoveList.GetHashCode());
        }

        public override string ToString()
        {
            var sb = new StringBuilder()
            .AppendLine()
            .AppendLine($"White  : {WhitePlayer}")
            .AppendLine($"Black  : {BlackPlayer}")
            .AppendLine($"Date   : {Date}")
            .AppendLine($"Result : {Result}")
            .AppendLine($"Key    : {GameKey}")
            .AppendLine($"+---+---+---+---+---+---+---+---+")
            .AppendLine($"| {_b[(int)SQ.a8].Identifier} | {_b[(int)SQ.b8].Identifier} | {_b[(int)SQ.c8].Identifier} | {_b[(int)SQ.d8].Identifier} | {_b[(int)SQ.e8].Identifier} | {_b[(int)SQ.f8].Identifier} | {_b[(int)SQ.g8].Identifier} | {_b[(int)SQ.h8].Identifier} |")
            .AppendLine($"+---+---+---+---+---+---+---+---+")
            .AppendLine($"| {_b[(int)SQ.a7].Identifier} | {_b[(int)SQ.b7].Identifier} | {_b[(int)SQ.c7].Identifier} | {_b[(int)SQ.d7].Identifier} | {_b[(int)SQ.e7].Identifier} | {_b[(int)SQ.f7].Identifier} | {_b[(int)SQ.g7].Identifier} | {_b[(int)SQ.h7].Identifier} |")
            .AppendLine($"+---+---+---+---+---+---+---+---+")
            .AppendLine($"| {_b[(int)SQ.a6].Identifier} | {_b[(int)SQ.b6].Identifier} | {_b[(int)SQ.c6].Identifier} | {_b[(int)SQ.d6].Identifier} | {_b[(int)SQ.e6].Identifier} | {_b[(int)SQ.f6].Identifier} | {_b[(int)SQ.g6].Identifier} | {_b[(int)SQ.h6].Identifier} |")
            .AppendLine($"+---+---+---+---+---+---+---+---+")
            .AppendLine($"| {_b[(int)SQ.a5].Identifier} | {_b[(int)SQ.b5].Identifier} | {_b[(int)SQ.c5].Identifier} | {_b[(int)SQ.d5].Identifier} | {_b[(int)SQ.e5].Identifier} | {_b[(int)SQ.f5].Identifier} | {_b[(int)SQ.g5].Identifier} | {_b[(int)SQ.h5].Identifier} |")
            .AppendLine($"+---+---+---+---+---+---+---+---+")
            .AppendLine($"| {_b[(int)SQ.a4].Identifier} | {_b[(int)SQ.b4].Identifier} | {_b[(int)SQ.c4].Identifier} | {_b[(int)SQ.d4].Identifier} | {_b[(int)SQ.e4].Identifier} | {_b[(int)SQ.f4].Identifier} | {_b[(int)SQ.g4].Identifier} | {_b[(int)SQ.h4].Identifier} |")
            .AppendLine($"+---+---+---+---+---+---+---+---+")
            .AppendLine($"| {_b[(int)SQ.a3].Identifier} | {_b[(int)SQ.b3].Identifier} | {_b[(int)SQ.c3].Identifier} | {_b[(int)SQ.d3].Identifier} | {_b[(int)SQ.e3].Identifier} | {_b[(int)SQ.f3].Identifier} | {_b[(int)SQ.g3].Identifier} | {_b[(int)SQ.h3].Identifier} |")
            .AppendLine($"+---+---+---+---+---+---+---+---+")
            .AppendLine($"| {_b[(int)SQ.a2].Identifier} | {_b[(int)SQ.b2].Identifier} | {_b[(int)SQ.c2].Identifier} | {_b[(int)SQ.d2].Identifier} | {_b[(int)SQ.e2].Identifier} | {_b[(int)SQ.f2].Identifier} | {_b[(int)SQ.g2].Identifier} | {_b[(int)SQ.h2].Identifier} |")
            .AppendLine($"+---+---+---+---+---+---+---+---+")
            .AppendLine($"| {_b[(int)SQ.a1].Identifier} | {_b[(int)SQ.b1].Identifier} | {_b[(int)SQ.c1].Identifier} | {_b[(int)SQ.d1].Identifier} | {_b[(int)SQ.e1].Identifier} | {_b[(int)SQ.f1].Identifier} | {_b[(int)SQ.g1].Identifier} | {_b[(int)SQ.h1].Identifier} |")
            .AppendLine($"+---+---+---+---+---+---+---+---+");

            sb.AppendLine();
            sb.AppendLine(ToFen());
            sb.AppendLine();
            sb.AppendLine(MoveList);

            return sb.ToString();
        }

        public string ToDebugString()
        {
            var sb = new StringBuilder()
            .AppendLine()
            .AppendLine($"+---+---+---+---+---+---+---+---+")
            .AppendLine($"| {_b[(int)SQ.a8].Identifier} | {_b[(int)SQ.b8].Identifier} | {_b[(int)SQ.c8].Identifier} | {_b[(int)SQ.d8].Identifier} | {_b[(int)SQ.e8].Identifier} | {_b[(int)SQ.f8].Identifier} | {_b[(int)SQ.g8].Identifier} | {_b[(int)SQ.h8].Identifier} |")
            .AppendLine($"+---+---+---+---+---+---+---+---+")
            .AppendLine($"| {_b[(int)SQ.a7].Identifier} | {_b[(int)SQ.b7].Identifier} | {_b[(int)SQ.c7].Identifier} | {_b[(int)SQ.d7].Identifier} | {_b[(int)SQ.e7].Identifier} | {_b[(int)SQ.f7].Identifier} | {_b[(int)SQ.g7].Identifier} | {_b[(int)SQ.h7].Identifier} |")
            .AppendLine($"+---+---+---+---+---+---+---+---+")
            .AppendLine($"| {_b[(int)SQ.a6].Identifier} | {_b[(int)SQ.b6].Identifier} | {_b[(int)SQ.c6].Identifier} | {_b[(int)SQ.d6].Identifier} | {_b[(int)SQ.e6].Identifier} | {_b[(int)SQ.f6].Identifier} | {_b[(int)SQ.g6].Identifier} | {_b[(int)SQ.h6].Identifier} |")
            .AppendLine($"+---+---+---+---+---+---+---+---+")
            .AppendLine($"| {_b[(int)SQ.a5].Identifier} | {_b[(int)SQ.b5].Identifier} | {_b[(int)SQ.c5].Identifier} | {_b[(int)SQ.d5].Identifier} | {_b[(int)SQ.e5].Identifier} | {_b[(int)SQ.f5].Identifier} | {_b[(int)SQ.g5].Identifier} | {_b[(int)SQ.h5].Identifier} |")
            .AppendLine($"+---+---+---+---+---+---+---+---+")
            .AppendLine($"| {_b[(int)SQ.a4].Identifier} | {_b[(int)SQ.b4].Identifier} | {_b[(int)SQ.c4].Identifier} | {_b[(int)SQ.d4].Identifier} | {_b[(int)SQ.e4].Identifier} | {_b[(int)SQ.f4].Identifier} | {_b[(int)SQ.g4].Identifier} | {_b[(int)SQ.h4].Identifier} |")
            .AppendLine($"+---+---+---+---+---+---+---+---+")
            .AppendLine($"| {_b[(int)SQ.a3].Identifier} | {_b[(int)SQ.b3].Identifier} | {_b[(int)SQ.c3].Identifier} | {_b[(int)SQ.d3].Identifier} | {_b[(int)SQ.e3].Identifier} | {_b[(int)SQ.f3].Identifier} | {_b[(int)SQ.g3].Identifier} | {_b[(int)SQ.h3].Identifier} |")
            .AppendLine($"+---+---+---+---+---+---+---+---+")
            .AppendLine($"| {_b[(int)SQ.a2].Identifier} | {_b[(int)SQ.b2].Identifier} | {_b[(int)SQ.c2].Identifier} | {_b[(int)SQ.d2].Identifier} | {_b[(int)SQ.e2].Identifier} | {_b[(int)SQ.f2].Identifier} | {_b[(int)SQ.g2].Identifier} | {_b[(int)SQ.h2].Identifier} |")
            .AppendLine($"+---+---+---+---+---+---+---+---+")
            .AppendLine($"| {_b[(int)SQ.a1].Identifier} | {_b[(int)SQ.b1].Identifier} | {_b[(int)SQ.c1].Identifier} | {_b[(int)SQ.d1].Identifier} | {_b[(int)SQ.e1].Identifier} | {_b[(int)SQ.f1].Identifier} | {_b[(int)SQ.g1].Identifier} | {_b[(int)SQ.h1].Identifier} |")
            .AppendLine($"+---+---+---+---+---+---+---+---+");

            return sb.ToString();
        }
    }
}
