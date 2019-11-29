using System;
using System.Collections.Generic;

using Core;

namespace Board
{
    public class King : Piece
    {
        public King(string identifier, SQ currentSquare) : base(identifier, currentSquare) { }

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

            #region castling
            // queen side
            if (Side == Side.White)
            {
                var status = board.CastlingStatus;
                if (board.CastlingStatus.Contains("Q"))
                {
                    moves.Add(new Ply
                    {
                        Piece = this,
                        Origin = CurrentSquare,
                        Destination = SQ.c1,
                        IsCastle = true,
                        IsPromotion = false,
                        IsCapture = false
                    });
                    moves.Add(new Ply
                    {
                        Piece = board[SQ.a1],
                        Origin = SQ.a1,
                        Destination = SQ.d1,
                        IsCastle = true,
                        IsPromotion = false,
                        IsCapture = false
                    });
                }

                if (board.CastlingStatus.Contains("K"))
                {
                    moves.Add(new Ply
                    {
                        Piece = this,
                        Origin = CurrentSquare,
                        Destination = SQ.g1,
                        IsCastle = true,
                        IsPromotion = false,
                        IsCapture = false
                    });
                    moves.Add(new Ply
                    {
                        Piece = board[SQ.h1],
                        Origin = SQ.h1,
                        Destination = SQ.f1,
                        IsCastle = true,
                        IsPromotion = false,
                        IsCapture = false
                    });
                }
            }
            else
            {
                if (board.CastlingStatus.Contains("q"))
                {
                    moves.Add(new Ply
                    {
                        Piece = this,
                        Origin = CurrentSquare,
                        Destination = SQ.c8,
                        IsCastle = true,
                        IsPromotion = false,
                        IsCapture = false
                    });
                    moves.Add(new Ply
                    {
                        Piece = board[SQ.a8],
                        Origin = SQ.a8,
                        Destination = SQ.d8,
                        IsCastle = true,
                        IsPromotion = false,
                        IsCapture = false
                    });
                }
                if (board.CastlingStatus.Contains("k"))
                {
                    moves.Add(new Ply
                    {
                        Piece = this,
                        Origin = CurrentSquare,
                        Destination = SQ.g8,
                        IsCastle = true,
                        IsPromotion = false,
                        IsCapture = false
                    });
                    moves.Add(new Ply
                    {
                        Piece = board[SQ.h8],
                        Origin = SQ.h8,
                        Destination = SQ.f8,
                        IsCastle = true,
                        IsPromotion = false,
                        IsCapture = false
                    });
                }
            }
            #endregion

            return moves;
        }
    }
}
