using System;
using SimMetrics.Net.API;
using SimMetrics.Net.Utilities;

namespace SimMetrics.Net.Metric
{
    public sealed class DiceSimilarity : AbstractStringMetric
    {
        private readonly double _estimatedTimingConstant;
        private readonly ITokeniser _tokeniser;
        private readonly TokeniserUtilities<string> _tokenUtilities;

        public DiceSimilarity() : this(new TokeniserWhitespace())
        {
        }

        public DiceSimilarity(ITokeniser tokeniserToUse)
        {
            _estimatedTimingConstant = 3.4457139008736704E-07;
            _tokeniser = tokeniserToUse;
            _tokenUtilities = new TokeniserUtilities<string>();
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            if (firstWord != null && secondWord != null && _tokenUtilities.CreateMergedSet(_tokeniser.Tokenize(firstWord), _tokeniser.Tokenize(secondWord)).Count > 0)
            {
                return 2.0 * _tokenUtilities.CommonSetTerms() / (_tokenUtilities.FirstSetTokenCount + _tokenUtilities.SecondSetTokenCount);
            }
            return 0.0;
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
                return (length + num2) * ((length + num2) * _estimatedTimingConstant);
            }
            return 0.0;
        }

        public override double GetUnnormalisedSimilarity(string firstWord, string secondWord)
        {
            return GetSimilarity(firstWord, secondWord);
        }

        public override string LongDescriptionString => "Implements the DiceSimilarity algorithm providing a similarity measure between two strings using the vector space of present terms";

        public override string ShortDescriptionString => "DiceSimilarity";
    }
}