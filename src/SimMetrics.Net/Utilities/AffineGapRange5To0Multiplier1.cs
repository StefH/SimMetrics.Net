using SimMetrics.Net.API;

namespace SimMetrics.Net.Utilities
{
    public sealed class AffineGapRange5To0Multiplier1 : AbstractAffineGapCost
    {
        private const double CharExactMatchScore = 5.0;
        private const double CharMismatchMatchScore = 0.0;

        public override double GetCost(string textToGap, int stringIndexStartGap, int stringIndexEndGap)
        {
            if (stringIndexStartGap >= stringIndexEndGap)
            {
                return CharMismatchMatchScore;
            }
            return CharExactMatchScore + (stringIndexEndGap - 1 - stringIndexStartGap);
        }

        public override double MaxCost => CharExactMatchScore;

        public override double MinCost => CharMismatchMatchScore;

        public override string ShortDescriptionString => "AffineGapRange5To0Multiplier1";
    }
}

