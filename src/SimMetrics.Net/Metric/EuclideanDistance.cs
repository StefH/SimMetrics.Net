using System;
using System.Collections.ObjectModel;
using SimMetrics.Net.API;
using SimMetrics.Net.Utilities;

namespace SimMetrics.Net.Metric
{
    public sealed class EuclideanDistance : AbstractStringMetric
    {
        private const double DefaultMismatchScore = 0.0;
        private readonly double _estimatedTimingConstant;
        private readonly ITokeniser _tokeniser;
        private readonly TokeniserUtilities<string> _tokenUtilities;

        public EuclideanDistance() : this(new TokeniserWhitespace())
        {
        }

        public EuclideanDistance(ITokeniser tokeniserToUse)
        {
            _estimatedTimingConstant = 7.4457137088757008E-05;
            _tokeniser = tokeniserToUse;
            _tokenUtilities = new TokeniserUtilities<string>();
        }

        private double GetActualDistance(Collection<string> firstTokens, Collection<string> secondTokens)
        {
            Collection<string> collection = _tokenUtilities.CreateMergedList(firstTokens, secondTokens);
            int num = 0;
            foreach (string str in collection)
            {
                int num2 = 0;
                int num3 = 0;
                if (firstTokens.Contains(str))
                {
                    num2++;
                }
                if (secondTokens.Contains(str))
                {
                    num3++;
                }
                num += (num2 - num3) * (num2 - num3);
            }
            return Math.Sqrt(num);
        }

        public double GetEuclidDistance(string firstWord, string secondWord)
        {
            if (firstWord != null && secondWord != null)
            {
                Collection<string> firstTokens = _tokeniser.Tokenize(firstWord);
                Collection<string> secondTokens = _tokeniser.Tokenize(secondWord);
                return GetActualDistance(firstTokens, secondTokens);
            }
            return 0.0;
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            if (firstWord != null && secondWord != null)
            {
                double unnormalisedSimilarity = GetUnnormalisedSimilarity(firstWord, secondWord);
                double num2 = Math.Sqrt(_tokenUtilities.FirstTokenCount + _tokenUtilities.SecondTokenCount);
                return (num2 - unnormalisedSimilarity) / num2;
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
                double count = _tokeniser.Tokenize(firstWord).Count;
                double num2 = _tokeniser.Tokenize(secondWord).Count;
                return ((count + num2) * count + (count + num2) * num2) * _estimatedTimingConstant;
            }
            return DefaultMismatchScore;
        }

        public override double GetUnnormalisedSimilarity(string firstWord, string secondWord)
        {
            return GetEuclidDistance(firstWord, secondWord);
        }

        public override string LongDescriptionString => "Implements the Euclidean Distancey algorithm providing a similarity measure between two stringsusing the vector space of combined terms as the dimensions";

        public override string ShortDescriptionString => "EuclideanDistance";
    }
}