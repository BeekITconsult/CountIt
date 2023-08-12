using CountIt.Domain.Entities;
using CountIt.SharedLibrary.Ordering;

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

        var ordered = document.WordCountPairs.ToList().OrderBy(x => x.Word);

        foreach (var wcp in ordered)
        {
            _outputWriter.WriteLine($"{wcp.Word.ToLower()} {wcp.Count}");
        }
    }

    public void Present(string message)
    {
        _outputWriter.WriteLine(message);
    }
}