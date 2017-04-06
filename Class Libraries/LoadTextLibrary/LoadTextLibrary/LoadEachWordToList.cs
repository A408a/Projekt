using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace LoadTextLibrary
{
    public class LoadEachWordToList : LoadStringToList
    {
        public List<string> Words = new List<string>(); // Indeholder hvert enkelte ord i teksten
        public string[] eachWord;

        public LoadEachWordToList(string filePath) : base(filePath)
        {
            this.LoadText();
        }

        public override void LoadText()
        {
            base.LoadText();

            foreach (string i in Lines)
            {
                string[] eachWord;
                string[] separators = { ",", ".", "!", "?", ";", ":", " ", "-", "\"", "(", ")"};

                eachWord = i.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                InsertWordsToList(eachWord);
            }
        }

        public void InsertWordsToList(string[] eachword)
        {
            foreach(string i in eachword)
            {
                Words.Add(i);
            }
        }

        public string GetWord(int i)
        {
            return Words[i];
        }

        public void PrintContent()
        {
            foreach(string i in Words)
            {
                Console.WriteLine(i);
            }
        }
    }
}
