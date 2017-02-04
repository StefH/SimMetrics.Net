namespace SimMetrics.Net.API
{
    public abstract class AbstractSubstitutionCost : ISubstitutionCost
    {
        public abstract double GetCost(string firstWord, int firstWordIndex, string secondWord, int secondWordIndex);

        public abstract double MaxCost { get; }

        public abstract double MinCost { get; }

        public abstract string ShortDescriptionString { get; }
    }
}

