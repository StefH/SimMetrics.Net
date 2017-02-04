using System;
using System.Collections.ObjectModel;
using SimMetrics.Net.API;
using SimMetrics.Net.Utilities;

namespace SimMetrics.Net.Metric
{
    public class MongeElkan : AbstractStringMetric
    {
        private const double DefaultMismatchScore = 0.0;
        private readonly double _estimatedTimingConstant;
        private readonly AbstractStringMetric _internalStringMetric;
        internal ITokeniser Tokeniser;

        public MongeElkan() : this(new TokeniserWhitespace())
        {
        }

        public MongeElkan(AbstractStringMetric metricToUse)
        {
            _estimatedTimingConstant = 0.034400001168251038;
            Tokeniser = new TokeniserWhitespace();
            _internalStringMetric = metricToUse;
        }

        public MongeElkan(ITokeniser tokeniserToUse)
        {
            _estimatedTimingConstant = 0.034400001168251038;
            Tokeniser = tokeniserToUse;
            _internalStringMetric = new SmithWatermanGotoh();
        }

        public MongeElkan(ITokeniser tokeniserToUse, AbstractStringMetric metricToUse)
        {
            _estimatedTimingConstant = 0.034400001168251038;
            Tokeniser = tokeniserToUse;
            _internalStringMetric = metricToUse;
        }

        public override double GetSimilarity(string firstWord, string secondWord)
        {
            if (firstWord == null || secondWord == null)
            {
                return DefaultMismatchScore;
            }

            Collection<string> collection = Tokeniser.Tokenize(firstWord);
            Collection<string> collection2 = Tokeniser.Tokenize(secondWord);
            double num = 0.0;
            for (int i = 0; i < collection.Count; i++)
            {
                string str = collection[i];
                double num3 = 0.0;
                for (int j = 0; j < collection2.Count; j++)
                {
                    string str2 = collection2[j];
                    double similarity = _internalStringMetric.GetSimilarity(str, str2);
                    if (similarity > num3)
                    {
                        num3 = similarity;
                    }
                }
                num += num3;
            }
            return num / collection.Count;
        }

        public override string GetSimilarityExplained(string firstWord, string secondWord)
        {
            throw new NotImplementedException();
        }

        public override double GetSimilarityTimingEstimated(string firstWord, string secondWord)
        {
            if (firstWord != null && secondWord != null)
            {
                double count = Tokeniser.Tokenize(firstWord).Count;
                double num2 = Tokeniser.Tokenize(secondWord).Count;
                return ((count + num2) * count + (count + num2) * num2) * _estimatedTimingConstant;
            }
            return DefaultMismatchScore;
        }

        public override double GetUnnormalisedSimilarity(string firstWord, string secondWord)
        {
            return GetSimilarity(firstWord, secondWord);
        }

        public override string LongDescriptionString => "Implements the Monge Elkan algorithm providing an matching style similarity measure between two strings";

        public override string ShortDescriptionString => "MongeElkan";
    }
}