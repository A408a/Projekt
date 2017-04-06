using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LoadTextLibrary
{
    public class LoadStringToList : LoadTextFromFile
    {
        public List<string> Lines { get; private set; } = new List<string>(); // Indeholder de indlæste tekst strenge
        public int LinesInText; // Indeholder antallet af linjer i teksten
        public int CharInText; // Indeholder det totale antal 'chars' i teksten

        public LoadStringToList(string filePath) : base(filePath)
        {
            this.LoadText();
        }

        public override void LoadText() // Indlæser teksten
        {
            Lines = File.ReadLines(FilePath).ToList(); // Indlæser hver linje i txt filen og indsætter dem i listen


            for (int i = Lines.Count - 1; i >= 0; --i) // Går igennem listen fra toppen til bunden 
            {
                if (string.IsNullOrWhiteSpace(Lines[i])) // Sker hvis tekstrengen er tom 
                {
                    Lines.RemoveAt(i);
                }
            }

            LinesInText = Lines.Count(); // Tæller antallet af linjer i teksten
        }

        public string GetLine(int i)
        {
            return Lines[i];
        }

        public int GetAmountOfChars() // Tæller det totalte antal 'chars' i teksten 
        {
            int amountChars = 0; 

            foreach(string i in Lines) // Går igennem alle strenge i listen
            {
                amountChars += CountChars(i);
            }

            return amountChars;
        }

        private int CountChars(string currentString) // Tæller antaget af 'chars' i tekststrengen 
        {
            int charsInString = 0;

            foreach(char i in currentString) // Går igennem alle 'chars' i tekststrengen 
            {
                ++charsInString;
            }

            return charsInString;
        }

        public override void WriteContent() // Udskriver hele teksten
        {
            foreach (string i in Lines)
            {
                Console.WriteLine(i);
            }
        }

        public void WriteSingleLine(int i) // Udskriver en bestemt linje
        {
            Console.WriteLine(Lines[i]);
        }

    }
}
