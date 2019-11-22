﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Board
{
    public class Bishop : Piece
    {
        public Bishop(string identifier, SQ currentSquare) : base(identifier, currentSquare) { }
        public override List<Move> GenMoves(GameState board)
        {
            var moves = new List<Move>();
            var vectors = new List<Vector>
            {
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
                        moves.Add(new Move
                        {
                            Piece = this,
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
