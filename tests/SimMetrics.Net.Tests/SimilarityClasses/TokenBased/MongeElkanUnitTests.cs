using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;
using SimMetrics.Net.Metric;

namespace SimMetrics.Net.Tests.SimilarityClasses.TokenBased
{
    // [TestFixture]
    public sealed class MongeElkanUnitTests
    {
        #region Test Data Setup
        struct TestRecord
        {
            public string NameOne;
            public string NameTwo;
            public double MongeElkanMatchLevel;
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
                testName.MongeElkanMatchLevel = Convert.ToDouble(letters[17], CultureInfo.InvariantCulture);
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

        #region MongeElkan Tests
        [Fact]
        // [Category("MongeElkan Test")]
        public void MongeElkan_ShortDescription()
        {
            AssertUtil.Equal("MongeElkan", _myMongeElkan.ShortDescriptionString, "Problem with MongeElkan test short description.");
        }

        [Fact]
        // [Category("MongeElkan Test")]
        public void MongeElkan_TestData()
        {
            foreach (TestRecord testRecord in _testNames)
            {
                AssertUtil.Equal(testRecord.MongeElkanMatchLevel.ToString("F3"),
                                _myMongeElkan.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3"),
                                "Problem with MongeElkan test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        MongeElkan _myMongeElkan;

        //[SetUp]
        public MongeElkanUnitTests()
        {
            LoadData();
            _myMongeElkan = new MongeElkan();
        }
    }
}