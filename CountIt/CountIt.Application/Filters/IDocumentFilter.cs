using CountIt.Domain.Entities;

namespace CountIt.Application;

public interface IDocumentFilter
{
    /// <summary>
    /// Filters input document by reference
    /// </summary>
    Document Filter(Document document);
}