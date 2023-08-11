using CountIt.Domain.Entities;

namespace CountIt.Application;

public interface IWordCountProcessor
{
    Task<ProcessedDocument> GetWordCountAsync();
}