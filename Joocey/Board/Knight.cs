using System;
using System.Collections.Generic;
using System.Text;

namespace Board
{
    public class Knight : Piece
    {
        public Knight(string identifier, SQ currentSquare) : base(identifier, currentSquare) { }
        public override List<Move> GenMoves(GameState board)
        {
            var moves = new List<Move>();
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
                        moves.Add(new Move
                        {
                            Piece = this,
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
