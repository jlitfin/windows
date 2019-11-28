using System;
using System.Linq;

namespace Core
{
    public class Evaluation
    {
        private readonly int _threshold;

        public Evaluation(int threshold)
        {
            _threshold = threshold;
        }
        public Evaluation()
        {
            _threshold = 100;
        }

        public Side EvaluatingSide { get; set; }
        public int MoveNumber { get; set; }
        public string Fen { get; set; }
        public string EngineMove { get; set; }
        public int EngineScore { get; set; }
        public int EngineMateIn { get; set; }
        public SearchResult EngineResult { get; set; }
        public string EngineVariation
        {
            get
            {
                return EngineResult.Variations.First().Line;
            }
        }
        public string EvaluationMove { get; set; }
        public int EvaluationScore { get; set; }
        public int EvaluationMateIn { get; set; }
        public SearchResult EvaluationResult { get; set; }
        public string EvaluationVariation
        {
            get
            {
                return EvaluationResult.Variations.First().Line;
            }
        }
        public double Duration { get; set; }
        public int Depth { get; set; }
        public bool CheckMove
        {
            get
            {
                return
                    (EngineScore - EvaluationScore > _threshold) ||
                    (EngineMateIn != 0 && EvaluationMateIn == 0) ||
                    (EngineMateIn < EvaluationMateIn);
            }
        }

        public override string ToString()
        {
            var engineScore = EngineMateIn != 0 ? $"mate {EngineMateIn}" : $"{EngineScore}";
            var evalScore = EvaluationMateIn != 0 ? $"mate {EvaluationMateIn}" : $"{EvaluationScore}";
            return $"{MoveNumber.ToString().PadLeft(3, ' ')}. {EngineMove.PadLeft(5, ' ')} -> {engineScore.PadLeft(8, ' ')}  {EvaluationMove.PadLeft(5, ' ')} -> {evalScore.PadLeft(8, ' ')}  | {Duration:N2} seconds";
        }
    }
}
