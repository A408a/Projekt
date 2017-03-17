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

            //Console.WriteLine("Enter the name of the first text file with .txt");
            //string firstText = Console.ReadLine();
            //Console.WriteLine("Enter the name of the second text file with .txt");
            //string secondText = Console.ReadLine();
            
            // Creating an instance of the LoadEachWordToList class. 
            LoadEachWordToList tekstA = new LoadEachWordToList(@"C:\Users\Aryan\Dropbox\P1 Projekt\P2\Program\Nyheder_Database\tekst1.txt");
            LoadEachWordToList tekstB = new LoadEachWordToList(@"C:\Users\Aryan\Dropbox\P1 Projekt\P2\Program\Nyheder_Database\tekst2.txt");

            //tekstB.LoadText();

            //foreach (string i in tekstB.Words)
            //{
            //    Console.WriteLine(i);
            //}

            // Creating an instance of the JaccardSimilarity class called nytekst.
            JaccardSimilarity nytekstA = new JaccardSimilarity();
            JaccardSimilarity nytekstB = new JaccardSimilarity();

            /* Calling the GetShingles method from the JaccardSimilarity class on the object.
             *  The parameter is a text, where each word is an element in a List. 
             *  */
            nytekstA.GetShingles(tekstA.Words);
            nytekstB.GetShingles(tekstB.Words);

            double jaccardSimilarity = nytekstA.CalculateSimilarity(nytekstA.shingles, nytekstB.shingles);
            Console.WriteLine("The Jaccard similarity of the two texts is: " + jaccardSimilarity);


            //foreach (string item in nytekstA.shingles)
            //{
            //    Console.WriteLine(item);
            //}

          

            /*LoadEachWordToList tekstA = new LoadEachWordToList(@"C:\Users\Aryan\Dropbox\P1 projekt\P2\Program\Jaccard\stopwords.txt");
            tekstA.LoadText();
            tekstA.GetEachWordInText();*/
            Console.ReadLine();

        }
    }
}
