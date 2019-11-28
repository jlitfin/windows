using System.Linq;
using System.Text;

using Core;

namespace Board
{
    public class Ply
    {
        public Piece Piece { get; set; }
        public SQ Origin { get; set; }
        public SQ Destination { get; set; }
        public bool IsCastle { get; set; }
        public bool IsCapture { get; set; }
        public bool IsPromotion { get; set; }
        public bool IsPawnAdvance { get; set; }
        public Piece PromotionPiece { get; set; }
        public bool IncludeOriginRank { get; set; }
        public bool IncludeOriginFile { get; set; }
        public string MovePgn
        {
            get
            {
                var piece = GameState.Pieces.Contains(Piece.Identifier) ? Piece.Identifier.ToUpper() : string.Empty;
                var sourceDetail = string.Empty;
                if (IncludeOriginFile)
                    sourceDetail = Origin.ToString().First().ToString();
                if (IncludeOriginRank)
                    sourceDetail = Origin.ToString().Last().ToString();
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
                        sb.Append(Origin.ToString().First());
                        sb.Append("x");
                    }
                    sb.Append(Destination).Append("=").Append(PromotionPiece.Identifier.ToUpper());
                }
                else if (IsCapture)
                {
                    if (string.IsNullOrEmpty(piece))
                    {
                        sb.Append(Origin.ToString().First());
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
        public string MoveUCI
        {
            get
            {
                return $"{Origin}{Destination}{(IsPromotion ? PromotionPiece.Identifier.ToLower() : string.Empty)}";
            }
        }

        public override string ToString()
        {
            return $"{Piece.Key} {Piece.CurrentSquare} {Origin} {Destination} {MovePgn} {MoveUCI} [{IncludeOriginFile}|{IncludeOriginRank}]";
        }
    }
}
