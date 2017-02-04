using System;

namespace SimMetrics.Net.API
{
    public abstract class AbstractStringMetric : IStringMetric
    {
        public double[] BatchCompareSet(string[] setRenamed, string comparator)
        {
            if (setRenamed == null || comparator == null)
            {
                return null;
            }
            double[] numArray = new double[setRenamed.Length];
            for (int i = 0; i < setRenamed.Length; i++)
            {
                numArray[i] = GetSimilarity(setRenamed[i], comparator);
            }
            return numArray;
        }

        public double[] BatchCompareSets(string[] firstSet, string[] secondSet)
        {
            double[] numArray;
            if (firstSet == null || secondSet == null)
            {
                return null;
            }

            if (firstSet.Length <= secondSet.Length)
            {
                numArray = new double[firstSet.Length];
            }
            else
            {
                numArray = new double[secondSet.Length];
            }

            for (int i = 0; i < numArray.Length; i++)
            {
                numArray[i] = GetSimilarity(firstSet[i], secondSet[i]);
            }

            return numArray;
        }

        public abstract double GetSimilarity(string firstWord, string secondWord);
        public abstract string GetSimilarityExplained(string firstWord, string secondWord);
        public long GetSimilarityTimingActual(string firstWord, string secondWord)
        {
            long num = (DateTime.Now.Ticks - 0x89f7ff5f7b58000L) / 0x2710L;
            GetSimilarity(firstWord, secondWord);
            long num2 = (DateTime.Now.Ticks - 0x89f7ff5f7b58000L) / 0x2710L;
            return num2 - num;
        }

        public abstract double GetSimilarityTimingEstimated(string firstWord, string secondWord);
        public abstract double GetUnnormalisedSimilarity(string firstWord, string secondWord);

        public abstract string LongDescriptionString { get; }

        public abstract string ShortDescriptionString { get; }
    }
}

