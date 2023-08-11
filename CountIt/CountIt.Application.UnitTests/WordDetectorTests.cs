using FluentAssertions;
using Xunit;

namespace CountIt.Application.UnitTests;

public class WordDetectorTests
{
    private readonly WordDetector _sut = new ();

    [Fact]
    public void FindsWords_DelimitedBySpace()
    {
        var inputString = "This is something";

        var result = _sut.GetWordsFromText(inputString);

        result.Should().BeEquivalentTo("This", "is", "something");
    }

    [Fact]
    public void FindsWords_DelimitedByMultipleSpaces()
    {
        var inputString = "This  is  something";

        var result = _sut.GetWordsFromText(inputString);

        result.Should().BeEquivalentTo("This", "is", "something");
    }

    [Fact]
    public void FindsWords_IgnoresLeadingAndTrailingSpaces()
    {
        var inputString = "   This  is  something    ";

        var result = _sut.GetWordsFromText(inputString);

        result.Should().BeEquivalentTo("This", "is", "something");
    }

    [Fact]
    public void FindsWords_DelimitedByTab()
    {
        var inputString = "This\tis\tsomething";

        var result = _sut.GetWordsFromText(inputString);

        result.Should().BeEquivalentTo("This", "is", "something");
    }

    [Fact]
    public void ConsidersDotPartOfWord()
    {
        var inputString = "This  is  something.";

        var result = _sut.GetWordsFromText(inputString);

        result.Should().BeEquivalentTo("This", "is", "something.");
    }
}