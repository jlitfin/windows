using System;
using System.Collections.Generic;
using System.Linq;

namespace Board
{
    public abstract class Piece
    {
        public static Dictionary<string, int> Ranks;
        public static Dictionary<string, int> Files;
        public Piece(string identifier, SQ currentSquare)
        {
            Identifier = identifier;
            CurrentSquare = currentSquare;

            if (!Char.IsWhiteSpace(identifier[0]))
            {
                Side = char.IsUpper(identifier[0]) ? Side.White : Side.Black;
            }
        }
        public string Key
        {
            get
            {
                return $"{Side.ToString()}{Identifier}";
            }
        }
        public Side Side { get; set; }
        public string Identifier { get; set; }
        public SQ CurrentSquare { get; set; }
        public char CurrentFile
        {
            get
            {
                return CurrentSquare.ToString().First();
            }
        }
        public int CurrentRank
        {
            get
            {
                return int.Parse(CurrentSquare.ToString().Last().ToString());
            }
        }

        public abstract List<Move> GenMoves(GameState board);
    }

    public class PieceFactory
    {
        public static Piece Create(Piece piece)
        {
            return Create(piece.Identifier, piece.CurrentSquare);
        }
        public static Piece Create(string identifier, SQ sq)
        {
            switch (identifier)
            {
                case "p":
                case "P":
                    return new Pawn(identifier, sq);
                case "k":
                case "K":
                    return new King(identifier, sq);
                case "q":
                case "Q":
                    return new Queen(identifier, sq);
                case "r":
                case "R":
                    return new Rook(identifier, sq);
                case "b":
                case "B":
                    return new Bishop(identifier, sq);
                case "n":
                case "N":
                    return new Knight(identifier, sq);
            }

            return new Empty(Constants.EmptyIdentifier, sq);
        }
    }
}
