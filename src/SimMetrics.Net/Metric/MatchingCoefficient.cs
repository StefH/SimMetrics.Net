using System;
using System.Collections.ObjectModel;
using SimMetrics.Net.API;
using SimMetrics.Net.Utilities;

namespace SimMetrics.Net.Metric
{
    public sealed class MatchingCoefficient : AbstractStringMetric
    {
        private const double DefaultMismatchScore = 0.0;
        private readonly double _estimatedTimingConstant;
        private readonly ITokeniser _tokeniser;
        private readonly TokeniserUtilities<string> _tokenUtilities;

        public MatchingCoefficient() : this(new TokeniserWhitespace())
        {
        }

        public MatchingCoefficient(ITokeniser tokeniserToUse)
        {
            _estimatedTimingConstant = 0.00019999999494757503;
            _tokeniser = tokeniserToUse;
            _tokenUtilities = new TokeniserUtilities<string>();
        }

        private double GetActualSimilarity(Collection<string> firstTokens, Collection<string> secondTokens)
        {
            _tokenUtilities.CreateMergedList(firstTokens, secondTokens);
            int num = 0;
            foreach (string str in firstTokens)
            {
                if (secondTokens.Contains(str))
                {
                    num++;
                }
            }
            return num;
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            if (firstWord != null && secondWord != null)
            {
                double unnormalisedSimilarity = GetUnnormalisedSimilarity(firstWord, secondWord);
                int num2 = Math.Max(_tokenUtilities.FirstTokenCount, _tokenUtilities.SecondTokenCount);
                return unnormalisedSimilarity / num2;
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
                return num2 * count * _estimatedTimingConstant;
            }
            return DefaultMismatchScore;
        }

        public override double GetUnnormalisedSimilarity(string firstWord, string secondWord)
        {
            Collection<string> firstTokens = _tokeniser.Tokenize(firstWord);
            Collection<string> secondTokens = _tokeniser.Tokenize(secondWord);
            return GetActualSimilarity(firstTokens, secondTokens);
        }

        public override string LongDescriptionString => "Implements the Matching Coefficient algorithm providing a similarity measure between two strings";

        public override string ShortDescriptionString => "MatchingCoefficient";
    }
}