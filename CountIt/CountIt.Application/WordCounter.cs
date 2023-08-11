using CountIt.Domain.Entities;

namespace CountIt.Application;

public class WordCounter : ICountWords
{
    public ICollection<WordCountPair> CountNumberOfOccurencesPerWord(ICollection<string> words, StringComparison comparison)
    {
        var wordCountPairCollection = new List<WordCountPair>();

        foreach (var word in words)
        {
            var wcp = GetOrCreateAndAddWordCountPair(wordCountPairCollection, word, comparison);

            wcp.Count++;
        }

        return wordCountPairCollection;
    }

    private WordCountPair GetOrCreateAndAddWordCountPair(ICollection<WordCountPair> wordCountPairCollection, string word, StringComparison comparison)
    {
        var wcp = wordCountPairCollection.FirstOrDefault(x => x.Word.Equals(word, comparison));

        if (wcp != null)
        {
            return wcp;
        }

        wcp = new WordCountPair {Word = word, Count = 0};
        wordCountPairCollection.Add(wcp);

        return wcp;
    }
}