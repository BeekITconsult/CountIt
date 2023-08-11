using System.Text.RegularExpressions;
using CountIt.Domain.Entities;

namespace CountIt.Application;

public class NumberFilter : IDocumentFilter
{
    public Document Filter(Document document)
    {
        var filtered = RemoveNumbers(document);

        return document with
        {
            Contents = filtered
        };
    }

    private static string RemoveNumbers(Document document)
    {
        var regex = new Regex(@"\d", RegexOptions.None);
        var filtered = regex.Replace(document.Contents, string.Empty);
        return filtered;
    }
}