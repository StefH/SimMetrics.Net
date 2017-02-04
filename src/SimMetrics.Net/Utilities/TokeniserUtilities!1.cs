using System.Collections.ObjectModel;

namespace SimMetrics.Net.Utilities
{
    public class TokeniserUtilities<T>
    {
        public TokeniserUtilities()
        {
            MergedTokens = new Collection<T>();
            TokenSet = new Collection<T>();
        }

        private void AddTokens(Collection<T> tokenList)
        {
            foreach (T local in tokenList)
            {
                MergedTokens.Add(local);
            }
        }

        private void AddUniqueTokens(Collection<T> tokenList)
        {
            foreach (T local in tokenList)
            {
                if (!TokenSet.Contains(local))
                {
                    TokenSet.Add(local);
                }
            }
        }

        private int CalculateUniqueTokensCount(Collection<T> tokenList)
        {
            Collection<T> collection = new Collection<T>();
            foreach (T local in tokenList)
            {
                if (!collection.Contains(local))
                {
                    collection.Add(local);
                }
            }
            return collection.Count;
        }

        public int CommonSetTerms()
        {
            return FirstSetTokenCount + SecondSetTokenCount - TokenSet.Count;
        }

        public int CommonTerms()
        {
            return FirstTokenCount + SecondTokenCount - MergedTokens.Count;
        }

        public Collection<T> CreateMergedList(Collection<T> firstTokens, Collection<T> secondTokens)
        {
            MergedTokens.Clear();
            FirstTokenCount = firstTokens.Count;
            SecondTokenCount = secondTokens.Count;
            MergeLists(firstTokens);
            MergeLists(secondTokens);
            return MergedTokens;
        }

        public Collection<T> CreateMergedSet(Collection<T> firstTokens, Collection<T> secondTokens)
        {
            TokenSet.Clear();
            FirstSetTokenCount = CalculateUniqueTokensCount(firstTokens);
            SecondSetTokenCount = CalculateUniqueTokensCount(secondTokens);
            MergeIntoSet(firstTokens);
            MergeIntoSet(secondTokens);
            return TokenSet;
        }

        public Collection<T> CreateSet(Collection<T> tokenList)
        {
            TokenSet.Clear();
            AddUniqueTokens(tokenList);
            FirstTokenCount = TokenSet.Count;
            SecondTokenCount = 0;
            return TokenSet;
        }

        public void MergeIntoSet(Collection<T> firstTokens)
        {
            AddUniqueTokens(firstTokens);
        }

        public void MergeLists(Collection<T> firstTokens)
        {
            AddTokens(firstTokens);
        }

        public int FirstSetTokenCount { get; private set; }

        public int FirstTokenCount { get; private set; }

        public Collection<T> MergedTokens { get; }

        public int SecondSetTokenCount { get; private set; }

        public int SecondTokenCount { get; private set; }

        public Collection<T> TokenSet { get; }
    }
}