using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using SimMetrics.Net.Metric;

namespace SimMetrics.Net.Tests.SimilarityClasses.JaroandJaroWinkler
{
    [TestFixture]
    public sealed class JaroAndJaroWinklerUnitTests
    {
        #region Test Data Setup
        /// Test Data is taken from
        /// Approximate string Comparison and its Effect on an Advanced Record Linkage System
        /// Porter and Winkler 1997
        /// Chapter 6.
        struct TestRecord
        {
            public string NameOne;
            public string NameTwo;
            public double JaroMatchLevel;
            public double JaroWinklerMatchLevel;
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
                testName.JaroMatchLevel = Convert.ToDouble(letters[2], CultureInfo.InvariantCulture);
                testName.JaroWinklerMatchLevel = Convert.ToDouble(letters[3], CultureInfo.InvariantCulture);
                _testNames.Add(testName);
            }
        }

        void LoadData()
        {
            AddNames(_addressSettings.jaroName1);
            AddNames(_addressSettings.jaroName2);
            AddNames(_addressSettings.jaroName3);
            AddNames(_addressSettings.jaroName4);
            AddNames(_addressSettings.jaroName5);
            AddNames(_addressSettings.jaroName6);
            AddNames(_addressSettings.jaroName7);
        }
        #endregion

        #region Jaro Tests
        [Test]
        [Category("Jaro Test")]
        public void JaroShortDescription()
        {
            //myJaro.
            Assert.AreEqual(_myJaro.ShortDescriptionString, "Jaro", "Problem with Jaro test ShortDescription");
        }

        [Test]
        [Category("Jaro Test")]
        public void JaroTestData()
        {
            foreach (TestRecord testRecord in _testNames)
            {
                Assert.AreEqual(testRecord.JaroMatchLevel.ToString("F3"),
                                _myJaro.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3"),
                                "Problem with Jaro test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        #region JaroWinkler tests
        [Test]
        [Category("JaroWinkler Test")]
        public void JaroWinklerShortDescription()
        {
            Assert.AreEqual(_myJaroWinkler.ShortDescriptionString, "JaroWinkler", "Problem with Jaro test ShortDescription");
        }

        [Test]
        [Category("JaroWinkler Test")]
        public void JaroWinklerTestData()
        {
            foreach (TestRecord testRecord in _testNames)
            {
                Assert.AreEqual(testRecord.JaroWinklerMatchLevel.ToString("F3"),
                                _myJaroWinkler.GetSimilarity(testRecord.NameOne, testRecord.NameTwo).ToString("F3"),
                                "Problem with JaroWinkler test - " + testRecord.NameOne + ' ' + testRecord.NameTwo);
            }
        }
        #endregion

        Jaro _myJaro;
        JaroWinkler _myJaroWinkler;

        [SetUp]
        public void SetUp()
        {
            LoadData();
            _myJaro = new Jaro();
            _myJaroWinkler = new JaroWinkler();
        }
    }
}