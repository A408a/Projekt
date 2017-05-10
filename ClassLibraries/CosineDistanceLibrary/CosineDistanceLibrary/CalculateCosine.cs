using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using CosineDistanceLibrary.Properties;

namespace CosineSimilarityLibrary
{
    public class CalculateCosine
    {
        private List<string> InputText1;
        private List<string> InputText2;
        public List<int> vecA = new List<int>();
        public List<int> vecB = new List<int>();
        public double _cosValue = 0; // Cosine similarity
        private double _vecA = 0, _vecB = 0; // Contains the magnitude for the two vectors
        public int Procent = 0; // _cosValue * 100
        public string[] nouns; // List of about 1100 nouns


        public CalculateCosine(List<string> InputText1, List<string> InputText2)
        {
            this.InputText1 = InputText1; // List containing each word from the text
            this.InputText2 = InputText2;

            ReadNoun();
            _cosValue = CalculateCosineSimilarity();
            Print();
        }

        public void ReadNoun() // Loads every line of the embedded txt file
        {
            // Makes the path to nouns
            string path = $"{Directory.GetCurrentDirectory()}\\CosineDistanceLibrary\\Resources\\nouns.txt";
            var stringSeperator = new string[] { Environment.NewLine }; // Splits at every newline
            nouns = File.ReadAllLines(path); // C:\Users\Marcus\Dropbox\AAU\P2\Noter\nouns.txt
            CreateVector();
        }

        private void CreateVector() // Makes the vectors
        {
            for (int i = 0; i < nouns.Length; i++)
            {
                vecA.Add(MatchNoun(nouns[i], InputText1)); // Searches through the list of words from the text to check if the noun appears
                vecB.Add(MatchNoun(nouns[i], InputText2));
            }
        }

        public int MatchNoun(string sPattern, List<string> textinput) // Checks how many times the noun appears in the text
        {
            int counter = 0;

            foreach (string word in textinput)
                if (sPattern == word) // Checks to see if pattern is exactly the same as the current word from the text
                    ++counter; // Amount of times the word appeared in the list of words from the text

            return counter;
        }

        private double CalculateCosineSimilarity()
        {
            var dotProduct = DotProduct(vecA, vecB);
            var magnitudeOfA = SquareRoot(_vecA);
            var magnitudeOfB = SquareRoot(_vecB);

            return dotProduct / (magnitudeOfA * magnitudeOfB); // Cosine similarity
        }

        public double DotProduct(List<int> vector1, List<int> vector2) // Calculates the dot product and magnitudes of the vectors
        {
            double dotProduct = 0;
            for (int i = 0; i < vector1.Count; i++)
            {
                dotProduct += (vector1[i] * vector2[i]); // Dotproduct
                _vecA += (vecA[i] * vecA[i]); // First part of the magnitude calculation
                _vecB += (vecB[i] * vecB[i]);
            }

            return dotProduct;
        }

        public double SquareRoot(double vector) // Second part of the magnitude calculation
        {
            return Math.Sqrt(vector);
        }

        public void Print() // Returns the cosine similarity value as percent
        {
            Procent = (int)(_cosValue * 100);
        }
    }
}
