namespace CountIt.Domain.Entities;

public class ProcessedDocument
{
    public ICollection<WordCountPair> WordCounts { get; set; } = new List<WordCountPair>();
}