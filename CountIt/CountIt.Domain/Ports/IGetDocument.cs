using CountIt.Domain.Entities;

namespace CountIt.Domain.Ports;

public interface IGetDocument
{
    Task<Document> GetDocumentAsync();
}