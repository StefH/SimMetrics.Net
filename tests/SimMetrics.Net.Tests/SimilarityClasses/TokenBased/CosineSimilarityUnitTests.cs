using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;
using SimMetrics.Net.Metric;


namespace SimMetrics.Net.Tests.SimilarityClasses.TokenBased
{
    // [TestFixture]
    public sealed class CosineSimilarityUnitTests
    {
        #region Test Data Setup
        struct TestRecord
        {
            public string NameOne;
            public string NameTwo;
            public double CosineSimilarityMatchLevel;
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
                testName.CosineSimilarityMatchLevel = Convert.ToDouble(letters[6], CultureInfo.InvariantCulture);
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

        #region Block Distance Tests
        [Fact]
        // [Category("CosineSimilarity Test")]
        public void CosineSimilarityShortDescription()
        {
            AssertUtil.Equal("CosineSimilarity", _myCosineSimilarity.ShortDescriptionString,
                            "Problem with CosineSimilarity test short description.");
        }

        [Fact]
        // [Category("CosineSimilarity Test")]
        public void CosineSimilarityTestData()
        {
            foreach (TestRecord testRecord in _testNames)
            {
                AssertUtil.Equal(testRecord.CosineSimilarityMatchLevel.ToString("F3"),
                                _myCosineSimilarity.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3"),
                                string.Format("{0}CosineSimilarity{1}{2}{3}{4}", Environment.NewLine, Environment.NewLine,
                                              testRecord.NameOne, Environment.NewLine, testRecord.NameTwo));
            }
        }
        #endregion

        CosineSimilarity _myCosineSimilarity;

        // [SetUp]
        public CosineSimilarityUnitTests()
        {
            LoadData();
            _myCosineSimilarity = new CosineSimilarity();
        }
    }
}