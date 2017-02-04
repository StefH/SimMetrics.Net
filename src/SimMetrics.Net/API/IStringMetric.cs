namespace SimMetrics.Net.API
{
    public interface IStringMetric
    {
        double GetSimilarity(string firstWord, string secondWord);
        string GetSimilarityExplained(string firstWord, string secondWord);
        long GetSimilarityTimingActual(string firstWord, string secondWord);
        double GetSimilarityTimingEstimated(string firstWord, string secondWord);
        double GetUnnormalisedSimilarity(string firstWord, string secondWord);

        string LongDescriptionString { get; }

        string ShortDescriptionString { get; }
    }
}

