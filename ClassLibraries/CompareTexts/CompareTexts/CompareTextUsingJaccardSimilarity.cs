using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadTextLibrary;
using JaccardSimilarityLibrary;

namespace CompareTexts
{
    public class CompareTextUsingJaccardSimilarity : CompareText
    {
        // If changes are made to this class, update ComapareTextUsingJaccardTestClass aswell 

        public CompareTextUsingJaccardSimilarity(List<string> text, string[] tags) : base(text, tags)
        { }

        // Returns the greatest JaccardSimilarity optained by comparing the text to texts in the directory 
        public override decimal CompareWithTexts(List<string> paths) 
        {
            decimal greatestSimilarity = 0;

            foreach (string path in paths) // Gets JaccardSimilarity for all false articles 
            {
                var databaseText = new LoadEachWordToList(path);

                var compareTexts = new JaccardSimilarity(TextToBeCompared, databaseText.Words);

                // Happens if the jaccardSimilarity between the two current texts are the greatest so far 
                if (compareTexts.Similarity > greatestSimilarity)
                    greatestSimilarity = compareTexts.Similarity;
            }

            return greatestSimilarity;
        }

    }
}
