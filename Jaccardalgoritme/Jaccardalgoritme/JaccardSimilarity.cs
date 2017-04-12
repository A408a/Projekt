using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaccardalgoritme
{
    class JaccardSimilarity
    {

        
        //private int total = 0;
      
        // Making a List of strings which consists of stopwords. 
        public List<string> stopWords = System.IO.File.ReadAllLines(@"C:\Users\Aryan\Dropbox\P1 Projekt\P2\Program\Implementationer\Gamle implementationer\Jaccard\stopwords2.txt").ToList();

        // Making a List of strings which will be used to store shinglevalues from a document. 
        public List<string> shingles = new List<string>();

        /*Define method for shingling.
        * The method must find shingles from a document.
        * A shingle is set to a sentece, which consist of a stopword and the two words that follows the word. 
        * */

        public void GetShingles(List<string> tekst)
        {
            // count variable. 
            int i = 0;
            // foreach loop that iterates over the text. 
            foreach (string item in tekst)
            {
                //total++;
                if (stopWords.Contains(item.ToLower()))
                {
                    shingles.Add(item + " " + tekst[i+1] + " " + tekst[i+2]);
                }

                ++i;
                // if the count variable is 2 less than the number of elements in the list, then the loop is finished. 
                // The reason for this is that the last index number in the list is the number of elements -1. 
                if (i == (tekst.Count - 2))
                    break;
            }
            //Console.WriteLine(total);
            
        }

        public double CalculateSimilarity(List<string> shingleSetOne, List<string> shingleSetTwo)
        {
            
            List<string> similarElements =  shingleSetOne.Intersect(shingleSetTwo).ToList();
            
            // Skal denne udregning deles op i to, ved at beregne værdien af union i en anden beregning. 
            double jaccardValue = (double)similarElements.Count / (double)(shingleSetOne.Union(shingleSetTwo).ToList().Count);
            //Console.WriteLine("similar Elements: " + similarElements.Count);
            //Console.WriteLine("Union size: " + (shingleSetOne.Union(shingleSetTwo).ToList().Count));

            return jaccardValue;
      
        }
          
    }
}
