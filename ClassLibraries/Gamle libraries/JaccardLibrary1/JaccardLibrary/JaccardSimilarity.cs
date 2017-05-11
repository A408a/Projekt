using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JaccardLibrary.Properties;

namespace JaccardSimilarityLibrary
{
    public class JaccardSimilarity
    {
        #region Members
        public string[] tempStopWords; 
        public HashSet<string> stopWords = new HashSet<string>(); // Contains the stopwords from tempStopWords
        public HashSet<string> shinglesA = new HashSet<string>(); // Contains shingles from TextA 
        public HashSet<string> shinglesB = new HashSet<string>(); // Contains shingles from TextB
        public List<string> TextA = new List<string>(); // Contains the first text 
        public List<string> TextB = new List<string>(); // Contains the second text 
        public double Similarity; // Contains the JaccardSimilarity between the two texts  
        #endregion  

        public JaccardSimilarity(List<string> TextA, List<string> TextB)
        {
            tempStopWords = Resources.stopwords2.Split(new string[] { Environment.NewLine }, StringSplitOptions.None); // Splits stopwords into array 
            CreateHashSetOfStopWords(); // Creates a HashSet of stopwords 
            this.TextA = TextA;
            this.TextB = TextB;

            GetShingles(TextA, shinglesA); // Get shingles from TextA
            GetShingles(TextB, shinglesB); // Get shingles from TextB

            Similarity = CalculateSimilarity(shinglesA, shinglesB); // Calculates similarity between the two texts 
        }

        private void CreateHashSetOfStopWords() 
        {
            foreach(string word in tempStopWords)
            {
                stopWords.Add(word); // Adds each stopwords to a HashSet
            }
        } 

        private void GetShingles(List<string> tekst, HashSet<string> shingles) 
        {
               
            for(int i = 0; i < tekst.Count; ++i) // Iterates through the text 
            {
                if (stopWords.Contains(tekst[i].ToLower())) // Happens if the current word is a stopword

                    shingles.Add(tekst[i] + " " + tekst[i + 1] + " " + tekst[i + 2]); // Add a shingle (stopword + the following two words) 

                if (i == (tekst.Count - 3)) // Happens if there's not enough words left to make a shingle (3 words are needed to make a shingle)
                    break;
            }
        }

        private double CalculateSimilarity(HashSet<string> shingleSetOne, HashSet<string> shingleSetTwo)
        {
            IEnumerable<string> similarElements = shingleSetOne.Intersect(shingleSetTwo); // Gets the Intersections of the two HashSets of shingles  

            IEnumerable<string> allElements = shinglesA.Union(shinglesB); // Gets the Union of the two HashSets of shingles  

            // Number og elements in the Intersection devided by number of elements in the Union
            double jaccardValue = (double)similarElements.Count() / (double)allElements.Count(); 

            return jaccardValue;
        }

        public void Print()
        {
            Console.WriteLine($"Jaccard similarity: {Similarity}");
        }
           
    }  
}


