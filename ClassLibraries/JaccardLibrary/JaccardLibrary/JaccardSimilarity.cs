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
        public string[] tempStopWords { get; private set; }
        public HashSet<string> stopWords { get; private set; } = new HashSet<string>(); // Contains the stopwords from tempStopWords
        public HashSet<string> shinglesA { get; private set; } = new HashSet<string>(); // Contains shingles from TextA 
        public HashSet<string> shinglesB { get; private set; } = new HashSet<string>(); // Contains shingles from TextB
        public List<string> TextA { get; private set; } = new List<string>(); // Contains the first text 
        public List<string> TextB { get; private set; } = new List<string>(); // Contains the second text 
        public IEnumerable<string> SimilarElements { get; private set; }
        public IEnumerable<string> AllElements { get; private set; }
        public decimal Similarity { get; private set; } // Contains the JaccardSimilarity between the two texts  
        #endregion  

        public JaccardSimilarity(List<string> TextA, List<string> TextB)
        {
            tempStopWords = Resources.stopwords2.Split(new string[] { Environment.NewLine }, StringSplitOptions.None); // Splits stopwords into array 
            CreateHashSetOfStopWords(); // Creates a HashSet of stopwords 

            this.TextA = TextA;
            this.TextB = TextB;

            if (!TextA.Any())
                throw new EmptyTextException("The first text is empty");

            if (!TextB.Any())
                throw new EmptyTextException("The second text is empty");

            GetShingles(TextA, shinglesA); // Get shingles from TextA
            GetShingles(TextB, shinglesB); // Get shingles from TextB

            Similarity = CalculateSimilarity(); // Calculates similarity between the two texts 
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

                    shingles.Add($"{tekst[i]} {tekst[i + 1]} {tekst[i + 2]}".ToLower()); // Add a shingle (stopword + the following two words) 

                if (i == (tekst.Count - 3)) // Happens if there's not enough words left to make a shingle (3 words are needed to make a shingle)
                    break;
            }
        }

        private decimal CalculateSimilarity()
        {
            if (!shinglesA.Any() || !shinglesB.Any()) 
                return 0; 

            SimilarElements = shinglesA.Intersect(shinglesB); // Gets the Intersections of the two HashSets of shingles  

            AllElements = shinglesA.Union(shinglesB); // Gets the Union of the two HashSets of shingles  

            // Number og elements in the Intersection devided by number of elements in the Union
            return (decimal)SimilarElements.Count() / (decimal)AllElements.Count(); 
        }

        public void Print()
        {
            Console.WriteLine($"Jaccard similarity: {Similarity}");
        }
    }  
}


