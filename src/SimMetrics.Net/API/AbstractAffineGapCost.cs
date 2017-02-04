namespace SimMetrics.Net.API
{
    public abstract class AbstractAffineGapCost : IAffineGapCost
    {
        public abstract double GetCost(string textToGap, int stringIndexStartGap, int stringIndexEndGap);

        public abstract double MaxCost { get; }

        public abstract double MinCost { get; }

        public abstract string ShortDescriptionString { get; }
    }
}