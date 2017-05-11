using NUnit.Framework;
using JaccardSimilarityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JaccardSimilarityLibraryTests.Properties;



namespace JaccardSimilarityLibrary.Tests
{
    [TestFixture()] 
    public class JaccardSimilarityTests
    {
        private List<string> InitializeListWithWords(string text)
        {
            var ResultList = new List<string>();

            ResultList = text.Split(' ').ToList();

            return ResultList;
        } // Helper method

        private List<string> InitiaizeListWithShingles(params string[] shingles)
        {
            var result = new List<string>();

            foreach (string shingle in shingles)
                result.Add(shingle);

            return result;
        } // Helper method 

        private void InitializeListWithWordsFromText(out List<string> firstText, out List<string> secondText)
        {
            string[] stringSeparators = { ",", ".", "!", "?", ";", ":", " ", "-", "\"", "(", ")" };

            firstText = Resources.Pizzagate1.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries).ToList();
            secondText = Resources.Pizzagate2.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries).ToList();
            
        } // Helper method 

        [TestCase("He is standing behind you", "He is standing behind you", 1)]
        [TestCase("It is clearly a problem", "That is clearly a problem", 0.5)]
        [TestCase("Are these two text similar, according to the Jaccard implementation",
                  "They should be quite similar, according to the Jaccard implementation", 0.22222222222222221)]
        [TestCase("This is the first text", "That text is definitely not equal to this one", 0)]
        [TestCase("Upper case letters should not matter", "UPPER CASE LETTERS SHOULD NOT MATTER", 1)] // Test with uppercase letters 
        [TestCase("Cat ate mouse", "Cat ate mouse", 0)] // Doesn't contain shingles and should therefore have 0 similarity 
        [TestCase(" ", " ", 0)] // Doesn't contain shingles and should therefore have 0 similarity  
        public void FullImplementationSimilarityTest(string first, string second, double expectedSimilarity)
        {
            List<string> firstList = InitializeListWithWords(first);
            List<string> secondList = InitializeListWithWords(second);

            var test = new JaccardSimilarity(firstList, secondList);

            Assert.AreEqual(expectedSimilarity, test.Similarity);
        }

        [Test()] // Load of stopwords from textfile
        public void TemporaryStopwordsTest()
        {
            var test = new JaccardSimilarity(new List<string>() { "Can't be empty" }, new List<string>() { "Can't be empty" });

            Assert.AreEqual(464, test.tempStopWords.Count());
        }
        
        [Test()] // Method that insert stopwords to HashSet
        public void AmountOfStopwordsTest()
        {
            var test = new JaccardSimilarity(new List<string>() { "Can't be empty" }, new List<string>() { "Can't be empty" });

            Assert.AreEqual(464, test.stopWords.Count);
        }

        [Test()] // Check that the first text are handled correctly 
        public void InitializeTextATest()
        {
            List<string> first = InitializeListWithWords("This is a test");

            var test = new JaccardSimilarity(first, new List<string>() { "Can't be empty" });

            CollectionAssert.AreEqual(first, test.TextA);
        }

        [Test()] // Check that the second text are handled correctly
        public void InitializeTextBTest()
        {
            List<string> Second = InitializeListWithWords("This is a test");

            var test = new JaccardSimilarity(new List<string>() { "Can't be empty" }, Second);

            CollectionAssert.AreEqual(Second, test.TextB);
        }

        [TestCase("Hello with you")]
        [TestCase("Test af shingles på en lidt længere sætning - stopord er på engelsk")]
        // We expect no shingles to be generated from the 2 above standing texts input
        public void GetShinglesAExpectNoShinglesInGivenTextTest(string text)
        {
            var listOfWords = InitializeListWithWords(text);

            var test = new JaccardSimilarity(listOfWords, new List<string>() { "Can't be empty" });

            Assert.IsFalse(test.shinglesA.Any());
        }

        [TestCase("Hello with you")]
        [TestCase("Test af shingles på en lidt længere sætning - stopord er på engelsk")]
        // We expect no shingles to be generated from the 2 above standing texts input
        public void GetShinglesBExpectNoShinglesInGivenTextTest(string text)
        {
            var listOfWords = InitializeListWithWords(text);

            var test = new JaccardSimilarity(new List<string>() { "Can't be empty" }, listOfWords);

            Assert.IsFalse(test.shinglesB.Any());
        }

        [TestCase("You Are Tired", "you are tired")] // Test with upper- and lowercase letters 
        [TestCase("UPPERCASE SHOULD BE CONVERTED TO LOWERCASE", "should be converted", // Test with all uppercase
                  "be converted to")] 
        [TestCase("just a normal sentence to check for generated shingles", "just a normal", "a normal sentence",
                  "to check for", "for generated shingles")] // Regular sentence 
        public void GetShinglesAShinglesInGivenTextTest(string text, params string[] shingles)
        {
            List<string> listOfWords = InitializeListWithWords(text);
            List<string> expectedResult = InitiaizeListWithShingles(shingles);

            var test = new JaccardSimilarity(listOfWords, new List<string>() { "Can't be empty" });

            CollectionAssert.AreEqual(expectedResult, test.shinglesA);
        }

        [TestCase("You Are Tired", "you are tired")] // Test with upper- and lowercase letters 
        [TestCase("UPPERCASE SHOULD BE CONVERTED TO LOWERCASE", "should be converted",
                  "be converted to")] // Test with all uppercase
        [TestCase("just a normal sentence to check for generated shingles", "just a normal", "a normal sentence",
                  "to check for", "for generated shingles")] // Regular sentence 
        public void GetShinglesBShinglesInGivenTextTest(string text, params string[] shingles)
        {
            List<string> listOfWords = InitializeListWithWords(text);
            List<string> expectedResult = InitiaizeListWithShingles(shingles);

            var test = new JaccardSimilarity(new List<string>() { "Can't be empty" }, listOfWords);

            CollectionAssert.AreEqual(expectedResult, test.shinglesB);
        }

        [TestCase("This is the first sentence", "This is the second sentence", 1)]
        [TestCase("THIS IS THE FIRST SENTENCE", "This is the second sentence", 1)] // UPPERCASE AND LOWERCASE
        [TestCase("Maybe we should test with a longer sentence", "We can test with a logner sentence", 0 )]
        [TestCase("We could also try with two equal sentences", "We could also try with two equal sentences", 5)] // Equal sentences
        public void SimilarElementsTest(string first, string second, int expectedResult)
        {
            List<string> firstList = InitializeListWithWords(first);
            List<string> secondList = InitializeListWithWords(second);

            var test = new JaccardSimilarity(firstList, secondList);

            Assert.AreEqual(expectedResult, test.SimilarElements.Count());
        }

        [TestCase("This is the first sentence", "This is the second sentence", 5)]
        [TestCase("THIS IS THE FIRST SENTENCE", "This is the second sentence", 5)] // UPPERCASE AND LOWERCASE
        [TestCase("Maybe we should test with a longer sentence", "We can test with a logner sentence", 8)]
        [TestCase("We could also try with two equal sentences", "We could also try with two equal sentences", 5)] // Equal sentences
        public void AllElementsTest(string first, string second, int expectedResult)
        {
            List<string> firstList = InitializeListWithWords(first);
            List<string> secondList = InitializeListWithWords(second);

            var test = new JaccardSimilarity(firstList, secondList);

            Assert.AreEqual(expectedResult, test.AllElements.Count());
        }

        [Test()] // Test for two hole texts (added as resources) 
        public void SimilarityBetweenTwoRealTextstTest()
        {
            List<string> firstText;
            List<string> secondText; 
       
            InitializeListWithWordsFromText(out firstText, out secondText);

            var test = new JaccardSimilarity(firstText, secondText);

            decimal similarity = Math.Round(test.Similarity, 6);

            Assert.AreEqual(0.008997, similarity);
        }

        [Test()] // Test for two hole text1s in reverse order (added as resources) 
        public void SimilarityBetweenTwoRealTextstInReverseOrderTest()
        {
            List<string> firstText;
            List<string> secondText;

            InitializeListWithWordsFromText(out firstText, out secondText);

            var test = new JaccardSimilarity(secondText, firstText);

            decimal similarity = Math.Round(test.Similarity, 6);

            Assert.AreEqual(0.008997, similarity);
        }


        [Test()]
        public void FirstArgumentEmptyListExceptionTest()
        {
            Assert.Throws(typeof(EmptyTextException), () => new JaccardSimilarity(new List<string>(), new List<string>() { "Can't be empty" }));
        } // Argument exception if the first list is empty 

        [Test()]
        public void SecondArgumentEmptyListExceptionTest()
        {
            Assert.Throws(typeof(EmptyTextException), () => new JaccardSimilarity(new List<string>() { "Can't be empty" }, new List<string>()));
        }// Argument exception if the second list is empty 
   
    }
}