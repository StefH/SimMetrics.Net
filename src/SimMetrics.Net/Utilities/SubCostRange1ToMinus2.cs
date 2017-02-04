using SimMetrics.Net.API;

namespace SimMetrics.Net.Utilities
{
    public sealed class SubCostRange1ToMinus2 : AbstractSubstitutionCost
    {
        private const int CharExactMatchScore = 1;
        private const double CharMismatchMatchScore = -2.0;

        public override double GetCost(string firstWord, int firstWordIndex, string secondWord, int secondWordIndex)
        {
            if (firstWord == null || secondWord == null)
            {
                return CharMismatchMatchScore;
            }

            if (firstWord.Length <= firstWordIndex || firstWordIndex < 0)
            {
                return CharMismatchMatchScore;
            }

            if (secondWord.Length <= secondWordIndex || secondWordIndex < 0)
            {
                return CharMismatchMatchScore;
            }

            return firstWord[firstWordIndex] != secondWord[secondWordIndex] ? CharMismatchMatchScore : CharExactMatchScore;
        }

        public override double MaxCost => CharExactMatchScore;

        public override double MinCost => CharMismatchMatchScore;

        public override string ShortDescriptionString => "SubCostRange1ToMinus2";
    }
}

