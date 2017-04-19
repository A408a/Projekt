using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebArticleURLToText
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(" Insert URL Address >> ");

           
            string Webaddress = Console.ReadLine();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;               // Color on article letters.
            NewsPage page = new NewsPage(Webaddress);                   // New Instance.
            Console.WriteLine(page.GetArticleHead());
            Console.WriteLine(page.GetArticleBody());                 // Print Text content

            Console.ReadKey();
        }
    }
}
