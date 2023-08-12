using CountIt.Application;
using CountIt.Domain.Exceptions;

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
        try
        {
            var document = await _wordCountProcessor.GetWordCountAsync();
            _presenter.Present(document);
        }
        catch (DocumentNotFoundException)
        {
            _presenter.Present("Something went wrong loading the document, please contact our support department at awesomesupportdesk@countit.com");
        }
    }
}