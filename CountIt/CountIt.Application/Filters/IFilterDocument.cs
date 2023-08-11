using CountIt.Domain.Entities;

namespace CountIt.Application.Filters;

public interface IFilterDocument
{
    /// <summary>
    /// Filters input document by reference
    /// </summary>
    Document Filter(Document document);
}