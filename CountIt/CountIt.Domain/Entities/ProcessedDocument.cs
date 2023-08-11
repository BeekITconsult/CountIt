namespace CountIt.Domain.Entities;

public record ProcessedDocument
{
    public required string FileName { get; set; }
    public required ICollection<WordCountPair> WordCountPairs { get; set; } = new List<WordCountPair>();
}