using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadTextLibrary;

namespace ChangeDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 0;
            if (start == 1)
            {
                AutomaticRemoveFromDatabase Run = new AutomaticRemoveFromDatabase();
                Run.FindOutdateFolder();
            }
            else
            {
                LoadEachWordToList TextA = new LoadEachWordToList(@"C:\Users\Jesper\Dropbox\AAU\P2\Program\Nyheder_Database\Pizzagate2.txt");
                ChangeDatabase Run = new ChangeDatabase(TextA.Words);
                Run.AddArticle();
                Console.ReadLine();
                ChangeDatabase Run1 = new ChangeDatabase("test.txt");
                Run1.RemoveArticle();
            }
        }
    }
}