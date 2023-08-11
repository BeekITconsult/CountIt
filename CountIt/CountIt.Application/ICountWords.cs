using CountIt.Domain.Entities;

namespace CountIt.Application;

public interface ICountWords
{
    ICollection<WordCountPair> CountNumberOfOccurencesPerWord(ICollection<string> words, StringComparison comparison);
}