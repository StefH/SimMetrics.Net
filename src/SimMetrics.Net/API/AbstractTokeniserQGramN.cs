using System.Collections.ObjectModel;
using System.Text;
using SimMetrics.Net.Utilities;

namespace SimMetrics.Net.API
{
    public abstract class AbstractTokeniserQGramN : ITokeniser
    {
        private const string DefaultEndPadCharacter = "#";
        private const string DefaultStartPadCharacter = "?";

        public abstract Collection<string> Tokenize(string word);

        public Collection<string> Tokenize(string word, bool extended, int tokenLength, int characterCombinationIndexValue)
        {
            int num3;
            if (string.IsNullOrEmpty(word))
            {
                return null;
            }
            SuppliedWord = word;
            Collection<string> collection = new Collection<string>();
            int length = word.Length;
            int count = 0;
            if (tokenLength > 0)
            {
                count = tokenLength - 1;
            }
            StringBuilder builder = new StringBuilder(length + 2 * count);
            if (extended)
            {
                builder.Insert(0, DefaultStartPadCharacter, count);
            }
            builder.Append(word);
            if (extended)
            {
                builder.Insert(builder.Length, DefaultEndPadCharacter, count);
            }
            string str = builder.ToString();
            if (extended)
            {
                num3 = length + count;
            }
            else
            {
                num3 = length - tokenLength + 1;
            }
            for (int i = 0; i < num3; i++)
            {
                string termToTest = str.Substring(i, tokenLength);
                if (!StopWordHandler.IsWord(termToTest))
                {
                    collection.Add(termToTest);
                }
            }
            if (characterCombinationIndexValue != 0)
            {
                str = builder.ToString();
                num3--;
                for (int j = 0; j < num3; j++)
                {
                    string str3 = str.Substring(j, count) + str.Substring(j + tokenLength, 1);
                    if (!StopWordHandler.IsWord(str3) && !collection.Contains(str3))
                    {
                        collection.Add(str3);
                    }
                }
            }
            return collection;
        }

        public Collection<string> TokenizeToSet(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                SuppliedWord = word;
                return TokenUtilities.CreateSet(Tokenize(word));
            }
            return null;
        }

        public int CharacterCombinationIndex { get; set; }

        public string Delimiters => string.Empty;

        public int QGramLength { get; set; }

        public abstract string ShortDescriptionString { get; }

        public ITermHandler StopWordHandler { get; set; }

        public string SuppliedWord { get; set; }

        public TokeniserUtilities<string> TokenUtilities { get; set; }
    }
}