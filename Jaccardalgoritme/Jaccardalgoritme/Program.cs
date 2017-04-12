using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadTextLibrary;
using System.Windows.Forms;

namespace Jaccardalgoritme
{
    class Program  
    {
        [STAThread]
        static void Main(string[] args)
        {


            //Console.WriteLine("Enter the name of the first text file");
            //string firstText = Console.ReadLine();
            //Console.WriteLine("Enter the name of the second text file");
            //string secondText = Console.ReadLine();


            // Creating an instance of the LoadEachWordToList class. 
            //LoadEachWordToList tekstA = new LoadEachWordToList(@"C:\Users\Aryan\Dropbox\P1 Projekt\P2\Program\Nyheder_Database\" + firstText + ".txt");
            //LoadEachWordToList tekstB = new LoadEachWordToList(@"C:\Users\Aryan\Dropbox\P1 Projekt\P2\Program\Nyheder_Database\" + secondText + ".txt");


            // Creating instances of the JaccardSimilarity class called nytekstA and nytekstB.
            //JaccardSimilarity nytekstA = new JaccardSimilarity();
            //JaccardSimilarity nytekstB = new JaccardSimilarity();

            /* Calling the GetShingles method from the JaccardSimilarity class on the object.
             *  The parameter is a text, where each word is an element in a List. 
             *  */
            //nytekstA.GetShingles(tekstA.Words);
            //nytekstB.GetShingles(tekstB.Words);

            //double jaccardSimilarity = nytekstA.CalculateSimilarity(nytekstA.shingles, nytekstB.shingles);
            //Console.WriteLine("The Jaccard similarity of the two texts is: " + jaccardSimilarity);
            //Console.WriteLine("Shigles for tekst A: ");
            //foreach (string item in nytekstA.shingles)
            //{
            //    Console.WriteLine(item);
            //}


        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new BrowseFile());
        
        //Console.ReadLine();

        }
    }
}
