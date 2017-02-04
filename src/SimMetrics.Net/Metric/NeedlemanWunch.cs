using System;
using SimMetrics.Net.API;
using SimMetrics.Net.Utilities;

namespace SimMetrics.Net.Metric
{
    public sealed class NeedlemanWunch : AbstractStringMetric
    {
        private const double DefaultGapCost = 2.0;
        private const double DefaultMismatchScore = 0.0;
        private const double DefaultPerfectMatchScore = 1.0;
        private readonly double _estimatedTimingConstant;

        public NeedlemanWunch() : this(DefaultGapCost, new SubCostRange0To1())
        {
        }

        public NeedlemanWunch(AbstractSubstitutionCost costFunction) : this(DefaultGapCost, costFunction)
        {
        }

        public NeedlemanWunch(double costG) : this(costG, new SubCostRange0To1())
        {
        }

        public NeedlemanWunch(double costG, AbstractSubstitutionCost costFunction)
        {
            _estimatedTimingConstant = 0.00018420000560581684;
            GapCost = costG;
            DCostFunction = costFunction;
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            if (firstWord == null || secondWord == null)
            {
                return DefaultMismatchScore;
            }
            double unnormalisedSimilarity = GetUnnormalisedSimilarity(firstWord, secondWord);
            double num2 = Math.Max(firstWord.Length, secondWord.Length);
            double num3 = num2;
            if (DCostFunction.MaxCost > GapCost)
            {
                num2 *= DCostFunction.MaxCost;
            }
            else
            {
                num2 *= GapCost;
            }
            if (DCostFunction.MinCost < GapCost)
            {
                num3 *= DCostFunction.MinCost;
            }
            else
            {
                num3 *= GapCost;
            }

            if (num3 < 0.0)
            {
                num2 -= num3;
                unnormalisedSimilarity -= num3;
            }

            if (num2 == 0.0)
            {
                return DefaultPerfectMatchScore;
            }

            return DefaultPerfectMatchScore - unnormalisedSimilarity / num2;
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
                    double num8 = DCostFunction.GetCost(firstWord, m - 1, secondWord, n - 1);
                    numArray[m][n] = MathFunctions.MinOf3(numArray[m - 1][n] + GapCost, numArray[m][n - 1] + GapCost, numArray[m - 1][n - 1] + num8);
                }
            }

            return numArray[length][index];
        }

        public AbstractSubstitutionCost DCostFunction { get; set; }

        public double GapCost { get; set; }

        public override string LongDescriptionString => "Implements the Needleman-Wunch algorithm providing an edit distance based similarity measure between two strings";

        public override string ShortDescriptionString => "NeedlemanWunch";
    }
}