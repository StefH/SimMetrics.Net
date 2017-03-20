using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;
using SimMetrics.Net.Metric;
using SimMetrics.Net.Utilities;

namespace SimMetrics.Net.Tests.SimilarityClasses.EditDistance
{
    // [TestFixture]
    public sealed class SmithWatermanUnitTests
    {
        #region Test Data Setup
        struct SwTestRecord
        {
            public string NameOne;
            public string NameTwo;
            public double SwDefault;
            public double SwCost;
            public double SwCostFunction;
            public double SwCostAndCostFunction;
        }

        struct SwgTestRecord
        {
            public string NameOne;
            public string NameTwo;
            public double SwgDefault;
            public double SwgGapCostFunction;
            public double SwgCostFunction;
            public double SwgGapCostAndCostFunctions;
        }

        struct SwgaTestRecord
        {
            public string NameOne;
            public string NameTwo;
            public double SwgaDefault;
            public double SwgaWindowSize;
            public double SwgaGapCostFunction;
            public double SwgaGapCostFunctionAndWindowSize;
            public double SwgaGapCostAndCostFunctions;
            public double SwgaGapCostAndCostFunctionsAndWindowSize;
            public double SwgaCostFunction;
            public double SwgaCostFunctionAndWindowSize;
        }

        readonly Settings _addressSettings = Settings.Default;
        readonly List<SwTestRecord> _swTestNames = new List<SwTestRecord>(26);
        readonly List<SwgTestRecord> _swgTestNames = new List<SwgTestRecord>(26);
        readonly List<SwgaTestRecord> _swgaTestNames = new List<SwgaTestRecord>(26);

        void SwAddNames(string addChars)
        {
            if (addChars != null)
            {
                string[] letters = addChars.Split(',');
                SwTestRecord testName;
                testName.NameOne = letters[0];
                testName.NameTwo = letters[1];
                testName.SwDefault = Convert.ToDouble(letters[2], CultureInfo.InvariantCulture);
                testName.SwCost = Convert.ToDouble(letters[3], CultureInfo.InvariantCulture);
                testName.SwCostFunction = Convert.ToDouble(letters[4], CultureInfo.InvariantCulture);
                testName.SwCostAndCostFunction = Convert.ToDouble(letters[5], CultureInfo.InvariantCulture);
                _swTestNames.Add(testName);
            }
        }

        void SwgAddNames(string addChars)
        {
            if (addChars != null)
            {
                string[] letters = addChars.Split(',');
                SwgTestRecord testName;
                testName.NameOne = letters[0];
                testName.NameTwo = letters[1];
                testName.SwgDefault = Convert.ToDouble(letters[2], CultureInfo.InvariantCulture);
                testName.SwgGapCostFunction = Convert.ToDouble(letters[3], CultureInfo.InvariantCulture);
                testName.SwgCostFunction = Convert.ToDouble(letters[4], CultureInfo.InvariantCulture);
                testName.SwgGapCostAndCostFunctions = Convert.ToDouble(letters[5], CultureInfo.InvariantCulture);
                _swgTestNames.Add(testName);
            }
        }

        void SwgaAddNames(string addChars)
        {
            if (addChars != null)
            {
                string[] letters = addChars.Split(',');
                SwgaTestRecord testName;
                testName.NameOne = letters[0];
                testName.NameTwo = letters[1];
                testName.SwgaDefault = Convert.ToDouble(letters[2], CultureInfo.InvariantCulture);
                testName.SwgaWindowSize = Convert.ToDouble(letters[3], CultureInfo.InvariantCulture);
                testName.SwgaGapCostFunction = Convert.ToDouble(letters[4], CultureInfo.InvariantCulture);
                testName.SwgaGapCostFunctionAndWindowSize = Convert.ToDouble(letters[5], CultureInfo.InvariantCulture);
                testName.SwgaGapCostAndCostFunctions = Convert.ToDouble(letters[6], CultureInfo.InvariantCulture);
                testName.SwgaGapCostAndCostFunctionsAndWindowSize = Convert.ToDouble(letters[7], CultureInfo.InvariantCulture);
                testName.SwgaCostFunction = Convert.ToDouble(letters[8], CultureInfo.InvariantCulture);
                testName.SwgaCostFunctionAndWindowSize = Convert.ToDouble(letters[9], CultureInfo.InvariantCulture);
                _swgaTestNames.Add(testName);
            }
        }

        void LoadData()
        {
            SwAddNames(_addressSettings.swName1);
            SwAddNames(_addressSettings.swName2);
            SwAddNames(_addressSettings.swName3);
            SwAddNames(_addressSettings.swName4);
            SwAddNames(_addressSettings.swName5);
            SwAddNames(_addressSettings.swName6);
            SwAddNames(_addressSettings.swName7);

            SwgAddNames(_addressSettings.swgName1);
            SwgAddNames(_addressSettings.swgName2);
            SwgAddNames(_addressSettings.swgName3);
            SwgAddNames(_addressSettings.swgName4);
            SwgAddNames(_addressSettings.swgName5);
            SwgAddNames(_addressSettings.swgName6);
            SwgAddNames(_addressSettings.swgName7);

            SwgaAddNames(_addressSettings.swgaName1);
            SwgaAddNames(_addressSettings.swgaName2);
            SwgaAddNames(_addressSettings.swgaName3);
            SwgaAddNames(_addressSettings.swgaName4);
            SwgaAddNames(_addressSettings.swgaName5);
            SwgaAddNames(_addressSettings.swgaName6);
            SwgaAddNames(_addressSettings.swgaName7);
            SwgaAddNames(_addressSettings.swgaName8);
        }
        #endregion

        #region SmithWaterman Tests
        [Fact]
        // [Category("SmithWaterman")]
        public void SmithWatermanShortDescription()
        {
            AssertUtil.Equal(_mySmithWatermanDefault.ShortDescriptionString, "SmithWaterman",
                            "Problem with SmithWaterman test ShortDescription");
        }

        [Fact]
        // [Category("SmithWaterman")]
        public void SmithWatermanDefaultTestData()
        {
            foreach (SwTestRecord testRecord in _swTestNames)
            {
                AssertUtil.Equal(testRecord.SwDefault.ToString("F3"),
                                _mySmithWatermanDefault.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3"),
                                "Problem with SmithWaterman test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }

        [Fact]
        // [Category("SmithWaterman")]
        public void SmithWatermanCostTestData()
        {
            foreach (SwTestRecord testRecord in _swTestNames)
            {
                AssertUtil.Equal(testRecord.SwDefault.ToString("F3"),
                                _mySmithWatermanCost.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3"),
                                "Problem with SmithWaterman test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }

        [Fact]
        // [Category("SmithWaterman")]
        public void SmithWatermanCostFunctionTestData()
        {
            foreach (SwTestRecord testRecord in _swTestNames)
            {
                AssertUtil.Equal(testRecord.SwDefault.ToString("F3"),
                                _mySmithWatermanCostFunction.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3"),
                                "Problem with SmithWaterman test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }

        [Fact]
        // [Category("SmithWaterman")]
        public void SmithWatermanCostAndCostFunctionTestData()
        {
            foreach (SwTestRecord testRecord in _swTestNames)
            {
                AssertUtil.Equal(testRecord.SwDefault.ToString("F3"),
                                _mySmithWatermanCostAndCostFunction.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).
                                    ToString("F3"),
                                "Problem with SmithWaterman test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        #region SmithWatermanGotoh tests
        [Fact]
        // [Category("SmithWatermanGotoh")]
        public void SmithWatermanGotohShortDescription()
        {
            AssertUtil.Equal(_mySmithWatermanGotohDefault.ShortDescriptionString, "SmithWatermanGotoh",
                            "Problem with SmithWaterman test ShortDescription");
        }

        [Fact]
        // [Category("SmithWatermanGotoh")]
        public void SmithWatermanGotohDefaultTestData()
        {
            foreach (SwgTestRecord testRecord in _swgTestNames)
            {
                AssertUtil.Equal(testRecord.SwgDefault.ToString("F3"),
                                _mySmithWatermanGotohDefault.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3"),
                                "Problem with SmithWatermanGotoh test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }

        [Fact]
        // [Category("SmithWatermanGotoh")]
        public void SmithWatermanGotoGapCostFunctionTestData()
        {
            foreach (SwgTestRecord testRecord in _swgTestNames)
            {
                AssertUtil.Equal(testRecord.SwgGapCostFunction.ToString("F3"),
                                _mySmithWatermanGotohGapCostFunction.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).
                                    ToString("F3"),
                                "Problem with SmithWatermanGotoh test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }

        [Fact]
        // [Category("SmithWatermanGotoh")]
        public void SmithWatermanGotoCostFunctionTestData()
        {
            foreach (SwgTestRecord testRecord in _swgTestNames)
            {
                AssertUtil.Equal(testRecord.SwgCostFunction.ToString("F3"),
                                _mySmithWatermanGotohCostFunction.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString(
                                    "F3"),
                                "Problem with SmithWatermanGotoh test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }

        [Fact]
        // [Category("SmithWatermanGotoh")]
        public void SmithWatermanGotoGapCostAndCostFunctionsTestData()
        {
            foreach (SwgTestRecord testRecord in _swgTestNames)
            {
                AssertUtil.Equal(testRecord.SwgGapCostAndCostFunctions.ToString("F3"),
                                _mySmithWatermanGotohGapCostAndCostFunctions.GetSimilarity(testRecord.NameOne, testRecord.NameTwo)
                                    .ToString("F3"),
                                "Problem with SmithWatermanGotoh test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        #region SmithWatermanGotohWindowedAffine tests
        [Fact]
        // [Category("SWGWA")]
        public void SwgwaShortDescription()
        {
            AssertUtil.Equal(_mySwgwaDefault.ShortDescriptionString, "SmithWatermanGotohWindowedAffine",
                            "Problem with SmithWaterman test ShortDescription");
        }

        [Fact]
        // [Category("SWGWA")]
        public void SwgwaDefaultTestData()
        {
            foreach (SwgaTestRecord testRecord in _swgaTestNames)
            {
                AssertUtil.Equal(testRecord.SwgaDefault.ToString("F3"),
                                _mySwgwaDefault.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3"),
                                "Problem with SWGWA test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }

        [Fact]
        // [Category("SWGWA")]
        public void SwgwaWindowSizeTestData()
        {
            foreach (SwgaTestRecord testRecord in _swgaTestNames)
            {
                AssertUtil.Equal(testRecord.SwgaWindowSize.ToString("F3"),
                                _mySwgwaWindowSize.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3"),
                                "Problem with SWGWA test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }

        [Fact]
        // [Category("SWGWA")]
        public void SwgwaGapCostFunctionTestData()
        {
            foreach (SwgaTestRecord testRecord in _swgaTestNames)
            {
                AssertUtil.Equal(testRecord.SwgaGapCostFunction.ToString("F3"),
                                _mySwgwaGapCostFunction.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3"),
                                "Problem with SWGWA test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }

        [Fact]
        // [Category("SWGWA")]
        public void SwgwaGapCostFunctionAndWindowSizeTestData()
        {
            foreach (SwgaTestRecord testRecord in _swgaTestNames)
            {
                AssertUtil.Equal(testRecord.SwgaGapCostFunctionAndWindowSize.ToString("F3"),
                                _mySwgwaGapCostFunctionAndWindowSize.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).
                                    ToString("F3"), "Problem with SWGWA test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }

        [Fact]
        // [Category("SWGWA")]
        public void SwgwaGapCostAndCostFunctionsTestData()
        {
            foreach (SwgaTestRecord testRecord in _swgaTestNames)
            {
                AssertUtil.Equal(testRecord.SwgaGapCostAndCostFunctions.ToString("F3"),
                                _mySwgwaGapCostAndCostFunctions.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString(
                                    "F3"), "Problem with SWGWA test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }

        [Fact]
        // [Category("SWGWA")]
        public void SwgwaGapCostAndCostFunctionsAndWindowSizeTestData()
        {
            foreach (SwgaTestRecord testRecord in _swgaTestNames)
            {
                AssertUtil.Equal(testRecord.SwgaGapCostAndCostFunctionsAndWindowSize.ToString("F3"),
                                _mySwgwaGapCostAndCostFunctionsAndWindowSize.GetSimilarity(testRecord.NameOne, testRecord.NameTwo)
                                    .ToString("F3"),
                                "Problem with SWGWA test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }

        [Fact]
        // [Category("SWGWA")]
        public void SwgwaCostFunctionTestData()
        {
            foreach (SwgaTestRecord testRecord in _swgaTestNames)
            {
                AssertUtil.Equal(testRecord.SwgaCostFunction.ToString("F3"),
                                _mySwgwaCostFunction.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3"),
                                "Problem with SWGWA test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }

        [Fact]
        // [Category("SWGWA")]
        public void SwgwaCostFunctionAndWindowSizeTestData()
        {
            foreach (SwgaTestRecord testRecord in _swgaTestNames)
            {
                AssertUtil.Equal(testRecord.SwgaCostFunctionAndWindowSize.ToString("F3"),
                                _mySwgwaCostFunctionAndWindowSize.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString(
                                    "F3"), "Problem with SWGWA test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        #region private fields
        SmithWaterman _mySmithWatermanDefault;
        SmithWaterman _mySmithWatermanCost;
        SmithWaterman _mySmithWatermanCostFunction;
        SmithWaterman _mySmithWatermanCostAndCostFunction;

        SmithWatermanGotoh _mySmithWatermanGotohDefault;
        SmithWatermanGotoh _mySmithWatermanGotohGapCostFunction;
        SmithWatermanGotoh _mySmithWatermanGotohCostFunction;
        SmithWatermanGotoh _mySmithWatermanGotohGapCostAndCostFunctions;

        SmithWatermanGotohWindowedAffine _mySwgwaDefault;
        SmithWatermanGotohWindowedAffine _mySwgwaWindowSize;
        SmithWatermanGotohWindowedAffine _mySwgwaGapCostFunction;
        SmithWatermanGotohWindowedAffine _mySwgwaGapCostFunctionAndWindowSize;
        SmithWatermanGotohWindowedAffine _mySwgwaGapCostAndCostFunctions;
        SmithWatermanGotohWindowedAffine _mySwgwaGapCostAndCostFunctionsAndWindowSize;
        SmithWatermanGotohWindowedAffine _mySwgwaCostFunction;
        SmithWatermanGotohWindowedAffine _mySwgwaCostFunctionAndWindowSize;
        #endregion

        // [SetUp]
        public SmithWatermanUnitTests()
        {
            LoadData();

            # region SmithWaterman classes
            // 0.5F and SubCostRange1ToMinus2 are the values used for the default constructor
            _mySmithWatermanDefault = new SmithWaterman();
            _mySmithWatermanCost = new SmithWaterman(0.5D);
            _mySmithWatermanCostFunction = new SmithWaterman(new SubCostRange1ToMinus2());
            _mySmithWatermanCostAndCostFunction = new SmithWaterman(0.5D, new SubCostRange1ToMinus2());
            #endregion

            // we also need to check running a different set of tests

            #region SmithWatermanGotoh classes
            _mySmithWatermanGotohDefault = new SmithWatermanGotoh();
            _mySmithWatermanGotohGapCostFunction = new SmithWatermanGotoh(new AffineGapRange5To0Multiplier1());
            _mySmithWatermanGotohCostFunction = new SmithWatermanGotoh(new SubCostRange5ToMinus3());
            _mySmithWatermanGotohGapCostAndCostFunctions =
                new SmithWatermanGotoh(new AffineGapRange5To0Multiplier1(), new SubCostRange5ToMinus3());
            #endregion

            #region SmithWatermanGotohWindowedAffine classes
            _mySwgwaDefault = new SmithWatermanGotohWindowedAffine();
            _mySwgwaWindowSize = new SmithWatermanGotohWindowedAffine(100);
            _mySwgwaGapCostFunction = new SmithWatermanGotohWindowedAffine(new AffineGapRange5To0Multiplier1());
            _mySwgwaGapCostFunctionAndWindowSize = new SmithWatermanGotohWindowedAffine(new AffineGapRange5To0Multiplier1(), 100);
            _mySwgwaGapCostAndCostFunctions =
                new SmithWatermanGotohWindowedAffine(new AffineGapRange5To0Multiplier1(), new SubCostRange5ToMinus3());
            _mySwgwaGapCostAndCostFunctionsAndWindowSize =
                new SmithWatermanGotohWindowedAffine(new AffineGapRange5To0Multiplier1(), new SubCostRange5ToMinus3(), 100);
            _mySwgwaCostFunction = new SmithWatermanGotohWindowedAffine(new SubCostRange5ToMinus3());
            _mySwgwaCostFunctionAndWindowSize = new SmithWatermanGotohWindowedAffine(new SubCostRange5ToMinus3(), 100);
            #endregion
        }
    }
}