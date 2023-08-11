using CountIt.Domain.Entities;

namespace CountIt.TestSupport;

public static class DocumentFactory
{
    public static Document Create(string contents)
    {
        return new Document
        {
            Name = "test.txt",
            Contents = contents
        };
    }
}