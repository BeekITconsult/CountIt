using System.IO.Enumeration;
using CountIt.Application.Filters;
using CountIt.Domain.Entities;
using CountIt.Domain.Ports;

namespace CountIt.Application;

public class WordCountProcessor : IWordCountProcessor
{
    private readonly IGetDocument _getDocument;
    private readonly IFilterPipeline _filterPipeline;
    private readonly IDetectWords _wordDetector;
    private readonly ICountWords _wordCounter;

    public WordCountProcessor(
        IGetDocument getDocument,
        IFilterPipeline filterPipeline,
        IDetectWords wordDetector,
        ICountWords wordCounter)
    {
        _getDocument = getDocument;
        _filterPipeline = filterPipeline;
        _wordDetector = wordDetector;
        _wordCounter = wordCounter;
    }

    public async Task<ProcessedDocument> GetWordCountAsync()
    {
        var document = await _getDocument.GetDocumentAsync();
        var filtered = _filterPipeline.FilterDocument(document);
        var words = _wordDetector.GetWordsFromText(filtered.Contents);
        var wordCount = _wordCounter.CountNumberOfOccurencesPerWord(words, StringComparison.InvariantCultureIgnoreCase);

        return new ProcessedDocument
        {
            FileName = document.Name,
            WordCountPairs = wordCount
        };
    }


}