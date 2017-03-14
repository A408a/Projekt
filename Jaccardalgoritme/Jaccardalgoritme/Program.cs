using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadTextLibrary;

namespace Jaccardalgoritme
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string text = System.IO.File.ReadAllText(@"C:\Users\Aryan\Dropbox\P1 projekt\P2\Program\Jaccard\stopwords.txt");
            string nytekst = text.Replace(", ", Environment.NewLine);
            Console.ReadLine();
            System.IO.File.WriteAllText(@"C:\Users\Aryan\Dropbox\P1 projekt\P2\Program\Jaccard\stopwords2.txt", nytekst);
            */
            
            // Creating an instance of the LoadEachWordToList class. 
            LoadEachWordToList tekstB = new LoadEachWordToList(@"C:\Users\Aryan\Dropbox\P1 Projekt\P2\Program\Nyheder_Database\Pizzagate1.txt");

            //tekstB.LoadText();

            //foreach (string i in tekstB.Words)
            //{
            //    Console.WriteLine(i);
            //}

            // Creating an instance of the JaccardSimilarity class called nytekst.
            JaccardSimilarity nytekst = new JaccardSimilarity();

            /* Calling the GetShingles method from the JaccardSimilarity class on the object.
             *  The parameter is a text, where each word is an element in a List. 
             *  */
            nytekst.GetShingles(tekstB.Words);

            foreach (string item in nytekst.shingles)
            {
                Console.WriteLine(item);
            }


            /*LoadEachWordToList tekstA = new LoadEachWordToList(@"C:\Users\Aryan\Dropbox\P1 projekt\P2\Program\Jaccard\stopwords.txt");
            tekstA.LoadText();
            tekstA.GetEachWordInText();*/
            Console.ReadLine();

        }
    }
}
