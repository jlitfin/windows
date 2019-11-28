using System;
using System.Collections.Generic;

using Core;

namespace Board
{
    public class Pawn : Piece
    {
        public Pawn(string identifier, SQ currentSquare) : base(identifier, currentSquare) { }

        public override List<Ply> GenMoves(GameState board)
        {
            var moves = new List<Ply>();
            var increment = Side == Side.White ? 1 : -1;
            var homeRank = Side == Side.White ? 2 : 7;
            var promoteRank = Side == Side.White ? 8 : 1;

            // push
            var bi = board.BoardIndeces[CurrentSquare].Get();
            bi.Add(new Vector(0, increment));

            if (bi.Square != SQ.xx && board[bi.Square].Side == Side.Empty)
            {
                if (board.BoardIndeces[bi.Square].Rank == promoteRank)
                {
                    moves.Add(new Ply
                    {
                        Piece = this,
                        Origin = CurrentSquare,
                        Destination = bi.Square,
                        IsPromotion = true,
                        PromotionPiece = new Queen(Side == Side.White ? "Q" : "q", bi.Square)
                    });
                    moves.Add(new Ply
                    {
                        Piece = this,
                        Origin = CurrentSquare,
                        Destination = bi.Square,
                        IsPromotion = true,
                        PromotionPiece = new Rook(Side == Side.White ? "R" : "r", bi.Square)
                    });
                    moves.Add(new Ply
                    {
                        Piece = this,
                        Origin = CurrentSquare,
                        Destination = bi.Square,
                        IsPromotion = true,
                        PromotionPiece = new Bishop(Side == Side.White ? "B" : "b", bi.Square)
                    });
                    moves.Add(new Ply
                    {
                        Piece = this,
                        Origin = CurrentSquare,
                        Destination = bi.Square,
                        IsPromotion = true,
                        PromotionPiece = new Knight(Side == Side.White ? "N" : "n", bi.Square)
                    });
                }
                else
                {
                    moves.Add(new Ply
                    {
                        Piece = this,
                        Origin = CurrentSquare,
                        Destination = bi.Square
                    });
                }
            }
            // first move
            if (board.BoardIndeces[CurrentSquare].Rank == homeRank)
            {
                var v = new Vector(0, increment);
                bi = board.BoardIndeces[CurrentSquare].Get();
                if (board[bi.Add(v).Square].Side == Side.Empty)
                {
                    if (bi.Add(v).Square != SQ.xx && board[bi.Square].Side == Side.Empty)
                    {
                        moves.Add(new Ply
                        {
                            Piece = this,
                            Origin = CurrentSquare,
                            Destination = bi.Square
                        });
                    }
                }
            }
            // captures?
            var vectors = new List<Vector> { new Vector(1, increment), new Vector(-1, increment) };
            foreach (var v in vectors)
            {
                bi = board.BoardIndeces[CurrentSquare].Get();
                if (bi.Add(v).Square != SQ.xx && (board[bi.Square].Side != Side.Empty || bi.Square == board.EnPassantSquare) && board[bi.Square].Side != Side)
                {
                    if (board.BoardIndeces[bi.Square].Rank == promoteRank)
                    {
                        moves.Add(new Ply
                        {
                            Piece = this,
                            Origin = CurrentSquare,
                            Destination = bi.Square,
                            IsCapture = true,
                            IsPromotion = true,
                            PromotionPiece = new Queen(Side == Side.White ? "Q" : "q", bi.Square)
                        });
                        moves.Add(new Ply
                        {
                            Piece = this,
                            Origin = CurrentSquare,
                            Destination = bi.Square,
                            IsCapture = true,
                            IsPromotion = true,
                            PromotionPiece = new Rook(Side == Side.White ? "R" : "r", bi.Square)
                        });
                        moves.Add(new Ply
                        {
                            Piece = this,
                            Origin = CurrentSquare,
                            Destination = bi.Square,
                            IsCapture = true,
                            IsPromotion = true,
                            PromotionPiece = new Bishop(Side == Side.White ? "B" : "b", bi.Square)
                        });
                        moves.Add(new Ply
                        {
                            Piece = this,
                            Origin = CurrentSquare,
                            Destination = bi.Square,
                            IsCapture = true,
                            IsPromotion = true,
                            PromotionPiece = new Knight(Side == Side.White ? "N" : "n", bi.Square)
                        });
                    }
                    else
                    {
                        moves.Add(new Ply
                        {
                            Piece = this,
                            Origin = CurrentSquare,
                            Destination = bi.Square,
                            IsCapture = true
                        });
                    }
                }
            }

            foreach (var mv in moves)
            {
                mv.IsPawnAdvance = true;
            }

            return moves;
        }
    }
}
