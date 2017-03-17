using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using SimMetrics.Net.Metric;

namespace SimMetrics.Net.Tests.SimilarityClasses.TokenBased
{
    [TestFixture]
    public sealed class EuclideanDistanceUnitTests
    {
        #region Test Data Setup
        struct TestRecord
        {
            public string NameOne;
            public string NameTwo;
            public double EuclideanDistanceMatchLevel;
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
                testName.EuclideanDistanceMatchLevel = Convert.ToDouble(letters[14], CultureInfo.InvariantCulture);
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

        #region EuclideanDistance Tests
        [Test]
        [Category("EuclideanDistance Test")]
        public void EuclideanDistance_ShortDescription()
        {
            Assert.AreEqual("EuclideanDistance", _myEuclideanDistance.ShortDescriptionString,
                            "Problem with EuclideanDistance test short description.");
        }

        [Test]
        [Category("EuclideanDistance Test")]
        public void EuclideanDistance_TestData()
        {
            foreach (TestRecord testRecord in _testNames)
            {
                Assert.AreEqual(testRecord.EuclideanDistanceMatchLevel.ToString("F3"),
                                _myEuclideanDistance.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3"),
                                "Problem with EuclideanDistance test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        EuclideanDistance _myEuclideanDistance;

        [SetUp]
        public void SetUp()
        {
            LoadData();
            _myEuclideanDistance = new EuclideanDistance();
        }
    }
}