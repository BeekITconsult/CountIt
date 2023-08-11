namespace CountIt.Domain.Entities;

public record Document
{
    public string Name { get; set; }
    public string Contents { get; set; }
}