using System;
using System.Collections.ObjectModel;
using SimMetrics.Net.API;
using SimMetrics.Net.Utilities;

namespace SimMetrics.Net.Metric
{
    public sealed class JaccardSimilarity : AbstractStringMetric
    {
        private const double DefaultMismatchScore = 0.0;
        private readonly double _estimatedTimingConstant;
        private readonly ITokeniser _tokeniser;
        private readonly TokeniserUtilities<string> _tokenUtilities;

        public JaccardSimilarity() : this(new TokeniserWhitespace())
        {
        }

        public JaccardSimilarity(ITokeniser tokeniserToUse)
        {
            _estimatedTimingConstant = 0.00014000000373926014;
            _tokeniser = tokeniserToUse;
            _tokenUtilities = new TokeniserUtilities<string>();
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            if (firstWord != null && secondWord != null)
            {
                Collection<string> collection = _tokenUtilities.CreateMergedSet(_tokeniser.Tokenize(firstWord), _tokeniser.Tokenize(secondWord));
                if (collection.Count > 0)
                {
                    return _tokenUtilities.CommonSetTerms() / (double) collection.Count;
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
                double count = _tokeniser.Tokenize(firstWord).Count;
                double num2 = _tokeniser.Tokenize(secondWord).Count;
                return count * num2 * _estimatedTimingConstant;
            }
            return DefaultMismatchScore;
        }

        public override double GetUnnormalisedSimilarity(string firstWord, string secondWord)
        {
            return GetSimilarity(firstWord, secondWord);
        }

        public override string LongDescriptionString => "Implements the Jaccard Similarity algorithm providing a similarity measure between two strings";

        public override string ShortDescriptionString => "JaccardSimilarity";
    }
}