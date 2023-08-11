namespace CountIt.Domain.Entities;

public record Document
{
    public required string Name { get; set; }
    public required string Contents { get; set; }
}