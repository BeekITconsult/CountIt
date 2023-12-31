﻿using System.Text.RegularExpressions;
using CountIt.Domain.Entities;

namespace CountIt.Application;

public class WordDetector : IDetectWords
{
    public ICollection<string> GetWordsFromText(string text)
    {
        var regex = new Regex(@"\s+");

        return regex
            .Split(text)
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToList();
    }
}