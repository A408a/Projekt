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
                                   int CharsInTextB, int LinesInTextA, int LinesInTextB) 
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
            //Swap the texts if text A is larger than text B.
            if (_charsInTextA > _charsInTextB)
            {
                Swap();
            }

            //The lines 'i' in text A are compared to the linjes 'j' in text B.
            for (int i = 0; i < _linesInTextA; i++) 
            {
                for (int j = 0; j < _linesInTextB; j++)
                {
                    if (!(string.IsNullOrEmpty(Basis[i]) || string.IsNullOrEmpty(Target[j])))
                    {
                        //Calculates the Levenshtein Distance. The return value is added to the list ListLevDis.
                        ListLevDis.Add(CalcLevenshteinDistance(Basis[i], Target[j])); 
                    }
                }
                //For every line in text A the smallest Levenshtein Distance
                //is compoundassigned to levenshteinDistanceDouble.
                levenshteinDistanceDouble += ListLevDis.Min();
                //The list is cleared for the next iteration of the for loop.
                ListLevDis.Clear();
            }
            //Calculates the Levenshtein Distance in percent.
            double LevDisPct = ((1 - (levenshteinDistanceDouble / _charsInTextA)) * 100);
            //Rounds off the Levenshtein Distance to 2 decimals.
            value = Math.Round(LevDisPct, 2);
        }

        public void Swap()
        {
            //Swaps text A and B.

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

        public int CalcLevenshteinDistance(string Basis, string Target)
        {
            int cost = 0;
            int lengthB = Basis.Length;
            int lengthT = Target.Length;

            //Initializes a matrix with rows equal to the number of chars in the Basis string 
            //and columns equal to the number of chars in the Target string.
            var distances = new int[lengthB + 1, lengthT + 1]; 

            //Startvalue of the matrix = 0,0.
            distances[0, 0] = 0; 

            //Compares the Basis 'B' string char by char to the Target 'T' string.
            for (int i = 1; i <= lengthB; i++) 
            {
                //Fills the rows with 0, 1, 2, ..., n.
                distances[i, 0] = i;
                for (int j = 1; j <= lengthT; j++)
                {
                    //Fills the columns with 0, 1, 2, ..., n.
                    distances[0, j] = j;

                    //If T and B are equal, cost is assigned to 0, if not cost is assigned to 1.
                    cost = Target[j - 1] == Basis[i - 1] ? 0 : 1;

                    //The lowest value of the 3 possible matrix-operations is found.
                    distances[i, j] = Math.Min
                        (
                        Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1), 
                        distances[i - 1, j - 1] + cost
                        );
                }
            }
            //Returns the Levenshtein Distance from the last element in the matrix.
            return distances[lengthB, lengthT];
        }

        public void Print()
        {
            //Prints the Levenshtein Distance.
            Console.WriteLine($"Levenshtein similarity: {value}%");
        }
    }
}
