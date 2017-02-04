using SimMetrics.Net.API;
using SimMetrics.Net.Utilities;

namespace SimMetrics.Net.Metric
{
    public sealed class SmithWatermanGotoh : SmithWatermanGotohWindowedAffine
    {
        private const int AffineGapWindowSize = 0x7fffffff;
        private const double EstimatedTimingConstant = 2.2000000171829015E-05;

        public SmithWatermanGotoh() : base(new AffineGapRange5To0Multiplier1(), new SubCostRange5ToMinus3(), AffineGapWindowSize)
        {
        }

        public SmithWatermanGotoh(AbstractAffineGapCost gapCostFunction) : base(gapCostFunction, new SubCostRange5ToMinus3(), AffineGapWindowSize)
        {
        }

        public SmithWatermanGotoh(AbstractSubstitutionCost costFunction) : base(new AffineGapRange5To0Multiplier1(), costFunction, AffineGapWindowSize)
        {
        }

        public SmithWatermanGotoh(AbstractAffineGapCost gapCostFunction, AbstractSubstitutionCost costFunction) : base(gapCostFunction, costFunction, AffineGapWindowSize)
        {
        }

        public override double GetSimilarityTimingEstimated(string firstWord, string secondWord)
        {
            if (firstWord != null && secondWord != null)
            {
                double length = firstWord.Length;
                double num2 = secondWord.Length;
                return (length * num2 * length + length * num2 * num2) * EstimatedTimingConstant;
            }
            return 0.0;
        }

        public override string LongDescriptionString => "Implements the Smith-Waterman-Gotoh algorithm providing a similarity measure between two string";

        public override string ShortDescriptionString => "SmithWatermanGotoh";
    }
}