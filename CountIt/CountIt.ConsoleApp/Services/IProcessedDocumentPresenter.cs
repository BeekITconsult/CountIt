using CountIt.Domain.Entities;

namespace CountIt.ConsoleApp.Services;

public interface IProcessedDocumentPresenter
{
    void Present(ProcessedDocument document);
    void Present(string message);
}