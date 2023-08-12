using CountIt.SharedLibrary.Ordering;
using FluentAssertions;

namespace CountIt.SharedLibrary.UnitTests;

public class CustomOrderByTests
{
    [Fact]
    public void OrdersCorrectly()
    {
        var input = new[]
        {
            new NameAgePair {Name = "Sjefke", Age = 42},
            new NameAgePair {Name = "Adri", Age = 11},
            new NameAgePair {Name = "Berend", Age = 99},
        };

        var resultByName = input.OrderBy(x => x.Name);
        var resultByAge = input.OrderBy(x => x.Age);

        resultByName
            .Should()
            .BeEquivalentTo(new[]
                {
                    new NameAgePair {Name = "Adri", Age = 11},
                    new NameAgePair {Name = "Berend", Age = 99},
                    new NameAgePair {Name = "Sjefke", Age = 42},
                },
                o => o.WithStrictOrdering());

        resultByAge
            .Should()
            .BeEquivalentTo(new[]
                {
                    new NameAgePair {Name = "Adri", Age = 11},
                    new NameAgePair {Name = "Sjefke", Age = 42},
                    new NameAgePair {Name = "Berend", Age = 99},
                },
                o => o.WithStrictOrdering());

    }

    private record NameAgePair
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}