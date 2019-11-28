using System;
using System.Collections.Generic;

using Core;

namespace Board
{
    public class Knight : Piece
    {
        public Knight(string identifier, SQ currentSquare) : base(identifier, currentSquare) { }
        public override List<Ply> GenMoves(GameState board)
        {
            var moves = new List<Ply>();
            var list = new List<Vector>
        {
            new Vector( 1, 2),
            new Vector( 1,-2),
            new Vector(-1, 2),
            new Vector(-1,-2),
            new Vector( 2, 1),
            new Vector( 2,-1),
            new Vector(-2, 1),
            new Vector(-2,-1)
        };

            foreach (var v in list)
            {
                var bi = board.BoardIndeces[CurrentSquare].Get();
                if (bi.Add(v).Square != SQ.xx)
                {
                    var empty = board[bi.Square].Side == Side.Empty;
                    var capture = !empty && board[bi.Square].Side != Side;
                    if (empty || capture)
                    {
                        moves.Add(new Ply
                        {
                            Piece = this,
                            Origin = CurrentSquare,
                            Destination = bi.Square,
                            IsCapture = capture
                        });
                    }
                }
            }

            return moves;
        }
    }
}
