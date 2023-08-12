
using System.Collections.Generic;
using CountIt.SharedLibrary.Ordering;
using FluentAssertions;

namespace CountIt.SharedLibrary.UnitTests;

public class QuickSortTests
{
    [Fact]
    public void TestSimpleOrderingWithIntegers()
    {
        var input = new [] {1, 2, 4, 3};


        var result = input.Sort();

        result.Should().BeEquivalentTo(new [] {1, 2, 3, 4}, o => o.WithStrictOrdering());
    }

    [Fact]
    public void TestOrderingWithIntegers_Duplicates()
    {
        var input = new [] {1, 2, 4, 3, 2, 1};


        var result = input.Sort();

        result.Should().BeEquivalentTo(new [] {1, 1, 2, 2, 3, 4}, o => o.WithStrictOrdering());
    }

    [Fact]
    public void TestOrderingWithIntegers_OnlyDuplicates()
    {
        var input = new [] {1, 1, 1};


        var result = input.Sort();

        result.Should().BeEquivalentTo(new [] {1, 1, 1}, o => o.WithStrictOrdering());
    }

    [Fact]
    public void TestOrderingWithText()
    {
        var input = new [] {"C", "a", "b"};

        var result = input.Sort();

        result.Should().BeEquivalentTo(new []{"a", "b", "C"}, o => o.WithStrictOrdering());
    }

    [Fact]
    public void EmptyInput_ReturnsEmptyInput()
    {
        var input = new List<int>();

        var result = QuickSort.Sort(input);

        result.Should().BeEmpty();
    }
}