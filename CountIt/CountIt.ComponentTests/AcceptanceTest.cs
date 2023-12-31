using System.Threading.Tasks;
using CountIt.ConsoleApp.Services;
using CountIt.Domain.Exceptions;
using CountIt.Domain.Ports;
using CountIt.TestSupport;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace CountIt.ComponentTests;

public class AcceptanceTest
{
    private readonly Worker _sut;
    private readonly Mock<IGetDocument> _getDocument;
    private readonly OutputWriterCapturer _outputWriterCapturer;


    public AcceptanceTest()
    {
        _getDocument = new Mock<IGetDocument>();
        _outputWriterCapturer = new OutputWriterCapturer();

        var testEnvironment = new TestEnvironment();
        testEnvironment.ServiceCollection.AddScoped<IGetDocument>(x => _getDocument.Object);
        testEnvironment.ServiceCollection.AddScoped<IOutputWriter>(x => _outputWriterCapturer);

        var scope = testEnvironment.ServiceCollection
            .BuildServiceProvider()
            .CreateScope();

        _sut = scope.ServiceProvider.GetRequiredService<Worker>();
    }


    [Fact]
    public async Task DocumentFromAssignment_MeetsResultFromAssignment()
    {
        // Arrange
        const string contents = "The big brown fox number 4 jumped over the lazy dog. THE BIG BROWN FOX JUMPED OVER THE LAZY DOG. \n The Big Brown Fox 123";
        var document = DocumentFactory.Create(contents);
        _getDocument.Setup(x => x.GetDocumentAsync()).ReturnsAsync(document);

        // Act
        await _sut.Execute();

        // Assert
        _outputWriterCapturer.CapturedLines.Should()
            .BeEquivalentTo(new [] {"Number of words: 23", "big 3", "brown 3", "dog 2", "fox 3", "jumped 2", "lazy 2", "number 1", "over 2", "the 5"}, o => o.WithStrictOrdering());
    }

    [Fact]
    public async Task EmptyDocumentDoesNotCrash()
    {
        // Arrange
        const string contents = "";
        var document = DocumentFactory.Create(contents);
        _getDocument.Setup(x => x.GetDocumentAsync()).ReturnsAsync(document);

        // Act
        await _sut.Execute();

        // Assert
        _outputWriterCapturer.CapturedLines.Should().BeEquivalentTo("Number of words: 0");
    }

    [Fact]
    public async Task DocumentNotFound_FailsGracefully()
    {
        // Arrange
        _getDocument.Setup(x => x.GetDocumentAsync()).Throws<DocumentNotFoundException>();

        // Act
        await _sut.Execute();

        // Assert
        _outputWriterCapturer.CapturedLines.Should().BeEquivalentTo("Something went wrong loading the document, please contact our support department at awesomesupportdesk@countit.com");
    }
}