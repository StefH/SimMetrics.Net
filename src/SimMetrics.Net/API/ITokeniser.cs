using System.Collections.ObjectModel;

namespace SimMetrics.Net.API
{
    public interface ITokeniser
    {
        Collection<string> Tokenize(string word);
        Collection<string> TokenizeToSet(string word);

        string Delimiters { get; }

        string ShortDescriptionString { get; }

        ITermHandler StopWordHandler { get; set; }
    }
}

