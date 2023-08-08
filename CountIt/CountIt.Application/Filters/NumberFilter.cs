using CountIt.Domain.Entities;

namespace CountIt.Application;

public class NumberFilter : IDocumentFilter
{
    public void Filter(Document document)
    {
        // Filter numbers by regex
    }
}