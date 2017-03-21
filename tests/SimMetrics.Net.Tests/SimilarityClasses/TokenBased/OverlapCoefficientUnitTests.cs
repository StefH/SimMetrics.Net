using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;
using SimMetrics.Net.Metric;

namespace SimMetrics.Net.Tests.SimilarityClasses.TokenBased
{
    // [TestFixture]
    public sealed class OverlapCoefficientUnitTests
    {
        #region Test Data Setup
        struct TestRecord
        {
            public string NameOne;
            public string NameTwo;
            public double OverlapCoefficientMatchLevel;
        }

        readonly Settings _addressSettings = Settings.Default;
        readonly List<TestRecord> _testNames = new List<TestRecord>(26);

        void AddNames(string addChars)
        {
            if (addChars != null)
            {
                string[] letters = addChars.Split(',');
                TestRecord testName;
                testName.NameOne = letters[0];
                testName.NameTwo = letters[1];
                testName.OverlapCoefficientMatchLevel = Convert.ToDouble(letters[18], CultureInfo.InvariantCulture);
                _testNames.Add(testName);
            }
        }

        void LoadData()
        {
            AddNames(_addressSettings.blockDistance1);
            AddNames(_addressSettings.blockDistance2);
            AddNames(_addressSettings.blockDistance3);
        }
        #endregion

        #region OverlapCoefficient Tests
        [Fact]
        // [Category("OverlapCoefficient Test")]
        public void OverlapCoefficient_ShortDescription()
        {
            AssertUtil.Equal("OverlapCoefficient", _myOverlapCoefficient.ShortDescriptionString,
                            "Problem with OverlapCoefficient test short description.");
        }

        [Fact]
        // [Category("OverlapCoefficient Test")]
        public void OverlapCoefficient_TestData()
        {
            foreach (TestRecord testRecord in _testNames)
            {
                AssertUtil.Equal(testRecord.OverlapCoefficientMatchLevel.ToString("F3"),
                                _myOverlapCoefficient.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3"),
                                "Problem with OverlapCoefficient test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        OverlapCoefficient _myOverlapCoefficient;

        // [SetUp]
        public OverlapCoefficientUnitTests()
        {
            LoadData();
            _myOverlapCoefficient = new OverlapCoefficient();
        }
    }
}