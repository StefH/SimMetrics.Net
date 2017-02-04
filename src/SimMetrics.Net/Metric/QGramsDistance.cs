using System;
using System.Collections.ObjectModel;
using SimMetrics.Net.API;
using SimMetrics.Net.Utilities;

namespace SimMetrics.Net.Metric
{
    public sealed class QGramsDistance : AbstractStringMetric
    {
        private const double DefaultMismatchScore = 0.0;
        private readonly double _estimatedTimingConstant;
        private readonly ITokeniser _tokeniser;
        private readonly TokeniserUtilities<string> _tokenUtilities;

        public QGramsDistance() : this(new TokeniserQGram3Extended())
        {
        }

        public QGramsDistance(ITokeniser tokeniserToUse)
        {
            _estimatedTimingConstant = 0.0001340000017080456;
            _tokeniser = tokeniserToUse;
            _tokenUtilities = new TokeniserUtilities<string>();
        }

        private double GetActualSimilarity(Collection<string> firstTokens, Collection<string> secondTokens)
        {
            Collection<string> collection = _tokenUtilities.CreateMergedSet(firstTokens, secondTokens);
            int num = 0;
            foreach (string str in collection)
            {
                int num2 = 0;
                for (int i = 0; i < firstTokens.Count; i++)
                {
                    if (firstTokens[i].Equals(str))
                    {
                        num2++;
                    }
                }
                int num4 = 0;
                for (int j = 0; j < secondTokens.Count; j++)
                {
                    if (secondTokens[j].Equals(str))
                    {
                        num4++;
                    }
                }
                if (num2 > num4)
                {
                    num += num2 - num4;
                }
                else
                {
                    num += num4 - num2;
                }
            }
            return num;
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            if (firstWord != null && secondWord != null)
            {
                double unnormalisedSimilarity = GetUnnormalisedSimilarity(firstWord, secondWord);
                int num2 = _tokenUtilities.FirstTokenCount + _tokenUtilities.SecondTokenCount;
                if (num2 != 0)
                {
                    return (num2 - unnormalisedSimilarity) / num2;
                }
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
                return length * num2 * _estimatedTimingConstant;
            }
            return DefaultMismatchScore;
        }

        public override double GetUnnormalisedSimilarity(string firstWord, string secondWord)
        {
            Collection<string> firstTokens = _tokeniser.Tokenize(firstWord);
            Collection<string> secondTokens = _tokeniser.Tokenize(secondWord);
            _tokenUtilities.CreateMergedList(firstTokens, secondTokens);
            return GetActualSimilarity(firstTokens, secondTokens);
        }

        public override string LongDescriptionString => "Implements the Q Grams Distance algorithm providing a similarity measure between two strings using the qGram approach check matching qGrams/possible matching qGrams";

        public override string ShortDescriptionString => "QGramsDistance";
    }
}