using System.Collections.ObjectModel;
using SimMetrics.Net.API;

namespace SimMetrics.Net.Utilities
{
    public sealed class SubCostRange5ToMinus3 : AbstractSubstitutionCost
    {
        private readonly Collection<string>[] _approx = new Collection<string>[7];
        private const double CharApproximateMatchScore = 3.0;
        private const double CharExactMatchScore = 5.0;
        private const double CharMismatchMatchScore = -3.0;

        public SubCostRange5ToMinus3()
        {
            _approx[0] = new Collection<string>();
            _approx[0].Add("d");
            _approx[0].Add("t");
            _approx[1] = new Collection<string>();
            _approx[1].Add("g");
            _approx[1].Add("j");
            _approx[2] = new Collection<string>();
            _approx[2].Add("l");
            _approx[2].Add("r");
            _approx[3] = new Collection<string>();
            _approx[3].Add("m");
            _approx[3].Add("n");
            _approx[4] = new Collection<string>();
            _approx[4].Add("b");
            _approx[4].Add("p");
            _approx[4].Add("v");
            _approx[5] = new Collection<string>();
            _approx[5].Add("a");
            _approx[5].Add("e");
            _approx[5].Add("i");
            _approx[5].Add("o");
            _approx[5].Add("u");
            _approx[6] = new Collection<string>();
            _approx[6].Add(",");
            _approx[6].Add(".");
        }

        public override double GetCost(string firstWord, int firstWordIndex, string secondWord, int secondWordIndex)
        {
            if (firstWord != null && secondWord != null)
            {
                if (firstWord.Length <= firstWordIndex || firstWordIndex < 0)
                {
                    return CharMismatchMatchScore;
                }

                if (secondWord.Length <= secondWordIndex || secondWordIndex < 0)
                {
                    return CharMismatchMatchScore;
                }

                if (firstWord[firstWordIndex] == secondWord[secondWordIndex])
                {
                    return CharExactMatchScore;
                }

                char ch = firstWord[firstWordIndex];
                string item = ch.ToString().ToLowerInvariant();
                char ch2 = secondWord[secondWordIndex];
                string str2 = ch2.ToString().ToLowerInvariant();
                for (int i = 0; i < _approx.Length; i++)
                {
                    if (_approx[i].Contains(item) && _approx[i].Contains(str2))
                    {
                        return CharApproximateMatchScore;
                    }
                }
            }
            return CharMismatchMatchScore;
        }

        public override double MaxCost => CharExactMatchScore;

        public override double MinCost => CharMismatchMatchScore;

        public override string ShortDescriptionString => "SubCostRange5ToMinus3";
    }
}