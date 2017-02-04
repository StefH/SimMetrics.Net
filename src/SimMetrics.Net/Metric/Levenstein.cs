using System;
using SimMetrics.Net.API;
using SimMetrics.Net.Utilities;

namespace SimMetrics.Net.Metric
{
    public sealed class Levenstein : AbstractStringMetric
    {
        private readonly AbstractSubstitutionCost _dCostFunction = new SubCostRange0To1();
        private const double DefaultMismatchScore = 0.0;
        private const double DefaultPerfectMatchScore = 1.0;
        private readonly double _estimatedTimingConstant = 0.00018000000272877514;

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            if (firstWord == null || secondWord == null)
            {
                return DefaultMismatchScore;
            }

            double unnormalisedSimilarity = GetUnnormalisedSimilarity(firstWord, secondWord);
            double length = firstWord.Length;
            if (length < secondWord.Length)
            {
                length = secondWord.Length;
            }

            if (length == 0.0)
            {
                return DefaultPerfectMatchScore;
            }

            return 1.0 - unnormalisedSimilarity / length;
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
            if (firstWord == null || secondWord == null)
            {
                return DefaultMismatchScore;
            }

            int length = firstWord.Length;
            int index = secondWord.Length;
            if (length == 0)
            {
                return index;
            }

            if (index == 0)
            {
                return length;
            }
            double[][] numArray = new double[length + 1][];
            for (int i = 0; i < length + 1; i++)
            {
                numArray[i] = new double[index + 1];
            }

            for (int j = 0; j <= length; j++)
            {
                numArray[j][0] = j;
            }

            for (int k = 0; k <= index; k++)
            {
                numArray[0][k] = k;
            }

            for (int m = 1; m <= length; m++)
            {
                for (int n = 1; n <= index; n++)
                {
                    double num8 = _dCostFunction.GetCost(firstWord, m - 1, secondWord, n - 1);
                    numArray[m][n] = MathFunctions.MinOf3(numArray[m - 1][n] + 1.0, numArray[m][n - 1] + 1.0, numArray[m - 1][n - 1] + num8);
                }
            }

            return numArray[length][index];
        }

        public override string LongDescriptionString => "Implements the basic Levenstein algorithm providing a similarity measure between two strings";

        public override string ShortDescriptionString => "Levenstein";
    }
}