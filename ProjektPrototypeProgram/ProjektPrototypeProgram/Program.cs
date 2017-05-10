using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadTextLibrary;
using LevenshteinDistanceLibrary;
using CosineSimilarityLibrary;
using ProjektPrototypeProgram.Properties;
using JaccardSimilarityLibrary;
using System.Diagnostics;  


namespace ProjektPrototypeProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine(Stopwatch.IsHighResolution); 
            stopwatch.Start();
           
            #region LevenshteinDistance
            //Indlæser hver linje af teksten til en liste af strings
            LoadStringToList tekstA = new LoadStringToList(@"C:\Users\Patri\Dropbox\Projekt\P2\Program\Nyheder_Database\Koran_Bible_Same1.txt");
            LoadStringToList tekstB = new LoadStringToList(@"C:\Users\Patri\Dropbox\Projekt\P2\Program\Nyheder_Database\Koran_Bible_Same2.txt");

            // Beregner LevenshteinDistance
            LevenshteinDistance levDis = new LevenshteinDistance(tekstA.Lines, tekstB.Lines, tekstA.GetAmountOfChars(),
                                                                 tekstB.GetAmountOfChars(), tekstA.LinesInText, tekstB.LinesInText);
            levDis.Print(); // Printer LevenshteinDistance mellem de to tekster 
            #endregion
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();

            #region CosineDistance 
            //Indlæser hvert ord fra teksten til en liste af strings 
            LoadEachWordToList TextA = new LoadEachWordToList(@"C:\Users\Patri\Dropbox\Projekt\P2\Program\Nyheder_Database\Koran_Bible_Same1.txt");
            LoadEachWordToList TextB = new LoadEachWordToList(@"C:\Users\Patri\Dropbox\Projekt\P2\Program\Nyheder_Database\Koran_Bible_Same2.txt");

            CalculateCosine CalcCos = new CalculateCosine(TextA.Words, TextB.Words); // Beregner CosineDistance
            CalcCos.Print(); // Printer CosineSimilarity mellem de to tekster 
            #endregion
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();

            #region JaccardDistance
            JaccardSimilarity nytekstA = new JaccardSimilarity(TextA.Words, TextB.Words); // TextA og TextB er indlæst i #region CosineDistance - (LoadEachWordToList)

            nytekstA.Print(); // Printer JaccardSimilarity mellem de to tekster  
            #endregion
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            stopwatch.Stop();

            #region TryDiffrentLoadMethod (Resources) 
            //var TekstA = new List<string>();
            //var TekstB = new List<string>();
            //string[] stringSeparators = { ",", ".", "!", "?", ";", ":", " ", "-", "\"", "(", ")" };

            //TekstA = Resources.Pizzagate1.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries).ToList();
            //TekstB = Resources.Pizzagate2.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries).ToList();

            //CalculateCosine CalcCos2 = new CalculateCosine(TekstA, TekstB); // Beregner CosineDistance
            //CalcCos2.Print(); // Printer CosineDistance mellem de to tekster 
            #endregion

            Console.ReadLine();
        }
    }
}
