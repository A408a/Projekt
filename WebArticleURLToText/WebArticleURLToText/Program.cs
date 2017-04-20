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
            NewsPage page = new NewsPage(Webaddress);                   // New Instance.
            Console.WriteLine(page.Headline);
            foreach (string text in page.BodyText)
            {
                Console.WriteLine(text);                 // Print Text content
            }

            Console.ReadKey();
        }
    }
}
