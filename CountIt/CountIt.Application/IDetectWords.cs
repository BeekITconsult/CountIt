namespace CountIt.Application;

public interface IDetectWords
{
    ICollection<string> GetWordsFromText(string text);
}