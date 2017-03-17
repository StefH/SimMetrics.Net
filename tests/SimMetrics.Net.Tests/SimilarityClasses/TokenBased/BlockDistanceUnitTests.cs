using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using SimMetrics.Net.Metric;


namespace SimMetrics.Net.Tests.SimilarityClasses.TokenBased
{
    [TestFixture]
    public sealed class BlockDistanceUnitTests
    {
        #region Test Data Setup
        struct TestRecord
        {
            public string NameOne;
            public string NameTwo;
            public double BlockDistanceMatchLevel;
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
                testName.BlockDistanceMatchLevel = Convert.ToDouble(letters[2], CultureInfo.InvariantCulture);
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
        [Test]
        [Category("BlockDistance Test")]
        public void BlockDistanceShortDescription()
        {
            Assert.AreEqual("BlockDistance", myBlockDistance.ShortDescriptionString,
                            "Problem with BlockDistance test short description.");
        }

        [Test]
        [Category("BlockDistance Test")]
        public void BlockDistanceTestData()
        {
            foreach (TestRecord testRecord in _testNames)
            {
                Assert.AreEqual(testRecord.BlockDistanceMatchLevel.ToString("F3"),
                                myBlockDistance.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3"),
                                "Problem with BlockDistance test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        BlockDistance myBlockDistance;

        [SetUp]
        public void SetUp()
        {
            LoadData();
            myBlockDistance = new BlockDistance();
        }
    }
}