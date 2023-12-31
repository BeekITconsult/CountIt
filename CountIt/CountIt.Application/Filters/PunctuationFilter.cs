﻿using System.Text.RegularExpressions;
using CountIt.Domain.Entities;

namespace CountIt.Application.Filters;

public class PunctuationFilter : IFilterDocument
{
    public Document Filter(Document document)
    {
        var filtered = FilterPunctuationCharacters(document.Contents);

        return document with
        {
            Contents = filtered
        };
    }

    public string FilterPunctuationCharacters(string text)
    {
        var regex = new Regex(@"[.,;]+", RegexOptions.None);
        var filtered = regex.Replace(text, string.Empty);
        return filtered;
    }



}