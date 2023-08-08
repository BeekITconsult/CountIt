using CountIt.Domain.Entities;
using CountIt.Domain.Repository;

namespace CountIt.Application;

public class WordCountProcessor
{
    private readonly IGetDocument _getDocument;

    public WordCountProcessor(IGetDocument getDocument)
    {
        _getDocument = getDocument;
    }

    public async Task<ProcessedDocument> GetWordCountAsync()
    {
        var document = await _getDocument.GetDocumentAsync();

        throw new NotImplementedException();
    }
}