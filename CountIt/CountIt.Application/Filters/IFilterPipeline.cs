using CountIt.Domain.Entities;

namespace CountIt.Application.Filters;

public interface IFilterPipeline
{
    Document FilterDocument(Document document);
}