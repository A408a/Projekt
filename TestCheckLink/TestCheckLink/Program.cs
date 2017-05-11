using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckLinkTrustworthinessLibrary;
using FindQuoteLibrary;
using System.IO;
using System.Text.RegularExpressions;

namespace TestCheckLink
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Method1();
            Console.WriteLine("skriv link:");
            string link = Console.ReadLine();
            CheckLinkTrustworthiness checklink = new CheckLinkTrustworthiness();
            try
            {
                checklink.IsLinkValid(link);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //public static void Method1()
        //{
        //    string Text;
        //    List<string> ListOfQuotes = new List<string>();
        //    //5 mapper op
        //    string path = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName}\\Nyheder_Database";
        //    string path2 = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName}\\DatabaseOfQuotes.txt";
        //    //string path = "D:\\P2GithubMappe\\Projekt\\Nyheder_Database";
        //    string[] files = Directory.GetFiles(path);
        //    //Text = File.ReadAllText(files[0]);
        //    //Text = Regex.Replace(Text, @"\r\n?|\n", " ");
        //    //Console.ReadKey();
        //    foreach (string filename in files)
        //    {
        //        Text = File.ReadAllText(filename);
        //        Text = Regex.Replace(Text, @"\r\n?|\n", " ");
        //        //string[] b = Regex.Split(Text, "(?>=[\"])");
        //        string[] b = Text.Split(new string[] { "â?o", "\"", "&ldquo;", "â??", "&rdquo;" }, StringSplitOptions.RemoveEmptyEntries);
        //        //Console.WriteLine(Text);
        //        //Console.ReadKey();
        //        for (int i = 1; i < b.Count(); i += 2)
        //        {
        //            if (b[i].Length > 25)
        //            {
        //                ListOfQuotes.Add(b[i].Trim(' '));
        //            }
        //        }
        //    }
        //    File.WriteAllLines(path2, ListOfQuotes);
        //}
    }

}
