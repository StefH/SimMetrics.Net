using System;
using System.Collections.ObjectModel;
using SimMetrics.Net.API;

namespace SimMetrics.Net.Utilities
{
    public class TokeniserQGram2 : AbstractTokeniserQGramN
    {
        public TokeniserQGram2()
        {
            StopWordHandler = new DummyStopTermHandler();
            TokenUtilities = new TokeniserUtilities<string>();
            CharacterCombinationIndex = 0;
            QGramLength = 2;
        }

        public override Collection<string> Tokenize(string word)
        {
            return base.Tokenize(word, false, QGramLength, CharacterCombinationIndex);
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(SuppliedWord))
            {
                return string.Format("{0} : not word passed for tokenising yet.", ShortDescriptionString);
            }
            return string.Format("{0} - currently holding : {1}.{2} The method is using a QGram length of {3}.", ShortDescriptionString, SuppliedWord, Environment.NewLine, Convert.ToInt32(QGramLength));
        }

        public override string ShortDescriptionString => "TokeniserQGram2";
    }
}