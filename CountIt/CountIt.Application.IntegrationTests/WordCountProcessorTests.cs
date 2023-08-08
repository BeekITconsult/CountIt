using System.Threading.Tasks;
using CountIt.Domain.Entities;
using CountIt.Domain.Repository;
using FluentAssertions;
using Moq;
using Xunit;

namespace CountIt.Application.IntegrationTests;

public class WordCountProcessorTests
{
    private readonly WordCountProcessor _sut;
    private readonly Mock<IGetDocument> _getDocument;


    public WordCountProcessorTests()
    {
        _getDocument = new Mock<IGetDocument>();
        _sut = new WordCountProcessor(_getDocument.Object);
    }


    [Theory]
    [InlineData("BZ4X", 2)]
    [InlineData("4ever together", 2)]
    public async Task Words_WithNumbers_AreRecognizedAsTwoWords(string input, int expectedCount)
    {
        // Arrange
        SetupGetDocument(input);

        // Act
        var result = await _sut.GetWordCountAsync();

        // Assert
        result.WordCounts.Should().HaveCount(expectedCount);
    }

    [Theory]
    [InlineData("AM am", 2)]
    [InlineData("I am awake at four AM", 6)]
    [InlineData("am jAMming", 2)]
    public async Task Words_WithCapitals_AreRecognizedAsSameWords(string input, int expectedCount)
    {
        // Arrange
        SetupGetDocument(input);

        // Act
        var result = await _sut.GetWordCountAsync();

        // Assert
        result.WordCounts.Should().HaveCount(expectedCount);

        //TODO: Assert am has count two -> split test
    }

    [Theory]
    [InlineData("It's holiday", 2)]
    [InlineData("#superdupertest", 6)]
    [InlineData("j0hns@ns", 1)]
    public async Task Punctuations_AreRecognizedAs_PartOfWord(string input, int expectedCount)
    {
        // Arrange
        SetupGetDocument(input);

        // Act
        var result = await _sut.GetWordCountAsync();

        // Assert
        result.WordCounts.Should().HaveCount(expectedCount);
    }


    private void SetupGetDocument(string content)
    {
        var document = CreateDocument(content);
        _getDocument.Setup(x => x.GetDocumentAsync()).ReturnsAsync(document);
    }

    private static Document CreateDocument(string input)
    {
        return new Document
        {
            Name = "test.txt",
            Contents = input
        };
    }
}