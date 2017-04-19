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
            LoadStringToList ListOfFakeNewsWebsites = new LoadStringToList(@"D:\AAU\2.semester\Projekt\Program\FakeNewsWebsiteDatabase\FakeNewsWebsites.txt");
            CheckLinkTrustworthiness CheckLink = new CheckLinkTrustworthiness(ListOfFakeNewsWebsites.Lines);
            Console.ReadLine();
        }
    }
}
