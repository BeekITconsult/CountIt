using System.Threading.Tasks;
using CountIt.Domain.Entities;
using CountIt.Domain.Ports;
using CountIt.TestSupport;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace CountIt.Application.IntegrationTests;

public class WordCountProcessorTests
{
    private readonly IWordCountProcessor _sut;
    private readonly Mock<IGetDocument> _getDocument;


    public WordCountProcessorTests()
    {
        _getDocument = new Mock<IGetDocument>();

        var testEnvironment = new TestEnvironment();
        testEnvironment.ServiceCollection.AddScoped<IGetDocument>(x => _getDocument.Object);
        var scope = testEnvironment.ServiceCollection
            .BuildServiceProvider()
            .CreateScope();

        _sut = scope.ServiceProvider.GetRequiredService<IWordCountProcessor>();
    }

    [Fact]
    public async Task Enteres_AreProcessedCorrectly()
    {
        // Arrange
        var input = "James \n is \n awesome";

        SetupGetDocument(input);

        // Act
        var result = await _sut.GetWordCountAsync();

        // Assert
        result.WordCountPairs.Should().HaveCount(3);
    }


    [Theory]
    [InlineData("BZ4X", 1)]
    [InlineData("4ever together", 2)]
    public async Task NumbersPartOfWordsAreIgnored(string input, int expectedCount)
    {
        // Arrange
        SetupGetDocument(input);

        // Act
        var result = await _sut.GetWordCountAsync();

        // Assert
        result.WordCountPairs.Should().HaveCount(expectedCount);
    }

    [Theory]
    [InlineData("AM am", 1)]
    [InlineData("I am awake at four AM", 5)]
    [InlineData("am jAMming", 2)]
    public async Task Words_WithCapitals_AreRecognizedAsSameWords(string input, int expectedCount)
    {
        // Arrange
        var testCase1 = "I am jAMming";
        SetupGetDocument(input);

        // Act
        var result = await _sut.GetWordCountAsync();

        // Assert
        result.WordCountPairs.Should().HaveCount(expectedCount);
    }

    [Fact]
    public async Task Words_WithCapitals_AreRecognizedAsSameWords_AssertExactWords()
    {
        // Arrange
        var input = "I am jAMming at four AM";
        SetupGetDocument(input);

        // Act
        var result = await _sut.GetWordCountAsync();

        // Assert
        result.WordCountPairs.Should().BeEquivalentTo(new[]
        {
            new WordCountPair()
            {
                Word = "I",
                Count = 1,
            },
            new WordCountPair()
            {
                Word = "am",
                Count = 2,
            },
            new WordCountPair()
            {
                Word = "jAMming",
                Count = 1,
            },
            new WordCountPair()
            {
                Word = "at",
                Count = 1,
            },

            new WordCountPair()
            {
                Word = "four",
                Count = 1,
            },
        });
    }

    [Theory]
    [InlineData("It's holiday", 2)]
    [InlineData("#superdupertest", 1)]
    [InlineData("j0hns@ns", 1)]
    [InlineData("\"john", 1)]
    public async Task SpecialMarks_AreRecognizedAs_PartOfWord(string input, int expectedCount)
    {
        // Arrange
        SetupGetDocument(input);

        // Act
        var result = await _sut.GetWordCountAsync();

        // Assert
        result.WordCountPairs.Should().HaveCount(expectedCount);
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