using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LoadTextLibrary
{
    public class LoadAllText : LoadTextFromFile
    {
        public string Text { get; private set; } // Indeholder den indlæste tekst

        public LoadAllText(string filePath) : base(filePath)
        {
            this.LoadText();
        }

        public override void LoadText() // Indlæser teksten
        {
            Text = File.ReadAllText(FilePath); // Indlæser teksten i en streng
        }

        public override void WriteContent() // Udskriver hele teksten
        {
            Console.WriteLine(Text);
        }
    }
}
