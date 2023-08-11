using FluentAssertions;
using Xunit;

namespace CountIt.Application.IntegrationTests;

public class WordDetectorTests
{
    private readonly WordDetector _sut = new ();

    [Fact]
    public void FindsWords_DelimitedBySpace()
    {
        var inputString = "This is something";

        var result = _sut.GetWordsFromText(inputString);

        result.Should().BeEquivalentTo(new[] {"This", "is", "something"});
    }
}