using System;
using System.Collections.Generic;

using Core;

namespace Board
{
    public class Queen : Piece
    {
        public Queen(string identifier, SQ currentSquare) : base(identifier, currentSquare) { }

        public override List<Ply> GenMoves(GameState board)
        {
            var moves = new List<Ply>();
            var vectors = new List<Vector>
            {
                { new Vector( 1, 0) },
                { new Vector(-1, 0) },
                { new Vector( 0, 1) },
                { new Vector( 0,-1) },
                { new Vector( 1, 1) },
                { new Vector(-1, 1) },
                { new Vector(-1,-1) },
                { new Vector( 1,-1) }
            };
            foreach (var v in vectors)
            {
                var bi = board.BoardIndeces[CurrentSquare].Get();
                while (bi.Add(v).Square != SQ.xx)
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
                        if (capture) break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return moves;
        }
    }
}
