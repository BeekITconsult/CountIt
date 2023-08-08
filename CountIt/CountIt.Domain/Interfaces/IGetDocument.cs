using CountIt.Domain.Entities;

namespace CountIt.Domain.Repository;

public interface IGetDocument
{
    Task<Document> GetDocumentAsync();
}