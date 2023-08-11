using CountIt.TestSupport;
using FluentAssertions;
using Xunit;

namespace CountIt.Application.UnitTests.Filters;

public class NumberFilterTests
{
    private readonly NumberFilter _sut = new NumberFilter();

    [Theory]
    [InlineData("ab2c", "abc")]
    [InlineData("ab234c", "abc")]
    [InlineData("xxx", "xxx")]
    [InlineData("123", "")]
    [InlineData("1a", "a")]
    [InlineData("1@", "@")]
    public void Filter_FiltersNumbersCorrectly(string contents, string expectedContents)
    {
        // Arrange
        var document = DocumentFactory.Create(contents);

        // Act
        var result = _sut.Filter(document);

        // Assert
        result.Contents.Should().Be(expectedContents);
    }
}