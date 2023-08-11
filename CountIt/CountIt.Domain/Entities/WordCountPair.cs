namespace CountIt.Domain.Entities;

public record WordCountPair
{
    public required string Word { get; set; }
    public required int Count { get; set; }
}