using CountIt.Domain.Entities;
using CountIt.Domain.Ports;

namespace CountIt.Infrastructure;

public class DocumentRetriever : IGetDocument
{
    public async Task<Document> GetDocumentAsync()
    {
        var path = @"C:\temp\countit\input.txt";
        var contents = await File.ReadAllTextAsync(path);

        return new Document
        {
            Name = "input.txt",
            Contents = contents
        };
    }
}