using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;
using SimMetrics.Net.Metric;


namespace SimMetrics.Net.Tests.SimilarityClasses.EditDistance
{
    // [TestFixture]
    public sealed class NeedlemanWunchUnitTests
    {
        #region Test Data Setup
        struct TestRecord
        {
            public string NameOne;
            public string NameTwo;
            public double NeedlemanWunchMatchLevel;
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
                testName.NeedlemanWunchMatchLevel = Convert.ToDouble(letters[11], CultureInfo.InvariantCulture);
                _testNames.Add(testName);
            }
        }

        void LoadData()
        {
            AddNames(_addressSettings.blockDistance1);
            AddNames(_addressSettings.blockDistance2);
            AddNames(_addressSettings.blockDistance3);
            AddNames(_addressSettings.jaroName1);
            AddNames(_addressSettings.jaroName2);
            AddNames(_addressSettings.jaroName3);
            AddNames(_addressSettings.jaroName4);
            AddNames(_addressSettings.jaroName5);
            AddNames(_addressSettings.jaroName6);
            AddNames(_addressSettings.jaroName7);
        }
        #endregion

        #region NeedlemanWunch Tests
        [Fact]
        // [Category("NeedlemanWunch Test")]
        public void NeedlemanWunch_ShortDescription()
        {
            AssertUtil.Equal("NeedlemanWunch", _myNeedlemanWunch.ShortDescriptionString,
                            "Problem with NeedlemanWunch test short description.");
        }

        [Fact]
        // [Category("NeedlemanWunch Test")]
        public void NeedlemanWunch_TestData()
        {
            foreach (TestRecord testRecord in _testNames)
            {
                AssertUtil.Equal(testRecord.NeedlemanWunchMatchLevel.ToString("F3"),
                                _myNeedlemanWunch.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3"),
                                "Problem with NeedlemanWunch test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        NeedlemanWunch _myNeedlemanWunch;

        // [SetUp]
        public NeedlemanWunchUnitTests()
        {
            LoadData();
            _myNeedlemanWunch = new NeedlemanWunch();
        }
    }
}