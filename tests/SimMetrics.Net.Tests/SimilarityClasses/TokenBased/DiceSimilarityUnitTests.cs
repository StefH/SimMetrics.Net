using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using SimMetrics.Net.Metric;


namespace SimMetrics.Net.Tests.SimilarityClasses.TokenBased
{
    [TestFixture]
    public sealed class DiceSimilarityUnitTests
    {
        #region Test Data Setup
        struct TestRecord
        {
            public string NameOne;
            public string NameTwo;
            public double DiceSimilarityMatchLevel;
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
                testName.DiceSimilarityMatchLevel = Convert.ToDouble(letters[13], CultureInfo.InvariantCulture);
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

        #region DiceSimilarity Tests
        [Test]
        [Category("DiceSimilarity Test")]
        public void DiceSimilarity_ShortDescription()
        {
            Assert.AreEqual("DiceSimilarity", _myDiceSimilarity.ShortDescriptionString,
                            "Problem with DiceSimilarity test short description.");
        }

        [Test]
        [Category("DiceSimilarity Test")]
        public void DiceSimilarity_TestData()
        {
            foreach (TestRecord testRecord in _testNames)
            {
                Assert.AreEqual(testRecord.DiceSimilarityMatchLevel.ToString("F3"),
                                _myDiceSimilarity.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3"),
                                "Problem with DiceSimilarity test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        DiceSimilarity _myDiceSimilarity;

        [SetUp]
        public void SetUp()
        {
            LoadData();
            _myDiceSimilarity = new DiceSimilarity();
        }
    }
}