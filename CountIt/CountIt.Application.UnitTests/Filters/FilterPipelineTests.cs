using System.Collections.Generic;
using CountIt.Application.Filters;
using CountIt.Domain.Entities;
using CountIt.TestSupport;
using FluentAssertions;
using Moq;
using Xunit;

namespace CountIt.Application.UnitTests.Filters;

public class FilterPipelineTests
{
    [Fact]
    public void Invokes_All_Filters()
    {
        // Arrange
        var document = DocumentFactory.Create("test");

        var filter1 = new Mock<IFilterDocument>();
        var filtered1 = DocumentFactory.Create("filter1");
        filter1.Setup(f => f.Filter(document)).Returns(filtered1);

        var filter2 = new Mock<IFilterDocument>();
        var filtered2 = DocumentFactory.Create("filter2");
        filter2.Setup(f => f.Filter(filtered1)).Returns(filtered2);

        var sut = new FilterPipeline(new []{filter1.Object, filter2.Object});

        // Act
        var result = sut.FilterDocument(document);

        // Assert
        result.Should().Be(filtered2);
    }

    [Fact]
    public void ReturnsInputUnfiltered_WhenNoFiltersProvided()
    {
        // Arrange
        var document = DocumentFactory.Create("test");
        var sut = new FilterPipeline(new List<IFilterDocument>());

        // Act
        var result = sut.FilterDocument(document);

        // Assert
        result.Should().Be(document);
    }
}