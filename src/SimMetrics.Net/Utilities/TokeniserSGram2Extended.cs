using System;

namespace SimMetrics.Net.Utilities
{
    public class TokeniserSGram2Extended : TokeniserQGram2Extended
    {
        public TokeniserSGram2Extended()
        {
            CharacterCombinationIndex = 1;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(SuppliedWord))
            {
                return string.Format("{0} : no word passed for tokenising yet.", ShortDescriptionString);
            }
            if (CharacterCombinationIndex == 0)
            {
                return string.Format("{0} - currently holding : {1}.{2}The method is using a QGram length of {3}.", ShortDescriptionString, SuppliedWord, Environment.NewLine, Convert.ToInt32(QGramLength));
            }
            return string.Format("{0} - currently holding : {1}.{2}The method is using a character combination index of {3} and {4}a QGram length of {5}.", ShortDescriptionString, SuppliedWord, Environment.NewLine, Convert.ToInt32(CharacterCombinationIndex), Environment.NewLine, Convert.ToInt32(QGramLength));
        }

        public override string ShortDescriptionString => "TokeniserSGram2Extended";
    }
}