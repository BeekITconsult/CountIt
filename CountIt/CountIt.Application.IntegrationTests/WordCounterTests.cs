using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace CountIt.Application.IntegrationTests;

public class WordCounterTests
{
    private readonly WordCounter _sut = new ();

    [Fact]
    public void All_Words_OccurOnce()
    {
        var words = new[] {"I", "like", "to", "drink", "coffee"};

        var result = _sut.CountNumberOfOccurencesPerWord(words, StringComparison.InvariantCultureIgnoreCase);

        result.Should().HaveCount(5);
        result.Select(x => x.Word).Should().BeEquivalentTo("I", "like", "to", "drink", "coffee");

    }

    [Fact]
    public void Words_AreComparedUsingComparison()
    {
        var words = new[] {"Coffee", "coffee", "COFFEE", "coffeE"};

        var result = _sut.CountNumberOfOccurencesPerWord(words, StringComparison.InvariantCultureIgnoreCase);

        result.Should().ContainSingle();
        result.Single().Word.Should().Be("Coffee");
        result.Single().Count.Should().Be(4);
    }
}