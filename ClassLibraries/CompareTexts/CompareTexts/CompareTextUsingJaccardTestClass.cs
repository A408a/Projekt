using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadTextLibrary;
using System.IO;
using JaccardSimilarityLibrary;

namespace CompareTexts
{
    public class CompareTextUsingJaccardTestClass : CompareText
    {
        /* This class is used to test CompareTextUsingJaccardSimilarity, since the directory
         * is diffrent. Therefore if CompareTextUsingJaccard is updated this class should be
         * updated aswell in order to test the updates made to the class 
         * Last updated: 10-05-2017 */

        public CompareTextUsingJaccardTestClass(List<string> text, string[] tags) : base(text, tags)
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

        /* The directory is diffrent when running test, therefore the below method is overriden and 
         * changed to not add ..\..\..\ to the file path */
        public override List<string> FindDatabaseFilePaths(string tag, string trueOrFalse)
        {
            string directoryName = "Nyheder_Database";
            string path = Directory.GetCurrentDirectory();

            // path = Path.GetFullPath(Path.Combine(path, @"..\..\..\")); // Goes 3 steps up the directory hierarchy

            path = Path.Combine(path, directoryName, tag, trueOrFalse); // Combines the toal path to the wanted directory

            var directoryInformation = new DirectoryInfo(path); // Get information about the directory 

            var filePaths = new List<string>(); // Contains paths to all files in the given directory 

            foreach (FileInfo f in directoryInformation.GetFiles()) // Adds each filepath to the list 
            {
                filePaths.Add(f.FullName);
            }

            return filePaths;
        }

    }
}
