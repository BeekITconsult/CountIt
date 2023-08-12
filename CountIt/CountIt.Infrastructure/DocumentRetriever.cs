using CountIt.Domain.Entities;
using CountIt.Domain.Exceptions;
using CountIt.Domain.Ports;

namespace CountIt.Infrastructure;

public class DocumentRetriever : IGetDocument
{
    public async Task<Document> GetDocumentAsync()
    {
        var path = @"C:\temp\countit\input.txt";
        try
        {
            var contents = await File.ReadAllTextAsync(path);

            return new Document
            {
                Name = "input.txt",
                Contents = contents
            };
        }
        catch (Exception ex) when (ex is FileNotFoundException ||
                                   ex is DirectoryNotFoundException ||
                                   ex is IOException ||
                                   ex is UnauthorizedAccessException)
        {
            throw new DocumentNotFoundException($"Unable to read from document at path {path}", ex);
        }
    }
}