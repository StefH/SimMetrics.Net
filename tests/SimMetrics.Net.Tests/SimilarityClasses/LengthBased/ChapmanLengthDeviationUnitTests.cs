using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using SimMetrics.Net.Metric;

namespace SimMetrics.Net.Tests.SimilarityClasses.LengthBased
{
    [TestFixture]
    public sealed class ChapmanLengthDeviationUnitTests
    {
        #region Test Data Setup
        struct TestRecord
        {
            public string NameOne;
            public string NameTwo;
            public double ChapmanLengthMatchLevel;
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
                testName.ChapmanLengthMatchLevel = Convert.ToDouble(letters[4], CultureInfo.InvariantCulture);
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

        #region Chapman Deviation Tests
        [Test]
        [Category("Chapman Length Deviation Test")]
        public void ChapmanLengthDeviation_ShortDescription()
        {
            Assert.AreEqual("ChapmanLengthDeviation", myChapmanLengthDeviation.ShortDescriptionString,
                            "Problem with Chapman Length Deviation test short description.");
        }

        [Test]
        [Category("Chapman Length Deviation Test")]
        public void ChapmanLengthDeviation_TestData()
        {
            foreach (TestRecord testRecord in _testNames)
            {
                Assert.AreEqual(testRecord.ChapmanLengthMatchLevel.ToString("F3"),
                                myChapmanLengthDeviation.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3"),
                                "Problem with Chapman Length Deviation test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        ChapmanLengthDeviation myChapmanLengthDeviation;

        [SetUp]
        public void SetUp()
        {
            LoadData();
            myChapmanLengthDeviation = new ChapmanLengthDeviation();
        }
    }
}