using System.Collections.Generic;
using JetBrains.Annotations;
using SimMetrics.Net.Metric;

namespace SimMetrics.Net
{
    public static class Extensions
    {
        [PublicAPI]
        public static List<string> ApproximatelyEquals(this List<string> list, string word, double threshold, SimMetricType simMetricType = SimMetricType.Levenstein)
        {
            var newList = new List<string>();
            foreach (var l in list)
            {
                var num = l.ApproximatelyEquals(word, simMetricType);
                var thr = 1 - num;
                if (thr <= threshold)
                    newList.Add(l);
            }
            return newList;
        }

        [PublicAPI]
        public static double ApproximatelyEquals(this string firstWord, string secondWord, SimMetricType simMetricType = SimMetricType.Levenstein)
        {
            switch (simMetricType)
            {
                case SimMetricType.BlockDistance:
                    var sim2 = new BlockDistance();
                    return sim2.GetSimilarity(firstWord, secondWord);
                case SimMetricType.ChapmanLengthDeviation:
                    var sim3 = new ChapmanLengthDeviation();
                    return sim3.GetSimilarity(firstWord, secondWord);
                case SimMetricType.CosineSimilarity:
                    var sim4 = new CosineSimilarity();
                    return sim4.GetSimilarity(firstWord, secondWord);
                case SimMetricType.DiceSimilarity:
                    var sim5 = new DiceSimilarity();
                    return sim5.GetSimilarity(firstWord, secondWord);
                case SimMetricType.EuclideanDistance:
                    var sim6 = new EuclideanDistance();
                    return sim6.GetSimilarity(firstWord, secondWord);
                case SimMetricType.JaccardSimilarity:
                    var sim7 = new JaccardSimilarity();
                    return sim7.GetSimilarity(firstWord, secondWord);
                case SimMetricType.Jaro:
                    var sim8 = new Jaro();
                    return sim8.GetSimilarity(firstWord, secondWord);
                case SimMetricType.JaroWinkler:
                    var sim9 = new JaroWinkler();
                    return sim9.GetSimilarity(firstWord, secondWord);
                case SimMetricType.MatchingCoefficient:
                    var sim10 = new MatchingCoefficient();
                    return sim10.GetSimilarity(firstWord, secondWord);
                case SimMetricType.MongeElkan:
                    var sim11 = new MongeElkan();
                    return sim11.GetSimilarity(firstWord, secondWord);
                case SimMetricType.NeedlemanWunch:
                    var sim12 = new NeedlemanWunch();
                    return sim12.GetSimilarity(firstWord, secondWord);
                case SimMetricType.OverlapCoefficient:
                    var sim13 = new OverlapCoefficient();
                    return sim13.GetSimilarity(firstWord, secondWord);
                case SimMetricType.QGramsDistance:
                    var sim14 = new QGramsDistance();
                    return sim14.GetSimilarity(firstWord, secondWord);
                case SimMetricType.SmithWaterman:
                    var sim15 = new SmithWaterman();
                    return sim15.GetSimilarity(firstWord, secondWord);
                case SimMetricType.SmithWatermanGotoh:
                    var sim16 = new SmithWatermanGotoh();
                    return sim16.GetSimilarity(firstWord, secondWord);
                case SimMetricType.SmithWatermanGotohWindowedAffine:
                    var sim17 = new SmithWatermanGotohWindowedAffine();
                    return sim17.GetSimilarity(firstWord, secondWord);
                case SimMetricType.ChapmanMeanLength:
                    var sim18 = new ChapmanMeanLength();
                    return sim18.GetSimilarity(firstWord, secondWord);
                default:
                    var sim1 = new Levenstein();
                    return sim1.GetSimilarity(firstWord, secondWord);
            }
        }
    }
}