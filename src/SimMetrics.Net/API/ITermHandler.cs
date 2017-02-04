using System.Text;

namespace SimMetrics.Net.API
{
    public interface ITermHandler
    {
        void AddWord(string termToAdd);
        bool IsWord(string termToTest);
        void RemoveWord(string termToRemove);

        int NumberOfWords { get; }

        string ShortDescriptionString { get; }

        StringBuilder WordsAsBuffer { get; }
    }
}

