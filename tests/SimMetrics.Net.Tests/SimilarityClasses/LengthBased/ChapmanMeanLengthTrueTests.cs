using SimMetrics.Net.Metric;
using Xunit;

namespace SimMetrics.Net.Tests.SimilarityClasses.LengthBased;

public sealed class ChapmanMeanLengthTrueTests
{
    private readonly ChapmanMeanLengthTrue _sut = new();

    [Theory]
    [InlineData("Davdi", 0.800000)]
    [InlineData("david", 0.800000)]
    [InlineData("David", 1.000000)]
    [InlineData("Maday", 0.400000)]
    [InlineData("Daves", 0.600000)]
    [InlineData("divaD", 0.200000)]
    [InlineData("Dave", 0.666667)]
    [InlineData("Dovid", 0.800000)]
    [InlineData("Dadiv", 0.600000)]
    [InlineData("Da.v.id", 0.833333)]
    [InlineData("Dav id", 0.909091)]
    [InlineData("12345", 0.000000)]
    [InlineData("Divad", 0.600000)]
    [InlineData("D-avid", 0.909091)]
    [InlineData("xxxxx", 0.000000)]
    public void GetSimilarity(string test, double expected)
    {
        var result = _sut.GetSimilarity("David", test);
        
        Assert.Equal(expected, result, 5);
    }
}