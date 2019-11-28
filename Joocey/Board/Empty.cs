using System;
using System.Collections.Generic;

using Core;

namespace Board
{
    public class Empty : Piece
    {
        public Empty(string identifier, SQ currentSquare) : base(Constants.EmptyIdentifier, currentSquare)
        {
            Side = Side.Empty;
        }

        public override List<Ply> GenMoves(GameState board)
        {
            return new List<Ply>();
        }
    }
}
