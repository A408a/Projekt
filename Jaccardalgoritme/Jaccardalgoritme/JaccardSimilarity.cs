using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaccardalgoritme
{
    class JaccardSimilarity
    {
        /*Define method for shingling.
         * The method must find shingles from a document.
         * A shingle is set to a sentece, which consist of a stopword and the two words that follows the word. 
         * */
        // Making a List of strings which consists of stopwords. 
        public List<string> stopWords = System.IO.File.ReadAllLines(@"C:\Users\Aryan\Dropbox\P1 projekt\P2\Program\Jaccard\stopwords2.txt").ToList();

        // Making a List of strings which will be used to store shinglevalues from a document. 
        public List<string> shingles = new List<string>();

        /*Define method for shingling.
        * The method must find shingles from a document.
        * A shingle is set to a sentece, which consist of a stopword and the two words that follows the word. 
        * */
        public void GetShingles(string tekst)
        {
           

        }
          
    }
}
