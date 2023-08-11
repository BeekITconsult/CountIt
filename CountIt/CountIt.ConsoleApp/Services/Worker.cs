using CountIt.Application;

namespace CountIt.ConsoleApp.Services;

public class Worker
{
    private readonly IWordCountProcessor _wordCountProcessor;
    private readonly IProcessedDocumentPresenter _presenter;

    public Worker(IWordCountProcessor wordCountProcessor, IProcessedDocumentPresenter presenter )
    {
        _wordCountProcessor = wordCountProcessor;
        _presenter = presenter;
    }

    public async Task Execute()
    {
        var document = await _wordCountProcessor.GetWordCountAsync();
        _presenter.Present(document);
    }
}