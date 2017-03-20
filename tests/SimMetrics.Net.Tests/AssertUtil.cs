using Xunit;

namespace SimMetrics.Net.Tests
{
    internal static class AssertUtil
    {
        public static void Equal<T>(T expected, T actual)
        {
            Assert.Equal(expected, actual);
        }

        public static void Equal<T>(T expected, T actual, string message)
        {
            Assert.True(expected.Equals(actual), message);
        }
    }
}