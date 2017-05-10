using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindQuoteLibrary
{
    public class AddToQuoteDatabase
    {
        private string Text;
        private List<string> ListOfQuotes = new List<string>();

        public void Method1()
        {
            //5 mapper op
            string path = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.Parent.FullName}\\Nyheder_Database";
            string path2 = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.Parent.FullName}\\Nyheder_Database\\DatabaseOfQuotes.txt";
            //string path = "D:\\P2GithubMappe\\Projekt\\Nyheder_Database";
            string[] a = Directory.GetFiles(path);
            foreach (string filename in a)
            {
                Text = File.ReadAllText(filename);
                string[] b = Text.Split(new string[] { "â?o", "\"", "&ldquo;", "â??", "&rdquo;" }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 1; i < b.Count(); i += 2)
                {
                    ListOfQuotes.Add(b[i]);
                }
            }
            File.AppendAllLines(path2, ListOfQuotes);
        }
    }
}
