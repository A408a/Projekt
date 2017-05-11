using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompareTexts.Properties;
using LoadTextLibrary;
using CosineSimilarityLibrary;

namespace CompareTexts
{
    class Program
    {
        static void Main(string[] args)
        {
            var TekstA = new List<string>();
            var TekstB = new List<string>();
            string[] stringSeparators = { ", ", ".", "!", "?", ";", ":", " ", "-", "\"", "(", ")" };

            var test1 = new LoadEachWordToList(@"C:\Users\Patri\OneDrive\Dokumenter\Visual Studio 2015\Projects\CompareTexts\Nyheder_Database\All_articles\False\03_11_2016_Higgs_News_Network_BBC_And_CNN_News_Caught_Staging_FAKE_News.txt");
            var test2 = new LoadEachWordToList(@"C:\Users\Patri\OneDrive\Dokumenter\Visual Studio 2015\Projects\CompareTexts\Nyheder_Database\All_articles\False\05_03_2017_Koran_Bible_Same1.txt");
            var test3 = new LoadEachWordToList(@"C:\Users\Patri\OneDrive\Dokumenter\Visual Studio 2015\Projects\CompareTexts\Nyheder_Database\All_articles\True\20_04_2017_Syria_news_BBC.txt");
            

            string[] tags = { "Brexit" };

            var testJaccard = new CompareTextUsingJaccardSimilarity(test1.Words, null);
            Console.WriteLine("False: " + testJaccard.FalseArticlesSimilarity);
            Console.WriteLine("True: " + testJaccard.TrueArticlesSimilarity);


            var testCosine = new CompareTextUsingCosineSimilarity(test2.Words, tags);
            Console.WriteLine("\n");
            Console.WriteLine("False: " + (decimal)testCosine.FalseArticlesSimilarity);
            Console.WriteLine("True: " + (decimal)testCosine.TrueArticlesSimilarity);

            Console.ReadLine();

        }
    }
}
