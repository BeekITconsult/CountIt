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
        _outputWriter.WriteLine($"Number of words: {document.WordCountPairs.Sum(x => x.Count)}");

        // Todo: Use custom order
        var ordered = document.WordCountPairs.OrderBy(x => x.Word).ToList();

        foreach (var wcp in ordered)
        {
            _outputWriter.WriteLine($"{wcp.Word.ToLower()} {wcp.Count}");
        }
    }
}