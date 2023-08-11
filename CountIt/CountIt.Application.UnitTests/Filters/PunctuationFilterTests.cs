using CountIt.TestSupport;
using FluentAssertions;
using Xunit;

namespace CountIt.Application.UnitTests.Filters;

public class PunctuationFilterTests
{
    private readonly PunctuationFilter _sut = new PunctuationFilter();

    [Theory]
    [InlineData("e-mail", "e-mail")]
    [InlineData("j@ck", "j@ck")]
    [InlineData("Jake.", "Jake")]
    [InlineData("I'm", "I'm")]
    [InlineData("I, see", "I see")]
    [InlineData("I see you;", "I see you")]
    public void Filters_Correctly(string input, string expectedResult)
    {
        // Arrange
        var document = DocumentFactory.Create(input);

        // Act
        var result = _sut.Filter(document);

        // Assert
        result.Contents.Should().Be(expectedResult);
    }
}