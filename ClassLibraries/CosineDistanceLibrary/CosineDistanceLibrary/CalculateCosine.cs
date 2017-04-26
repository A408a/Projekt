using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using CosineDistanceLibrary.Properties;

namespace CosineSimilarityLibrary
{
    public class CalculateCosine
    {
        private List<string> InputText1;
        private List<string> InputText2;
        public List<int> vecA = new List<int>();
        public List<int> vecB = new List<int>();
        public double _cosValue = 0;
        private double _vecA = 0, _vecB = 0;
        public int Procent = 0;
        public string[] nouns;


        public CalculateCosine(List<string> InputText1, List<string> InputText2)
        {
            this.InputText1 = InputText1;
            this.InputText2 = InputText2;

            this.ReadNoun();
            _cosValue = CalculateCosineSimilarity();
            Print();
        }

        public void ReadNoun()
        {
            var stringSeperator = new string[] { Environment.NewLine };
            nouns = System.IO.File.ReadAllLines(@"C:\Users\Marcus\Dropbox\AAU\P2\Noter\nouns.txt");
            CreateVector();
        }

        private void CreateVector()
        {
            for (int i = 0; i < nouns.Length; i++)
            {
                vecA.Add(MatchNoun(nouns[i], InputText1));
                vecB.Add(MatchNoun(nouns[i], InputText2));
            }
        }

        public int MatchNoun(string sPattern, List<string> textinput)
        {
            int counter = 0;

            foreach (string word in textinput)
                if (sPattern == word)
                    ++counter;

            return counter;
        }

        private double CalculateCosineSimilarity()
        {
            var dotProduct = DotProduct(vecA, vecB);
            var magnitudeOfA = Magnitude(_vecA);
            var magnitudeOfB = Magnitude(_vecB);

            return dotProduct / (magnitudeOfA * magnitudeOfB);
        }

        public double DotProduct(List<int> vector1, List<int> vector2)
        {
            double dotProduct = 0;
            for (int i = 0; i < vector1.Count; i++)
            {
                dotProduct += (vector1[i] * vector2[i]);
                _vecA += (vecA[i] * vecA[i]);
                _vecB += (vecA[i] * vecA[i]);
            }

            return dotProduct;
        }

        public double Magnitude(double vector)
        {
            return Math.Sqrt(vector);
        }

        public void Print()
        {
            Procent = (int)(_cosValue * 100);
            Console.WriteLine($"Cosine similarity: {Procent}%");

        }
    }
}
