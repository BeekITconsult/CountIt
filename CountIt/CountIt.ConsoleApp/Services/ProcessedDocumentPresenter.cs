using CountIt.Domain.Entities;

namespace CountIt.ConsoleApp.Services;

public class ProcessedDocumentPresenter : IProcessedDocumentPresenter
{
    private readonly IOutputWriter _outputWriter;

    public ProcessedDocumentPresenter(IOutputWriter outputWriter)
    {
        _outputWriter = outputWriter;
    }

    public void Present(ProcessedDocument document)
    {
        _outputWriter.WriteLine($"Number of words: {document.WordCountPairs.Count}");
        foreach (var wcp in document.WordCountPairs)
        {
            _outputWriter.WriteLine($"{wcp.Word.ToLower()} {wcp.Count}");
        }
    }
}