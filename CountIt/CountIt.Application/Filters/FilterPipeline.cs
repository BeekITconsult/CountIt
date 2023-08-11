using CountIt.Domain.Entities;

namespace CountIt.Application.Filters;

public class FilterPipeline : IFilterPipeline
{
    private readonly IEnumerable<IFilterDocument> _filters;

    public FilterPipeline(IEnumerable<IFilterDocument> filters)
    {
        _filters = filters;
    }

    public Document FilterDocument(Document document)
    {
        var result = document;
        foreach (var filter in _filters)
        {
            result = filter.Filter(result);
        }

        return result;
    }
}