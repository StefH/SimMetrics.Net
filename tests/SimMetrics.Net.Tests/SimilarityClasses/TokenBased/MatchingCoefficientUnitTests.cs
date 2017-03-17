using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using SimMetrics.Net.Metric;

namespace SimMetrics.Net.Tests.SimilarityClasses.TokenBased
{
    [TestFixture]
    public sealed class MatchingCoefficientUnitTests
    {
        #region Test Data Setup
        struct TestRecord
        {
            public string NameOne;
            public string NameTwo;
            public double MatchingCoefficientMatchLevel;
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
                testName.MatchingCoefficientMatchLevel = Convert.ToDouble(letters[16], CultureInfo.InvariantCulture);
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

        #region MatchingCoefficient Tests
        [Test]
        [Category("MatchingCoefficient Test")]
        public void MatchingCoefficient_ShortDescription()
        {
            Assert.AreEqual("MatchingCoefficient", _myMatchingCoefficient.ShortDescriptionString,
                            "Problem with MatchingCoefficient test short description.");
        }

        [Test]
        [Category("MatchingCoefficient Test")]
        public void MatchingCoefficient_TestData()
        {
            foreach (TestRecord testRecord in _testNames)
            {
                Assert.AreEqual(testRecord.MatchingCoefficientMatchLevel.ToString("F3"),
                                _myMatchingCoefficient.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3"),
                                "Problem with MatchingCoefficient test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        MatchingCoefficient _myMatchingCoefficient;

        [SetUp]
        public void SetUp()
        {
            LoadData();
            _myMatchingCoefficient = new MatchingCoefficient();
        }
    }
}