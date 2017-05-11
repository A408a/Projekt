using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadTextLibrary;
using CosineSimilarityLibrary;

namespace CompareTexts
{
    public class CompareTextUsingCosineSimilarity : CompareText
    {
        // If changes are made to this class, update ComapareTextUsingCosineTestClass aswell 

        public CompareTextUsingCosineSimilarity(List<string> text, string[] tags) : base(text, tags)
        {
            CompareTextWithDatabase();
        }

        // Returns the greatest CosineSimilarity optained by comparing the text to all texts in the directory 
        public override decimal CompareWithTexts(List<string> paths)
        {
            int greatestSimilarity = 0;

            foreach (string path in paths) // Gets CosineSimilarity for all false articles 
            {
                var databaseText = new LoadEachWordToList(path);

                var compareTexts = new CalculateCosine(TextToBeCompared, databaseText.Words);

                // Happens if the CosineSimilarity between the two current texts are the greatest so far 
                if (compareTexts.Procent > greatestSimilarity)
                    greatestSimilarity = compareTexts.Procent;
            }

            return (decimal)greatestSimilarity;
        }

    }
}
