using System;
using SimMetrics.Net.API;
using SimMetrics.Net.Utilities;

namespace SimMetrics.Net.Metric
{
    public sealed class SmithWaterman : AbstractStringMetric
    {
        private const double DefaultGapCost = 0.5;
        private const double DefaultMismatchScore = 0.0;
        private const double DefaultPerfectMatchScore = 1.0;
        private const double EstimatedTimingConstant = 0.0001610000035725534;

        public SmithWaterman() : this(DefaultGapCost, new SubCostRange1ToMinus2())
        {
        }

        public SmithWaterman(AbstractSubstitutionCost costFunction) : this(DefaultGapCost, costFunction)
        {
        }

        public SmithWaterman(double costG) : this(costG, new SubCostRange1ToMinus2())
        {
        }

        public SmithWaterman(double costG, AbstractSubstitutionCost costFunction)
        {
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
            double num2 = Math.Min(firstWord.Length, secondWord.Length);

            if (DCostFunction.MaxCost > -GapCost)
            {
                num2 *= DCostFunction.MaxCost;
            }
            else
            {
                num2 *= -GapCost;
            }

            if (num2 == 0.0)
            {
                return DefaultPerfectMatchScore;
            }

            return unnormalisedSimilarity / num2;
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
                return (length * num2 + length + num2) * EstimatedTimingConstant;
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
            int num2 = secondWord.Length;
            if (length == 0)
            {
                return num2;
            }
            if (num2 == 0)
            {
                return length;
            }
            double[][] numArray = new double[length][];
            for (int i = 0; i < length; i++)
            {
                numArray[i] = new double[num2];
            }
            double num4 = 0.0;
            for (int j = 0; j < length; j++)
            {
                double thirdNumber = DCostFunction.GetCost(firstWord, j, secondWord, 0);
                if (j == 0)
                {
                    numArray[0][0] = MathFunctions.MaxOf3(0.0, -GapCost, thirdNumber);
                }
                else
                {
                    numArray[j][0] = MathFunctions.MaxOf3(0.0, numArray[j - 1][0] - GapCost, thirdNumber);
                }
                if (numArray[j][0] > num4)
                {
                    num4 = numArray[j][0];
                }
            }

            for (int k = 0; k < num2; k++)
            {
                double num8 = DCostFunction.GetCost(firstWord, 0, secondWord, k);
                if (k == 0)
                {
                    numArray[0][0] = MathFunctions.MaxOf3(0.0, -GapCost, num8);
                }
                else
                {
                    numArray[0][k] = MathFunctions.MaxOf3(0.0, numArray[0][k - 1] - GapCost, num8);
                }
                if (numArray[0][k] > num4)
                {
                    num4 = numArray[0][k];
                }
            }

            for (int m = 1; m < length; m++)
            {
                for (int n = 1; n < num2; n++)
                {
                    double num11 = DCostFunction.GetCost(firstWord, m, secondWord, n);
                    numArray[m][n] = MathFunctions.MaxOf4(0.0, numArray[m - 1][n] - GapCost, numArray[m][n - 1] - GapCost, numArray[m - 1][n - 1] + num11);
                    if (numArray[m][n] > num4)
                    {
                        num4 = numArray[m][n];
                    }
                }
            }
            return num4;
        }

        public AbstractSubstitutionCost DCostFunction { get; set; }

        public double GapCost { get; set; }

        public override string LongDescriptionString => "Implements the Smith-Waterman algorithm providing a similarity measure between two string";

        public override string ShortDescriptionString => "SmithWaterman";
    }
}