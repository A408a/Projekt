using NUnit.Framework;
using CosineSimilarityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosineSimilarityLibrary.Tests
{
    [TestFixture()]
    public class CalculateCosineTests
    {
        List<string> Input1 = new List<string>();
        List<string> Input2 = new List<string>();

        [Test()]
        public void DotProductTest()
        {
            var test = new CalculateCosine(Input1, Input2);
            List<int> TryVector1 = new List<int>();
            TryVector1.Add(3);
            TryVector1.Add(5);
            TryVector1.Add(0);
            TryVector1.Add(2);
            TryVector1.Add(0);

            List<int> TryVector2 = new List<int>();
            TryVector2.Add(4);
            TryVector2.Add(6);
            TryVector2.Add(0);
            TryVector2.Add(1);
            TryVector2.Add(0);

            Assert.AreEqual(test.DotProduct(TryVector1, TryVector2), 44);
        }

        [Test()]
        public void MagnitudeTest()
        {
            double vector = 16;

            var test = new CalculateCosine(Input1, Input2);

            Assert.AreEqual(test.Magnitude(vector), 4);
        }

        [Test()]
        public void PrintPercentValueLessThanTest()
        {
            //Input1.Add("people");
            //Input2.Add("people");
            var test = new CalculateCosine(Input1, Input2);

            Assert.LessOrEqual(test.Procent, 100);
        }

        [Test()]
        public void PrintPercentValueGreaterThanTest()
        {
            var test = new CalculateCosine(Input1, Input2);

            Assert.GreaterOrEqual(test.Procent, 0); 
        }

        [Test()]
        public void CalculateCosineSimilarityGreaterThanTest()
        {
            Input1.Add("people");
            Input2.Add("people");
            var test = new CalculateCosine(Input1, Input2);

            Assert.GreaterOrEqual(test._cosValue, 0);
        }

        [Test()]
        public void CalculateCosineSimilarityLessThanTest()
        {
            var test = new CalculateCosine(Input1, Input2);

            Assert.LessOrEqual(test._cosValue, 1);
        }

        [Test()]
        public void ReadNounTest()
        {
            var test = new CalculateCosine(Input1, Input2);

            Assert.IsNotEmpty(test.nouns);
        }

        [Test()]
        public void CreateVectorVecATest()
        {
            var test = new CalculateCosine(Input1, Input2);

            Assert.NotNull(test.vecA);
        }

        [Test()]
        public void CreateVectorVecBTest()
        {
            var test = new CalculateCosine(Input1, Input2);

            Assert.NotNull(test.vecB);
        }

        [Test()]
        public void MatchNounTest()
        {
            var test = new CalculateCosine(Input1, Input2);
            //string[] Pattern = new string[3] { "ad", "head", "people" };
            string Pattern = "ad";
            List<string> Input = new List<string>();
            Input.Add("people");
            Input.Add("head");
            Input.Add("ad");
            Input.Add("the");
            Input.Add("hello");
            Input.Add("");

            Assert.AreEqual(test.MatchNoun(Pattern, Input), 1);
        }
    }
}