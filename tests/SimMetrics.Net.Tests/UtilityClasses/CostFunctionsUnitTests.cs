using NFluent;
using Xunit;
using SimMetrics.Net.Utilities;

namespace SimMetrics.Net.Tests.UtilityClasses
{
    // [TestFixture]
    public sealed class CostFunctionsUnitTests
    {
        private const double Delta = 0.001;

        #region AffineGapRange1To0Multiplier1Over3 Tests
        [Fact]
        // [Category("AffineGapRange1To0Multiplier1Over3 Test")]
        public void AffineGapRange1To0Multiplier1Over3ShortDescription()
        {
            AssertUtil.Equal("AffineGapRange1To0Multiplier1Over3", myCostFunction1.ShortDescriptionString,
                            "Problem with AffineGapRange1To0Multiplier1Over3 test short description.");
        }

        [Fact]
        // [Category("AffineGapRange1To0Multiplier1Over3 Test")]
        public void AffineGapRange1To0Multiplier1Over3PassTest()
        {
            double result = myCostFunction1.GetCost("CHRIS", 1, 3);
            Check.That(result).IsCloseTo(1.333, Delta);
            //AssertUtil.Equal(1.333, result, "Problem with AffineGapRange1To0Multiplier1Over3 pass test.");
        }

        [Fact]
        // [Category("AffineGapRange1To0Multiplier1Over3 Test")]
        public void AffineGapRange1To0Multiplier1Over3FailTest()
        {
            double result = myCostFunction1.GetCost("CHRIS", 4, 3);
            Check.That(result).IsCloseTo(0.000, Delta);
            //AssertUtil.Equal("0.000", result.ToString("F3", CultureInfo.InvariantCulture), "Problem with AffineGapRange1To0Multiplier1Over3 fail test.");
        }
        #endregion

        #region AffineGapRange5To0Multiplier1 Tests
        [Fact]
        // [Category("AffineGapRange5To0Multiplier1 Test")]
        public void AffineGapRange5To0Multiplier1ShortDescription()
        {
            AssertUtil.Equal("AffineGapRange5To0Multiplier1", myCostFunction2.ShortDescriptionString,
                            "Problem with AffineGapRange5To0Multiplier1 test short description.");
        }

        [Fact]
        // [Category("AffineGapRange5To0Multiplier1 Test")]
        public void AffineGapRange5To0Multiplier1PassTest()
        {
            double result = myCostFunction2.GetCost("CHRIS", 1, 3);
            Check.That(result).IsCloseTo(6.000, Delta);
            //AssertUtil.Equal("6.000", result.ToString("F3"), "Problem with AffineGapRange5To0Multiplier1 pass test.");
        }

        [Fact]
        // [Category("AffineGapRange5To0Multiplier1 Test")]
        public void AffineGapRange5To0Multiplier1FailTest()
        {
            double result = myCostFunction2.GetCost("CHRIS", 4, 3);
            Check.That(result).IsCloseTo(0.000, Delta);
            //AssertUtil.Equal("0.000", result.ToString("F3"), "Problem with AffineGapRange5To0Multiplier1 fail test.");
        }
        #endregion

        #region SubCostRange0To1 Tests
        [Fact]
        // [Category("SubCostRange0To1 Test")]
        public void SubCostRange0To1ShortDescription()
        {
            AssertUtil.Equal("SubCostRange0To1", myCostFunction3.ShortDescriptionString,
                            "Problem with SubCostRange0To1 test short description.");
        }

        [Fact]
        // [Category("SubCostRange0To1 Test")]
        public void SubCostRange0To1PassTest()
        {
            double result = myCostFunction3.GetCost("CHRIS", 1, "KRIS", 3);
            Check.That(result).IsCloseTo(1.000, Delta);
            //AssertUtil.Equal("1.000", result.ToString("F3"), "Problem with SubCostRange0To1 pass test.");
        }

        [Fact]
        // [Category("SubCostRange0To1 Test")]
        public void SubCostRange0To1FailTest()
        {
            double result = myCostFunction3.GetCost("CHRIS", 4, "KRIS", 3);
            Check.That(result).IsCloseTo(0.000, Delta);
            //AssertUtil.Equal("0.000", result.ToString("F3"), "Problem with SubCostRange0To1 fail test.");
        }
        #endregion

        #region SubCostRange1ToMinus2 Tests
        [Fact]
        // [Category("SubCostRange1ToMinus2 Test")]
        public void SubCostRange1ToMinus2ShortDescription()
        {
            AssertUtil.Equal("SubCostRange1ToMinus2", myCostFunction4.ShortDescriptionString,
                            "Problem with SubCostRange1ToMinus2 test short description.");
        }

        [Fact]
        // [Category("SubCostRange1ToMinus2 Test")]
        public void SubCostRange1ToMinus2PassTest()
        {
            double result = myCostFunction4.GetCost("CHRIS", 1, "CHRIS", 1);
            Check.That(result).IsCloseTo(1.000, Delta);
            //AssertUtil.Equal("1.000", result.ToString("F3"), "Problem with SubCostRange1ToMinus2 pass test.");
        }

        [Fact]
        // [Category("SubCostRange1ToMinus2 Test")]
        public void SubCostRange1ToMinus2FailTest()
        {
            Check.That(myCostFunction4.GetCost("CHRIS", 6, "CHRIS", 3)).IsCloseTo(-2.000, Delta);
            Check.That(myCostFunction4.GetCost("CHRIS", 3, "CHRIS", 6)).IsCloseTo(-2.000, Delta);
            Check.That(myCostFunction4.GetCost("CHRIS", 1, "KRIS", 1)).IsCloseTo(-2.000, Delta);

            //// fail due to first word index greater than word length
            //AssertUtil.Equal("-2.000", myCostFunction4.GetCost("CHRIS", 6, "CHRIS", 3).ToString("F3"),
            //                "Problem with SubCostRange1ToMinus2 fail test.");
            //// fail due to second word index greater than word length
            //AssertUtil.Equal("-2.000", myCostFunction4.GetCost("CHRIS", 3, "CHRIS", 6).ToString("F3"),
            //                "Problem with SubCostRange1ToMinus2 fail test.");
            //// fail to different chars
            //AssertUtil.Equal("-2.000", myCostFunction4.GetCost("CHRIS", 1, "KRIS", 1).ToString("F3"),
            //                "Problem with SubCostRange1ToMinus2 fail test.");
        }
        #endregion

        #region SubCostRange5ToMinus3 Tests
        [Fact]
        // [Category("SubCostRange5ToMinus3 Test")]
        public void SubCostRange5ToMinus3ShortDescription()
        {
            AssertUtil.Equal("SubCostRange5ToMinus3", myCostFunction5.ShortDescriptionString,
                            "Problem with SubCostRange5ToMinus3 test short description.");
        }

        [Fact]
        // [Category("SubCostRange5ToMinus3 Test")]
        public void SubCostRange5ToMinus3PassTest()
        {
            double result = myCostFunction5.GetCost("CHRIS", 1, "CHRIS", 1);
            Check.That(result).IsCloseTo(5.000, Delta);
            //AssertUtil.Equal("5.000", result.ToString("F3"), "Problem with SubCostRange5ToMinus3 pass test.");
        }

        [Fact]
        // [Category("SubCostRange5ToMinus3 Test")]
        public void SubCostRange5ToMinus3FailTest()
        {
            Check.That(myCostFunction5.GetCost("CHRIS", 6, "CHRIS", 3)).IsCloseTo(-3.000, Delta);
            Check.That(myCostFunction5.GetCost("CHRIS", 3, "CHRIS", 6)).IsCloseTo(-3.000, Delta);
            Check.That(myCostFunction5.GetCost("CHRIS", 1, "KRIS", 1)).IsCloseTo(-3.000, Delta);

            //// fail due to first word index greater than word length
            //AssertUtil.Equal("-3.000", myCostFunction5.GetCost("CHRIS", 6, "CHRIS", 3).ToString("F3"),
            //                "Problem with SubCostRange5ToMinus3 fail test.");
            //// fail due to second word index greater than word length
            //AssertUtil.Equal("-3.000", myCostFunction5.GetCost("CHRIS", 3, "CHRIS", 6).ToString("F3"),
            //                "Problem with SubCostRange5ToMinus3 fail test.");
            //// fail to different chars
            //AssertUtil.Equal("-3.000", myCostFunction5.GetCost("CHRIS", 1, "KRIS", 1).ToString("F3"),
            //                "Problem with SubCostRange5ToMinus3 fail test.");
        }

        [Fact]
        // [Category("SubCostRange5ToMinus3 Test")]
        public void SubCostRange5ToMinus3ApproxTest()
        {
            double result = myCostFunction5.GetCost("GILL", 0, "JILL", 0);
            Check.That(result).IsCloseTo(3.000, Delta);
            //AssertUtil.Equal("3.000", myCostFunction5.GetCost("GILL", 0, "JILL", 0).ToString("F3"), "Problem with SubCostRange5ToMinus3 fail test.");
        }
        #endregion

        AffineGapRange1To0Multiplier1Over3 myCostFunction1;
        AffineGapRange5To0Multiplier1 myCostFunction2;
        SubCostRange0To1 myCostFunction3;
        SubCostRange1ToMinus2 myCostFunction4;
        SubCostRange5ToMinus3 myCostFunction5;

        // [SetUp]
        public CostFunctionsUnitTests()
        {
            myCostFunction1 = new AffineGapRange1To0Multiplier1Over3();
            myCostFunction2 = new AffineGapRange5To0Multiplier1();
            myCostFunction3 = new SubCostRange0To1();
            myCostFunction4 = new SubCostRange1ToMinus2();
            myCostFunction5 = new SubCostRange5ToMinus3();
        }
    }
}