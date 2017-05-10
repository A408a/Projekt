using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            try
            {
                NewsPage page = new NewsPage(Webaddress);                   // New Instance.

                Console.Clear();
                Console.WriteLine(page.Headline);
                foreach (string text in page.BodyText)
                {
                    Console.WriteLine(text);                 // Print Text content
                }

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
