using Xunit;
using SimMetrics.Net.Utilities;

namespace SimMetrics.Net.Tests.UtilityClasses
{
    // [TestFixture]
    public sealed class MathFuncsUnitTests
    {
        #region MathFuncs Tests
        [Fact]
        // [Category("MathFuncs Test")]
        public void MathFuncsMinOf3()
        {
            AssertUtil.Equal(1, MathFunctions.MinOf3(1, 2, 3), "Problem with MathFuncs MinOf3 int.");
            AssertUtil.Equal(1.0, MathFunctions.MinOf3(1.0, 2.0, 3.0), "Problem with MathFuncs MinOf3 double.");
        }

        [Fact]
        // [Category("MathFuncs Test")]
        public void MathFuncsMaxOf3()
        {
            AssertUtil.Equal(3, MathFunctions.MaxOf3(1, 2, 3), "Problem with MathFuncs MaxOf3 int.");
            AssertUtil.Equal(3.0, MathFunctions.MaxOf3(1.0, 2.0, 3.0), "Problem with MathFuncs MaxOf3 double.");
        }

        [Fact]
        // [Category("MathFuncs Test")]
        public void MathFuncsMaxOf4()
        {
            AssertUtil.Equal(4, MathFunctions.MaxOf4(1, 2, 3, 4), "Problem with MathFuncs MaxOf4 int.");
            AssertUtil.Equal(4.0, MathFunctions.MaxOf4(1.0, 2.0, 3.0, 4.0), "Problem with MathFuncs MaxOf4 double.");
        }
        #endregion

        // [SetUp]
        public MathFuncsUnitTests() { }
    }
}