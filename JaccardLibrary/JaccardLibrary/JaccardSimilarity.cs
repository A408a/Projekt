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
        public List<string> stopWords = new List<string>();  // Making a List of strings which consists of stopwords.
        public List<string> shinglesA = new List<string>();  // Making a List of strings which will be used to store shinglevalues from a document. 
        public List<string> shinglesB = new List<string>();  // Making a List of strings which will be used to store shinglevalues from a document. 
        public List<string> TekstA = new List<string>(); // Contains the first text 
        public List<string> TekstB = new List<string>(); // Contains the second text 
        public double Similarity; // Contains the JaccardSimilarity between the two texts 

        public JaccardSimilarity(List<string> TekstA, List<string> TekstB)
        {
            stopWords = Resources.stopwords2.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            this.TekstA = TekstA;
            this.TekstB = TekstB;

            GetShingles(TekstA, shinglesA);
            GetShingles(TekstB, shinglesB);

            Similarity = CalculateSimilarity(shinglesA, shinglesB);
        }

        /*Define method for shingling.
        * The method must find shingles from a document.
        * A shingle is set to a sentece, which consist of a stopword and the two words that follows the word. */
        public void GetShingles(List<string> tekst, List<string> shingles)
        {
            // count variable. 
            int i = 0;
            // foreach loop that iterates over the text. 
            foreach (string item in tekst)
            {

                if (stopWords.Contains(item.ToLower()))
                {
                    shingles.Add(item + " " + tekst[i + 1] + " " + tekst[i + 2]);
                }

                ++i;
                // if the count variable is 2 less than the number of elements in the list, then the loop is finished. 
                // The reason for this is that the last index number in the list is the number of elements -1. 
                if (i == (tekst.Count - 2))
                    break;
            }

        }

        public double CalculateSimilarity(List<string> shingleSetOne, List<string> shingleSetTwo)
        {

            List<string> similarElements = shingleSetOne.Intersect(shingleSetTwo).ToList();

            // Skal denne udregning deles op i to, ved at beregne værdien af union i en anden beregning. 
            double jaccardValue = (double)similarElements.Count / (double)(shingleSetOne.Union(shingleSetTwo).ToList().Count);

            return jaccardValue;

        }

        public void Print()
        {
            Console.WriteLine($"Jaccard similarity: {Similarity}");
        }
    }
}
