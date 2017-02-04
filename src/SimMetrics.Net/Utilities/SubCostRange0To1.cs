using SimMetrics.Net.API;

namespace SimMetrics.Net.Utilities
{
    public sealed class SubCostRange0To1 : AbstractSubstitutionCost
    {
        private const int CharExactMatchScore = 1;
        private const double CharMismatchMatchScore = 0.0;

        public override double GetCost(string firstWord, int firstWordIndex, string secondWord, int secondWordIndex)
        {
            if (firstWord != null && secondWord != null)
            {
                return firstWord[firstWordIndex] != secondWord[secondWordIndex] ? CharExactMatchScore : CharMismatchMatchScore;
            }

            return CharMismatchMatchScore;
        }

        public override double MaxCost => CharExactMatchScore;

        public override double MinCost => CharMismatchMatchScore;

        public override string ShortDescriptionString => "SubCostRange0To1";
    }
}