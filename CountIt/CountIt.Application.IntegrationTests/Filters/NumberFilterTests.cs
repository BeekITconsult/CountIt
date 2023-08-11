using System.Runtime.InteropServices;
using CountIt.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CountIt.Application.IntegrationTests.Filters;

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
        var document = CreateDocument(contents);

        // Act
        var result = _sut.Filter(document);

        // Assert
        result.Contents.Should().Be(expectedContents);
    }

    private static Document CreateDocument(string testString)
    {
        return new Document
        {
            Name = "test.txt",
            Contents = testString
        };
    }
}