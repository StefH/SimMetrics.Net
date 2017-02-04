using System;
using SimMetrics.Net.API;
using SimMetrics.Net.Utilities;

namespace SimMetrics.Net.Metric
{
    public class SmithWatermanGotohWindowedAffine : AbstractStringMetric
    {
        private const double EstimatedTimingConstant = 4.5000000682193786E-05;
        private const double DefaultMismatchScore = 0.0;
        private const double DefaultPerfectScore = 1.0;
        private const int DefaultWindowSize = 100;
        private readonly int _windowSize;

        public SmithWatermanGotohWindowedAffine() : this(new AffineGapRange5To0Multiplier1(), new SubCostRange5ToMinus3(), DefaultWindowSize)
        {
        }

        public SmithWatermanGotohWindowedAffine(AbstractAffineGapCost gapCostFunction) : this(gapCostFunction, new SubCostRange5ToMinus3(), DefaultWindowSize)
        {
        }

        public SmithWatermanGotohWindowedAffine(AbstractSubstitutionCost costFunction) : this(new AffineGapRange5To0Multiplier1(), costFunction, DefaultWindowSize)
        {
        }

        public SmithWatermanGotohWindowedAffine(int affineGapWindowSize) : this(new AffineGapRange5To0Multiplier1(), new SubCostRange5ToMinus3(), affineGapWindowSize)
        {
        }

        public SmithWatermanGotohWindowedAffine(AbstractAffineGapCost gapCostFunction, int affineGapWindowSize) : this(gapCostFunction, new SubCostRange5ToMinus3(), affineGapWindowSize)
        {
        }

        public SmithWatermanGotohWindowedAffine(AbstractSubstitutionCost costFunction, int affineGapWindowSize) : this(new AffineGapRange5To0Multiplier1(), costFunction, affineGapWindowSize)
        {
        }

        public SmithWatermanGotohWindowedAffine(AbstractAffineGapCost gapCostFunction, AbstractSubstitutionCost costFunction, int affineGapWindowSize = DefaultWindowSize)
        {
            GGapFunction = gapCostFunction;
            DCostFunction = costFunction;
            _windowSize = affineGapWindowSize;
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            if (firstWord == null || secondWord == null)
            {
                return DefaultMismatchScore;
            }
            double unnormalisedSimilarity = GetUnnormalisedSimilarity(firstWord, secondWord);
            double num2 = Math.Min(firstWord.Length, secondWord.Length);

            if (DCostFunction.MaxCost > -GGapFunction.MaxCost)
            {
                num2 *= DCostFunction.MaxCost;
            }
            else
            {
                num2 *= -GGapFunction.MaxCost;
            }

            if (num2 == 0.0)
            {
                return DefaultPerfectScore;
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
                return (length * num2 * _windowSize + length * num2 * _windowSize) * EstimatedTimingConstant;
            }
            return DefaultMismatchScore;
        }

        public override double GetUnnormalisedSimilarity(string firstWord, string secondWord)
        {
            if (firstWord == null || secondWord == null)
            {
                return 0.0;
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
                double num6 = DCostFunction.GetCost(firstWord, j, secondWord, 0);
                if (j == 0)
                {
                    numArray[0][0] = Math.Max(0.0, num6);
                }
                else
                {
                    double num7 = 0.0;
                    int num8 = j - _windowSize;
                    if (num8 < 1)
                    {
                        num8 = 1;
                    }
                    for (int n = num8; n < j; n++)
                    {
                        num7 = Math.Max(num7, numArray[j - n][0] - GGapFunction.GetCost(firstWord, j - n, j));
                    }
                    numArray[j][0] = MathFunctions.MaxOf3(0.0, num7, num6);
                }
                if (numArray[j][0] > num4)
                {
                    num4 = numArray[j][0];
                }
            }
            for (int k = 0; k < num2; k++)
            {
                double num11 = DCostFunction.GetCost(firstWord, 0, secondWord, k);
                if (k == 0)
                {
                    numArray[0][0] = Math.Max(0.0, num11);
                }
                else
                {
                    double num12 = 0.0;
                    int num13 = k - _windowSize;
                    if (num13 < 1)
                    {
                        num13 = 1;
                    }
                    for (int num14 = num13; num14 < k; num14++)
                    {
                        num12 = Math.Max(num12, numArray[0][k - num14] - GGapFunction.GetCost(secondWord, k - num14, k));
                    }
                    numArray[0][k] = MathFunctions.MaxOf3(0.0, num12, num11);
                }
                if (numArray[0][k] > num4)
                {
                    num4 = numArray[0][k];
                }
            }
            for (int m = 1; m < length; m++)
            {
                for (int num16 = 1; num16 < num2; num16++)
                {
                    double num17 = DCostFunction.GetCost(firstWord, m, secondWord, num16);
                    double num18 = 0.0;
                    double num19 = 0.0;
                    int num20 = m - _windowSize;
                    if (num20 < 1)
                    {
                        num20 = 1;
                    }
                    for (int num21 = num20; num21 < m; num21++)
                    {
                        num18 = Math.Max(num18, numArray[m - num21][num16] - GGapFunction.GetCost(firstWord, m - num21, m));
                    }
                    num20 = num16 - _windowSize;
                    if (num20 < 1)
                    {
                        num20 = 1;
                    }
                    for (int num22 = num20; num22 < num16; num22++)
                    {
                        num19 = Math.Max(num19, numArray[m][num16 - num22] - GGapFunction.GetCost(secondWord, num16 - num22, num16));
                    }
                    numArray[m][num16] = MathFunctions.MaxOf4(0.0, num18, num19, numArray[m - 1][num16 - 1] + num17);
                    if (numArray[m][num16] > num4)
                    {
                        num4 = numArray[m][num16];
                    }
                }
            }
            return num4;
        }

        public AbstractSubstitutionCost DCostFunction { get; set; }

        public AbstractAffineGapCost GGapFunction { get; set; }

        public override string LongDescriptionString => "Implements the Smith-Waterman-Gotoh algorithm with a windowed affine gap providing a similarity measure between two string";

        public override string ShortDescriptionString => "SmithWatermanGotohWindowedAffine";
    }
}