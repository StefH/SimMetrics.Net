using System;
using SimMetrics.Net.API;
using SimMetrics.Net.Utilities;

namespace SimMetrics.Net.Metric
{
    public sealed class OverlapCoefficient : AbstractStringMetric
    {
        private const double DefaultMismatchScore = 0.0;
        private readonly double _estimatedTimingConstant;
        private readonly ITokeniser _tokeniser;
        private readonly TokeniserUtilities<string> _tokenUtilities;

        public OverlapCoefficient() : this(new TokeniserWhitespace())
        {
        }

        public OverlapCoefficient(ITokeniser tokeniserToUse)
        {
            _estimatedTimingConstant = 0.00014000000373926014;
            _tokeniser = tokeniserToUse;
            _tokenUtilities = new TokeniserUtilities<string>();
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            if (firstWord != null && secondWord != null)
            {
                _tokenUtilities.CreateMergedSet(_tokeniser.Tokenize(firstWord), _tokeniser.Tokenize(secondWord));
                return _tokenUtilities.CommonSetTerms() / (double)Math.Min(_tokenUtilities.FirstSetTokenCount, _tokenUtilities.SecondSetTokenCount);
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

        public override string LongDescriptionString => "Implements the Overlap Coefficient algorithm providing a similarity measure between two string where it is determined to what degree a string is a subset of another";

        public override string ShortDescriptionString => "OverlapCoefficient";
    }
}