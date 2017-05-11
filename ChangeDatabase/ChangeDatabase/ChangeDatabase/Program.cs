using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            if (start == 1)
            {
                AutomaticRemoveFromDatabase Run = new AutomaticRemoveFromDatabase();
                Run.FindOutdatedFolder();
            }
            else
            {
                /*ChangeDatabase Run2 = new ChangeDatabase("test.txt");
                Run2.RemoveArticleFromDatabase();

                LoadEachWordToList TextA = new LoadEachWordToList(@"C:\Users\Jesper\Dropbox\AAU\P2\Program\Nyheder_Database\Crime\True\12_09_2016_New_York_Post_Anthony_Weiner_accused_of_sexting_relationship_with_15_year_old_girl.txt");
                ChangeDatabase Run = new ChangeDatabase(TextA.Words);
                Run.AddArticle();
                Console.ReadLine();*/
                AddOrRemoveArticle Run1 = new AddOrRemoveArticle("test.txt");
                Run1.RemoveArticleFromTag("abc");
            }
        }
    }
}