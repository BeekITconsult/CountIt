﻿using System.Text.RegularExpressions;
using CountIt.Domain.Entities;

namespace CountIt.Application;

public class NumberFilter : IDocumentFilter
{
    public Document Filter(Document document)
    {
        var filtered = RemoveNumbers(document.Contents);

        return document with
        {
            Contents = filtered
        };
    }

    private static string RemoveNumbers(string text)
    {
        var regex = new Regex(@"\d", RegexOptions.None);
        var filtered = regex.Replace(text, string.Empty);
        return filtered;
    }
}