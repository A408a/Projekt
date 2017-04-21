using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevenshteinDistanceLibrary
{
    public class LevenshteinDistance
    {
        private List<int> ListLevDis = new List<int>();
        public List<string> Basis { get; set; }
        public List<string> Target { get; set; }
        public int TotalCount = 0;
        private int _charsInTextA;
        private int _charsInTextB;
        private int _linesInTextA;
        private int _linesInTextB;
        private double value = 0;
        private double levenshteinDistanceDouble = 0;

        public LevenshteinDistance(List<string> a, List<string> b, int CharsInTextA,
                                   int CharsInTextB, int LinesInTextA, int LinesInTextB)//Constructor, som sætter streng a lig med Basis og b lig med Target
        {
            Basis = a;
            Target = b;
            this._charsInTextA = CharsInTextA;
            this._charsInTextB = CharsInTextB;
            this._linesInTextA = LinesInTextA;
            this._linesInTextB = LinesInTextB;

            CompareTexts();
            Print();
        }

        public void CompareTexts()
        {
            if (_charsInTextA > _charsInTextB)  //Hvis tekst A er større end tekst B lægges A i B, og B i A
            {
                Swap();
            }

            for (int i = 0; i < _linesInTextA; i++) //Hver linje 'i' i tekst A bliver kørt igennem hver linje 'j' i tekst B
            {
                for (int j = 0; j < _linesInTextB; j++)
                {
                    if (!(string.IsNullOrEmpty(Basis[i]) || string.IsNullOrEmpty(Target[j])))
                    {
                        ListLevDis.Add(CalcLevenshteinDistance(Basis[i], Target[j])); //Beregner Levenshtein Distance
                                                                                      //Returværdien lægges i en liste
                    }
                }
                levenshteinDistanceDouble += ListLevDis.Min(); //Den mindste LD for hver linje i tekst A i forhold til tekst B
                ListLevDis.Clear();  //Listen bliver clearet
            }
            double LevDisPct = ((1 - (levenshteinDistanceDouble / _charsInTextA)) * 100); //Finder LD i procent
            value = Math.Round(LevDisPct, 2);  //Afrunder værdien til 2 decimaler
        }

        public void Swap() //Ombytter tekst A og tekst B
        {
            List<string> tempList = new List<string>();

            tempList = Basis;
            Basis = Target;
            Target = tempList;

            int tempChars = _charsInTextA;
            _charsInTextA = _charsInTextB;
            _charsInTextB = tempChars;

            int tempLines = _linesInTextA;
            _linesInTextA = _linesInTextB;
            _linesInTextB = tempLines;
        }

        public int CalcLevenshteinDistance(string Basis, string Target) //Beregner Levenshtein Distance
        {
            int counter = 0;
            int lengthB = Basis.Length;
            int lengthT = Target.Length;

            var distances = new int[lengthB + 1, lengthT + 1]; //Opretter en matrix med rækker og søjler svarende til antal
                                                               //chars i Basis-linje og Target-linje
                                                               // for (int i = 0; i <= lengthB; distances[i, 0] = i++) { ++Total;}   //Fylder vores matrix's rækker med 0 .. Forkert
                                                               // for (int j = 0; j <= lengthT; distances[0, j] = j++) { ++Total;}  //Fylder vores matrix's søjler med 0 .. Forkert

            distances[0, 0] = 0; // Startværdi = 0,0
            for (int i = 1; i <= lengthB; i++) //Sammenligner char for char streng B med streng T
            {
                distances[i, 0] = i;            // Fyld rækker med 0, 1, 2.. n
                for (int j = 1; j <= lengthT; j++)
                {

                    distances[0, j] = j;        // Fyld søjler med 0, 1, 2.. n
                    counter++;
                    int cost = Target[j - 1] == Basis[i - 1] ? 0 : 1; //Hvis T og B er ens tillægges cost værdien 0 ellers 1
                    distances[i, j] = Math.Min
                        (
                        Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1), //Der findes den mindste værdi 
                        distances[i - 1, j - 1] + cost                             //for de 3 mulige operationer i matricen
                        );
                }
            }
            TotalCount += counter;  //Totale antal sammenligninger char for char
            return distances[lengthB, lengthT]; //Returnerer vores levenshtein distance fra det sidste element i matricen
        }

        public void Print() //Der printes
        {
            Console.WriteLine($"Levenshtein similarity: {value}%");
        }
    }
}
