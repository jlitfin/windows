using System;
using System.Collections.Generic;
using System.Text;

namespace Board
{
    public class Empty : Piece
    {
        public Empty(string identifier, SQ currentSquare) : base(Constants.EmptyIdentifier, currentSquare)
        {
            Side = Side.Empty;
        }

        public override List<Move> GenMoves(GameState board)
        {
            return new List<Move>();
        }
    }
}
