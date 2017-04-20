using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadTextLibrary;

namespace CheckLinkTrustworthiness
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadStringToList ListOfFakeNewsWebsites = new LoadStringToList(@"D:\P2GithubMappe\Projekt\FakeNewsWebsiteDatabase2\FakeNewsWebsites.txt");
            Console.WriteLine("Wat: ");
            string LinkFromUser = Console.ReadLine();
            CheckLinkTrustworthiness CheckLink = new CheckLinkTrustworthiness(ListOfFakeNewsWebsites.Lines, LinkFromUser);
            Console.ReadLine();
        }
    }
}
