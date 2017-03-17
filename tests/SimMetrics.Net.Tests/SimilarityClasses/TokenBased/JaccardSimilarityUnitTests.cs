using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using SimMetrics.Net.Metric;


namespace SimMetrics.Net.Tests.SimilarityClasses.TokenBased
{
    [TestFixture]
    public sealed class JaccardSimilarityUnitTests
    {
        #region Test Data Setup
        struct TestRecord
        {
            public string NameOne;
            public string NameTwo;
            public double JaccardSimilarityMatchLevel;
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
                testName.JaccardSimilarityMatchLevel = Convert.ToDouble(letters[15], CultureInfo.InvariantCulture);
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

        #region JaccardSimilarity Tests
        [Test]
        [Category("JaccardSimilarity Test")]
        public void JaccardSimilarity_ShortDescription()
        {
            Assert.AreEqual("JaccardSimilarity", _myJaccardSimilarity.ShortDescriptionString,
                            "Problem with JaccardSimilarity test short description.");
        }

        [Test]
        [Category("JaccardSimilarity Test")]
        public void JaccardSimilarity_TestData()
        {
            foreach (TestRecord testRecord in _testNames)
            {
                Assert.AreEqual(testRecord.JaccardSimilarityMatchLevel.ToString("F3"),
                                _myJaccardSimilarity.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3"),
                                "Problem with JaccardSimilarity test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        JaccardSimilarity _myJaccardSimilarity;

        [SetUp]
        public void SetUp()
        {
            LoadData();
            _myJaccardSimilarity = new JaccardSimilarity();
        }
    }
}