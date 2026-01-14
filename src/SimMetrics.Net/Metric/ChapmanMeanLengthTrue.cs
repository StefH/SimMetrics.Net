using System;
using SimMetrics.Net.API;

namespace SimMetrics.Net.Metric;

/// <summary>
/// Correct Chapman Mean Length implementation.
/// </summary>
public sealed class ChapmanMeanLengthTrue : AbstractStringMetric
{
    private const double DefaultMismatchScore = 0.0;
    private const double DefaultPerfectScore = 1.0;

    public override double GetSimilarity(string firstWord, string secondWord)
    {
        if (string.IsNullOrEmpty(firstWord) || string.IsNullOrEmpty(secondWord))
        {
            return DefaultMismatchScore;
        }

        // Compute LCS length
        var lcs = LongestCommonSubsequence(firstWord, secondWord);

        // Chapman Mean Length formula
        var score = 2.0 * lcs / (firstWord.Length + secondWord.Length);

        return score switch
        {
            < DefaultMismatchScore => DefaultMismatchScore,
            > DefaultPerfectScore => DefaultPerfectScore,
            _ => score
        };
    }

    public override string GetSimilarityExplained(string firstWord, string secondWord)
    {
        throw new NotImplementedException();
    }

    public override double GetSimilarityTimingEstimated(string firstWord, string secondWord)
    {
        return 0.0;
    }

    public override double GetUnnormalisedSimilarity(string firstWord, string secondWord)
    {
        return GetSimilarity(firstWord, secondWord);
    }

    public override string LongDescriptionString => "A true implementation of the Chapman Mean Length algorithm";

    public override string ShortDescriptionString => nameof(ChapmanMeanLengthTrue);

    private static int LongestCommonSubsequence(string s1, string s2)
    {
        int m = s1.Length, n = s2.Length;
        int[,] dp = new int[m + 1, n + 1];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (s1[i] == s2[j])
                {
                    dp[i + 1, j + 1] = dp[i, j] + 1;
                }
                else
                {
                    dp[i + 1, j + 1] = Math.Max(dp[i, j + 1], dp[i + 1, j]);
                }
            }
        }

        return dp[m, n];
    }
}