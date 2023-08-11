using CountIt.ConsoleApp;
using Microsoft.Extensions.DependencyInjection;

namespace CountIt.TestSupport;

public class TestEnvironment
{
    public TestEnvironment()
    {
        ServiceCollection = new ServiceCollection();
        ServiceCollection.AddCountIt();
    }

    public IServiceCollection ServiceCollection { get;  }

}