using NUnit.Framework;
using CompareTexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LoadTextLibrary;


namespace CompareTexts.Tests
{
    [TestFixture()]
    public class CompareTextUsingJaccardTestClassTests
    {
        // THESE TEST ARE RUN ON A CONSTANT DATABASE WITH LOCATION ..\CompareTexts\_Test

        private List<string> InitializeListWithWords(string text)
        {
            var ResultList = new List<string>();

            ResultList = text.Split(' ').ToList();

            return ResultList;
        } // Helper method

        private string GetFilePath(string fileName, string tag, string trueOrFalse) // Helper method 
        {
            string directoryName = "_Test";
            string path = Directory.GetCurrentDirectory();

            path = Path.Combine(path, directoryName, tag, trueOrFalse, fileName); 

            return path;
        }

        // Tags is needed to make the instance - but have no effect on the test 
        [TestCase("Hello with you", 3, @"..\_Test\All_articles")]
        [TestCase("This is a little longer text", 6, @"..\_Test\All_articles")]
        public void TempTextToBeComparedTest(string text, int expectedResult, params string[] tags)
        {
            var listOfWords = InitializeListWithWords(text);

            var test = new CompareTextUsingJaccardTestClass(listOfWords, tags);

            Assert.AreEqual(test.TempTextToBeCompared.Count(), expectedResult);
        }

        // Tags is needed to make the instance - but have no effect on the test 
        [TestCase("Hello with you", 3, @"..\_Test\All_articles")]
        [TestCase("This is a little longer text", 6, @"..\_Test\All_articles")]
        public void TextToBeComparedTest(string text, int expectedResult, params string[] tags)
        {
            var listOfWords = InitializeListWithWords(text);

            var test = new CompareTextUsingJaccardTestClass(listOfWords, tags);

            Assert.AreEqual(test.TextToBeCompared.Count(), expectedResult);
        }

        // Text input is needed to make the instance - but have no effect on the test
        [TestCase("T", @"..\_Test\All_articles")]
        [TestCase("T", @"..\_Test\Brexit")]
        [TestCase("T", @"..\_Test\Trump")]
        public void SingleTagTest(string text, params string[] tags)
        {
            var listOfWords = InitializeListWithWords(text);

            var test = new CompareTextUsingJaccardTestClass(listOfWords, tags);

            CollectionAssert.AreEqual(tags, test.Tags);
        }

        // Text input is needed to make the instance - but have no effect on the test
        [TestCase("T", @"..\_Test\All_articles", @"..\_Test\Brexit", @"..\_Test\Trump")]
        [TestCase("T", @"..\_Test\Brexit", @"..\_Test\Syria_war")]
        [TestCase("T", @"..\_Test\Trump", @"..\_Test\Brexit", @"..\_Test\Terror", @"..\_Test\Crime", @"..\_Test\Egypt_attack")]
        public void MultipleTagsTest(string text, params string[] tags)
        {
            var listOfWords = InitializeListWithWords(text);

            var test = new CompareTextUsingJaccardTestClass(listOfWords, tags);

            CollectionAssert.AreEqual(tags, test.Tags);
        }


        [Test()] // Exception test (thrown by JaccardSimilarity) 
        public void CompareTextUsingJaccardWithEmptyTextTest()
        {
            var listOfWords = InitializeListWithWords("");

            string[] tags = { @"..\_Test\All_articles" };

            Assert.Throws(typeof(JaccardSimilarityLibrary.EmptyTextException), () => new CompareTextUsingJaccardTestClass(listOfWords, tags));
        }

        [TestCase("24_09_2015_Koran_Bible_Same2.txt", "All_articles", "False", 1, @"..\_Test\All_articles")]
        [TestCase("24_09_2015_Koran_Bible_Same2.txt", "All_articles", "False", 0, @"..\_Test\Brexit")]
        [TestCase("20_04_2017_Syria_news_BBC.txt", "Syria_war", "True", 0.0012, @"..\_Test\Syria_war")]
        public void FullImplementationFalseArticleSimilarity(string fileName, string tag, string trueOrFalse, decimal expectedResult,
                                                             params string[] tags)
        {
            string path = GetFilePath(fileName, tag, trueOrFalse);

            var text = new LoadEachWordToList(path);

            var test = new CompareTextUsingJaccardTestClass(text.Words, tags);

            decimal result = Math.Round(test.FalseArticlesSimilarity, 5);

            Assert.AreEqual(expectedResult, result);

        }

        [TestCase("24_09_2015_Koran_Bible_Same2.txt", "All_articles", "False", 0.00154, @"..\_Test\All_articles")]
        [TestCase("24_09_2015_Koran_Bible_Same2.txt", "All_articles", "False", 0, @"..\_Test\Brexit")]
        [TestCase("20_04_2017_Syria_news_BBC.txt", "Syria_war", "True", 1, @"..\_Test\Syria_war")]
        public void FullImplementationTrueArticleSimilarity(string fileName, string tag, string trueOrFalse, decimal expectedResult,
                                                             params string[] tags)
        {
            string path = GetFilePath(fileName, tag, trueOrFalse);

            var text = new LoadEachWordToList(path);

            var test = new CompareTextUsingJaccardTestClass(text.Words, tags);

            decimal result = Math.Round(test.TrueArticlesSimilarity, 5);

            Assert.AreEqual(expectedResult, result);

        }
    }
}