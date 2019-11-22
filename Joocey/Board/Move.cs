using System.Linq;
using System.Text;

namespace Board
{
    public class Move
    {
        public Piece Piece { get; set; }
        public SQ Destination { get; set; }
        public bool IsCastle { get; set; }
        public bool IsCapture { get; set; }
        public bool IsPromotion { get; set; }
        public bool IsPawnAdvance { get; set; }
        public Piece PromotionPiece { get; set; }
        public bool IncludeOriginRank { get; set; }
        public bool IncludeOriginFile { get; set; }
        public string MoveText
        {
            get
            {
                var piece = GameState.Pieces.Contains(Piece.Identifier) ? Piece.Identifier.ToUpper() : string.Empty;
                var sourceDetail = string.Empty;
                if (IncludeOriginFile)
                    sourceDetail = Piece.CurrentSquare.ToString().First().ToString();
                if (IncludeOriginRank)
                    sourceDetail = Piece.CurrentSquare.ToString().Last().ToString();
                piece = $"{piece}{sourceDetail}";

                var sb = new StringBuilder();
                if (IsCastle)
                {
                    if (Destination == SQ.g1 || Destination == SQ.f1 || Destination == SQ.g8 || Destination == SQ.f8)
                    {
                        sb.Append("O-O");
                    }
                    else
                    {
                        sb.Append("O-O-O");
                    }
                }
                else if (IsPromotion)
                {
                    // also check for capture with promote
                    if (IsCapture)
                    {
                        sb.Append(Piece.CurrentSquare.ToString().First());
                        sb.Append("x");
                    }
                    sb.Append(Destination).Append("=").Append(PromotionPiece.Identifier.ToUpper());
                }
                else if (IsCapture)
                {
                    if (string.IsNullOrEmpty(piece))
                    {
                        sb.Append(Piece.CurrentSquare.ToString().First());
                    }
                    else
                    {
                        sb.Append(piece);
                    }
                    sb.Append("x").Append(Destination);
                }
                else
                {
                    sb.Append(piece).Append(Destination);
                }
                return sb.ToString();
            }
        }
    }
}
