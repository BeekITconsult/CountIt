namespace CountIt.Domain.Entities;

public record WordCountPair
{
    public string Word { get; set; }
    public int Pair { get; set; }
}