namespace CountIt.Domain.Entities;

public record ProcessedDocument
{
    public ICollection<WordCountPair> WordCounts { get; set; } = new List<WordCountPair>();
}