using System;
using System.Text;
using SimMetrics.Net.API;

namespace SimMetrics.Net.Metric
{
    public sealed class Jaro : AbstractStringMetric
    {
        private const double DefaultMismatchScore = 0.0;
        private readonly double _estimatedTimingConstant = 4.1200000850949436E-05;

        private static StringBuilder GetCommonCharacters(string firstWord, string secondWord, int distanceSep)
        {
            if (firstWord == null || secondWord == null)
            {
                return null;
            }
            StringBuilder builder = new StringBuilder();
            StringBuilder builder2 = new StringBuilder(secondWord);
            for (int i = 0; i < firstWord.Length; i++)
            {
                char ch = firstWord[i];
                bool flag = false;
                for (int j = Math.Max(0, i - distanceSep); !flag && j < Math.Min(i + distanceSep, secondWord.Length); j++)
                {
                    if (builder2[j] == ch)
                    {
                        flag = true;
                        builder.Append(ch);
                        builder2[j] = '#';
                    }
                }
            }
            return builder;
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            if (firstWord == null || secondWord == null)
            {
                return 0.0;
            }
            int distanceSep = Math.Min(firstWord.Length, secondWord.Length) / 2 + 1;
            StringBuilder builder = GetCommonCharacters(firstWord, secondWord, distanceSep);
            int length = builder.Length;
            if (length == 0)
            {
                return DefaultMismatchScore;
            }
            StringBuilder builder2 = GetCommonCharacters(secondWord, firstWord, distanceSep);
            if (length != builder2.Length)
            {
                return DefaultMismatchScore;
            }
            int num3 = 0;
            for (int i = 0; i < length; i++)
            {
                if (builder[i] != builder2[i])
                {
                    num3++;
                }
            }
            num3 /= 2;
            return length / (3.0 * firstWord.Length) + length / (3.0 * secondWord.Length) + (length - num3) / (3.0 * length);
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
                return length * num2 * _estimatedTimingConstant;
            }
            return DefaultMismatchScore;
        }

        public override double GetUnnormalisedSimilarity(string firstWord, string secondWord)
        {
            return GetSimilarity(firstWord, secondWord);
        }

        public override string LongDescriptionString => "Implements the Jaro algorithm providing a similarity measure between two strings allowing character transpositions to a degree";

        public override string ShortDescriptionString => "Jaro";
    }
}