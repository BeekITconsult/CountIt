using CountIt.Application;
using CountIt.Application.Filters;
using CountIt.ConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CountIt.ConsoleApp;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddCountIt(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddFilterPipeline()
            .AddTransient<IDetectWords, WordDetector>()
            .AddTransient<ICountWords, WordCounter>()
            .AddTransient<IDetectWords, WordDetector>()
            .AddTransient<IWordCountProcessor, WordCountProcessor>()
            .AddTransient<IProcessedDocumentPresenter, ProcessedDocumentPresenter>()
            .AddTransient<IOutputWriter, ConsoleOutputWriter>()
            .AddTransient<Worker>();
    }

    private static IServiceCollection AddFilterPipeline(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddTransient<IFilterDocument, NumberFilter>()
            .AddTransient<IFilterDocument, PunctuationFilter>()
            .AddTransient<IFilterPipeline, FilterPipeline>();
    }
}