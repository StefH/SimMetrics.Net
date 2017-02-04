using System;
using SimMetrics.Net.API;
using SimMetrics.Net.Utilities;

namespace SimMetrics.Net.Metric
{
    public sealed class JaroWinkler : AbstractStringMetric
    {
        private const double DefaultMismatchScore = 0.0;
        private const double EstimatedTimingConstant = 4.3420001020422205E-05;
        private readonly AbstractStringMetric _jaroStringMetric = new Jaro();
        private const int MinPrefixTestLength = 4;
        private const double PrefixAdustmentScale = 0.10000000149011612;

        private static int GetPrefixLength(string firstWord, string secondWord)
        {
            if (firstWord == null || secondWord == null)
            {
                return MinPrefixTestLength;
            }

            int num = MathFunctions.MinOf3(MinPrefixTestLength, firstWord.Length, secondWord.Length);
            for (int i = 0; i < num; i++)
            {
                if (firstWord[i] != secondWord[i])
                {
                    return i;
                }
            }
            return num;
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            if (firstWord != null && secondWord != null)
            {
                double similarity = _jaroStringMetric.GetSimilarity(firstWord, secondWord);
                int prefixLength = GetPrefixLength(firstWord, secondWord);
                return similarity + prefixLength * PrefixAdustmentScale * (1.0 - similarity);
            }
            return DefaultMismatchScore;
        }

        public override string GetSimilarityExplained(string firstWord, string secondWord)
        {
            throw new NotImplementedException();
        }

        public override double GetSimilarityTimingEstimated(string firstWord, string secondWord)
        {
            if (firstWord != null && secondWord != null)
            {
                double length = firstWord.Length;
                double num2 = secondWord.Length;
                return length * num2 * EstimatedTimingConstant;
            }
            return DefaultMismatchScore;
        }

        public override double GetUnnormalisedSimilarity(string firstWord, string secondWord)
        {
            return GetSimilarity(firstWord, secondWord);
        }

        public override string LongDescriptionString => "Implements the Jaro-Winkler algorithm providing a similarity measure between two strings allowing character transpositions to a degree adjusting the weighting for common prefixes";

        public override string ShortDescriptionString => "JaroWinkler";
    }
}