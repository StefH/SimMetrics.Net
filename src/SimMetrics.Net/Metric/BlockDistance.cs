using System;
using System.Collections.ObjectModel;
using SimMetrics.Net.API;
using SimMetrics.Net.Utilities;

namespace SimMetrics.Net.Metric
{
    public sealed class BlockDistance : AbstractStringMetric
    {
        private readonly double _estimatedTimingConstant;
        private readonly ITokeniser _tokeniser;
        private readonly TokeniserUtilities<string> _tokenUtilities;

        public BlockDistance() : this(new TokeniserWhitespace())
        {
        }

        public BlockDistance(ITokeniser tokeniserToUse)
        {
            _estimatedTimingConstant = 6.4457140979357064E-05;
            _tokeniser = tokeniserToUse;
            _tokenUtilities = new TokeniserUtilities<string>();
        }

        private double GetActualSimilarity(Collection<string> firstTokens, Collection<string> secondTokens)
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
                if (num2 > num3)
                {
                    num += num2 - num3;
                }
                else
                {
                    num += num3 - num2;
                }
            }
            return num;
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            Collection<string> firstTokens = _tokeniser.Tokenize(firstWord);
            Collection<string> secondTokens = _tokeniser.Tokenize(secondWord);
            int num = firstTokens.Count + secondTokens.Count;
            double actualSimilarity = GetActualSimilarity(firstTokens, secondTokens);
            return (num - actualSimilarity) / num;
        }

        public override string GetSimilarityExplained(string firstWord, string secondWord)
        {
            throw new NotImplementedException();
        }

        public override double GetSimilarityTimingEstimated(string firstWord, string secondWord)
        {
            double count = _tokeniser.Tokenize(firstWord).Count;
            double num2 = _tokeniser.Tokenize(secondWord).Count;
            return ((count + num2) * count + (count + num2) * num2) * _estimatedTimingConstant;
        }

        public override double GetUnnormalisedSimilarity(string firstWord, string secondWord)
        {
            Collection<string> firstTokens = _tokeniser.Tokenize(firstWord);
            Collection<string> secondTokens = _tokeniser.Tokenize(secondWord);
            return GetActualSimilarity(firstTokens, secondTokens);
        }

        public override string LongDescriptionString => "Implements the Block distance algorithm whereby vector space block distance is used to determine a similarity";

        public override string ShortDescriptionString => "BlockDistance";
    }
}