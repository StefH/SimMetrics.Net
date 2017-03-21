using System;
using System.Collections.ObjectModel;
using Xunit;
using SimMetrics.Net.Utilities;

namespace SimMetrics.Net.Tests.UtilityClasses
{
    // [TestFixture]
    public sealed class TokenisersUnitTests
    {
        #region TokeniserQGram3 Tests
        [Fact]
        // [Category("TokeniserQGram3 Test")]
        public void TokeniserQGram3ShortDescription()
        {
            AssertUtil.Equal("TokeniserQGram3", myTokeniserQGram3.ShortDescriptionString,
                            "Problem with TokeniserQGram3 test short description.");
        }

        [Fact]
        // [Category("TokeniserQGram3Extended Test")]
        public void TokeniserQGram3ExtendedShortDescription()
        {
            AssertUtil.Equal("TokeniserQGram3Extended", myTokeniserQGram3Extended.ShortDescriptionString,
                            "Problem with TokeniserQGram3Extended test short description.");
        }

        [Fact]
        // [Category("TokeniserQGram3 Test")]
        public void TokeniserQGram3TestData()
        {
            Collection<string> myKnownResult = new Collection<string>();
            myKnownResult.Add("CHR");
            myKnownResult.Add("HRI");
            myKnownResult.Add("RIS");
            //myKnownResult.TrimExcess();
            Collection<string> myResult = myTokeniserQGram3.Tokenize("CHRIS");
            for (int i = 0; i < myKnownResult.Count; i++)
            {
                AssertUtil.Equal(myKnownResult[i], myResult[i], "Problem with TokeniserQGram3 test.");
            }
        }

        [Fact]
        // [Category("TokeniserQGram3 Test")]
        public void TokeniserQGram3ExtendedTestData()
        {
            Collection<string> myKnownResult = new Collection<string>();
            myKnownResult.Add("??C");
            myKnownResult.Add("?CH");
            myKnownResult.Add("CHR");
            myKnownResult.Add("HRI");
            myKnownResult.Add("RIS");
            myKnownResult.Add("IS#");
            myKnownResult.Add("S##");
            Collection<string> myResult = myTokeniserQGram3Extended.Tokenize("CHRIS");
            for (int i = 0; i < myKnownResult.Count; i++)
            {
                AssertUtil.Equal(myKnownResult[i], myResult[i], "Problem with TokeniserQGram3Extended test.");
            }
        }
        #endregion

        #region TokeniserQGram2 Tests
        [Fact]
        // [Category("TokeniserQGram2 Test")]
        public void TokeniserQGram2ShortDescription()
        {
            AssertUtil.Equal("TokeniserQGram2", myTokeniserQGram2.ShortDescriptionString,
                            "Problem with TokeniserQGram2 test short description.");
        }

        [Fact]
        // [Category("TokeniserQGram2Extended Test")]
        public void TokeniserQGram2ExtendedShortDescription()
        {
            AssertUtil.Equal("TokeniserQGram2Extended", myTokeniserQGram2Extended.ShortDescriptionString,
                            "Problem with TokeniserQGram2Extended test short description.");
        }

        [Fact]
        // [Category("TokeniserQGram2 Test")]
        public void TokeniserQGram2TestData()
        {
            Collection<string> myKnownResult = new Collection<string>();
            myKnownResult.Add("CH");
            myKnownResult.Add("HR");
            myKnownResult.Add("RI");
            myKnownResult.Add("IS");
            //myKnownResult.TrimExcess();
            Collection<string> myResult = myTokeniserQGram2.Tokenize("CHRIS");
            for (int i = 0; i < myKnownResult.Count; i++)
            {
                AssertUtil.Equal(myKnownResult[i], myResult[i], "Problem with TokeniserQGram2 test.");
            }
        }

        [Fact]
        // [Category("TokeniserQGram2 CCI Test")]
        public void TokeniserQGram2TestWithCci1_Data()
        {
            Collection<string> myKnownResult = new Collection<string>();
            myKnownResult.Add("CH");
            myKnownResult.Add("HR");
            myKnownResult.Add("RI");
            myKnownResult.Add("IS");
            myKnownResult.Add("CR");
            myKnownResult.Add("HI");
            myKnownResult.Add("RS");
            //myKnownResult.TrimExcess();
            myTokeniserQGram2.CharacterCombinationIndex = 1;
            Collection<string> myResult = myTokeniserQGram2.Tokenize("CHRIS");
            for (int i = 0; i < myKnownResult.Count; i++)
            {
                AssertUtil.Equal(myKnownResult[i], myResult[i], "Problem with TokeniserQGram2 test.");
            }
        }

        [Fact]
        // [Category("TokeniserQGram2 Test")]
        public void TokeniserQGram2ExtendedTestData()
        {
            Collection<string> myKnownResult = new Collection<string>();
            myKnownResult.Add("?C");
            myKnownResult.Add("CH");
            myKnownResult.Add("HR");
            myKnownResult.Add("RI");
            myKnownResult.Add("IS");
            myKnownResult.Add("S#");
            Collection<string> myResult = myTokeniserQGram2Extended.Tokenize("CHRIS");
            for (int i = 0; i < myKnownResult.Count; i++)
            {
                AssertUtil.Equal(myKnownResult[i], myResult[i], "Problem with TokeniserQGram2Extended test.");
            }
        }

        [Fact]
        // [Category("TokeniserQGram2 CCI Test")]
        public void TokeniserQGram2ExtendedTestCc1_Data()
        {
            Collection<string> myKnownResult = new Collection<string>();
            myKnownResult.Add("?C");
            myKnownResult.Add("CH");
            myKnownResult.Add("HR");
            myKnownResult.Add("RI");
            myKnownResult.Add("IS");
            myKnownResult.Add("S#");
            myKnownResult.Add("?H");
            myKnownResult.Add("CR");
            myKnownResult.Add("HI");
            myKnownResult.Add("RS");
            myKnownResult.Add("I#");
            myTokeniserQGram2Extended.CharacterCombinationIndex = 1;
            Collection<string> myResult = myTokeniserQGram2Extended.Tokenize("CHRIS");
            for (int i = 0; i < myKnownResult.Count; i++)
            {
                AssertUtil.Equal(myKnownResult[i], myResult[i], "Problem with TokeniserQGram2Extended test.");
            }
        }
        #endregion

        #region SGram tests
        [Fact]
        public void TokeniserSGram2ExtendedTesting_ToString()
        {
            myTokeniserSGram2Extended.Tokenize("CHRIS");
            string result = myTokeniserSGram2Extended.ShortDescriptionString + " - currently holding : CHRIS." +
                            Environment.NewLine + "The method is using a character combination index of " +
                            Convert.ToInt32(myTokeniserSGram2Extended.CharacterCombinationIndex) + " and " + Environment.NewLine +
                            "a QGram length of " + Convert.ToInt32(myTokeniserSGram2Extended.QGramLength) + ".";
            AssertUtil.Equal(result, myTokeniserSGram2Extended.ToString(), "ToString method");
        }

        [Fact]
        public void TokeniserSGram2ExtendedTestCc1_Data()
        {
            Collection<string> myKnownResult = new Collection<string>();
            myKnownResult.Add("?C");
            myKnownResult.Add("CH");
            myKnownResult.Add("HR");
            myKnownResult.Add("RI");
            myKnownResult.Add("IS");
            myKnownResult.Add("S#");
            myKnownResult.Add("?H");
            myKnownResult.Add("CR");
            myKnownResult.Add("HI");
            myKnownResult.Add("RS");
            myKnownResult.Add("I#");
            Collection<string> myResult = myTokeniserSGram2Extended.Tokenize("CHRIS");
            for (int i = 0; i < myKnownResult.Count; i++)
            {
                AssertUtil.Equal(myKnownResult[i], myResult[i], "Problem with TokeniserQGram2Extended test.");
            }
        }

        [Fact]
        public void TokeniserSGram2TestWithCci1_Data()
        {
            Collection<string> myKnownResult = new Collection<string>();
            myKnownResult.Add("CH");
            myKnownResult.Add("HR");
            myKnownResult.Add("RI");
            myKnownResult.Add("IS");
            myKnownResult.Add("CR");
            myKnownResult.Add("HI");
            myKnownResult.Add("RS");
            Collection<string> myResult = myTokeniserSGram2.Tokenize("CHRIS");
            for (int i = 0; i < myKnownResult.Count; i++)
            {
                AssertUtil.Equal(myKnownResult[i], myResult[i], "Problem with TokeniserQGram2 test.");
            }
        }
        #endregion

        #region White Space Tests
        [Fact]
        // [Category("TokeniserWhitespace Test")]
        public void TokeniserWhitespaceShortDescription()
        {
            AssertUtil.Equal("TokeniserWhitespace", myTokeniserWhitespace.ShortDescriptionString,
                            "Problem with TokeniserWhitespace test short description.");
        }

        [Fact]
        // [Category("TokeniserWhitespace Test")]
        public void TokeniserWhitespaceTestData()
        {
            Collection<string> myKnownResult = new Collection<string>();
            myKnownResult.Add("CHRIS");
            myKnownResult.Add("IS");
            myKnownResult.Add("HERE");
            Collection<string> myResult = myTokeniserWhitespace.Tokenize("CHRIS IS HERE");
            for (int i = 0; i < myKnownResult.Count; i++)
            {
                AssertUtil.Equal(myKnownResult[i], myResult[i], "Problem with TokeniserWhitespace test.");
            }
        }

        [Fact]
        // [Category("TokeniserWhitespace Test")]
        public void TokeniserWhitespaceDelimiterTest()
        {
            Collection<string> myKnownResult = new Collection<string>();
            myKnownResult.Add("CHRIS");
            myKnownResult.Add("IS");
            myKnownResult.Add("");
            myKnownResult.Add("HERE");
            myKnownResult.Add("woo");
            Collection<string> myResult = myTokeniserWhitespace.Tokenize("CHRIS\nIS\r HERE\twoo");
            for (int i = 0; i < myKnownResult.Count; i++)
            {
                AssertUtil.Equal(myKnownResult[i], myResult[i], "Problem with TokeniserWhitespace test.");
            }
        }
        #endregion

        TokeniserQGram3 myTokeniserQGram3;
        TokeniserQGram3Extended myTokeniserQGram3Extended;
        TokeniserQGram2 myTokeniserQGram2;
        TokeniserSGram2 myTokeniserSGram2;
        TokeniserQGram2Extended myTokeniserQGram2Extended;
        TokeniserSGram2Extended myTokeniserSGram2Extended;
        TokeniserWhitespace myTokeniserWhitespace;

        // [SetUp]
        public TokenisersUnitTests()
        {
            myTokeniserQGram3 = new TokeniserQGram3();
            myTokeniserQGram3Extended = new TokeniserQGram3Extended();
            myTokeniserQGram2 = new TokeniserQGram2();
            myTokeniserSGram2 = new TokeniserSGram2();
            myTokeniserQGram2Extended = new TokeniserQGram2Extended();
            myTokeniserSGram2Extended = new TokeniserSGram2Extended();
            myTokeniserWhitespace = new TokeniserWhitespace();
        }
    }
}