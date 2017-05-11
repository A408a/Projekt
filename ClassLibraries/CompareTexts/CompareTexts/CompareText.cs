using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadTextLibrary;
using System.IO;

namespace CompareTexts
{
    public abstract class CompareText
    {
        public List<string> TempTextToBeCompared { get; protected set; } = new List<string>(); // Contains the non splitted text 
        public List<string> TextToBeCompared { get; protected set; } = new List<string>(); // Contains the splitted text 
        public string[] Tags { get; private set; }
        public decimal FalseArticlesSimilarity { get; private set; }
        public decimal TrueArticlesSimilarity { get; private set; }

        public CompareText(List<string> text, string[] tags)
        {
            this.Tags = tags;
            this.TempTextToBeCompared = text;
            SplitTempText();

            CompareTextWithDatabase();
        }

        public void SplitTempText() // Gets a list which contains each word in the given text 
        {
            // Splits each string in the list according to the seperators specified in ListSplitSentencesToWords 
            var split = new ListSplitSentencesToWords(TempTextToBeCompared); 
            TextToBeCompared = split.Result; // Gets the splitted list 
        }
        public void CompareTextWithDatabase() // Decides if the text is to be compared to all text or text with a certain tag/tags
        {
            if (Tags != null) // Happens if a tag/tags is provided to the instance 
                CompareTextAccordingToTags(); // Compares the text with all texts with the given tag/tags 
            else 
                CompareTextToCompleteDatabase(); // Compares the text with all texts in the database 
        }

        public virtual void CompareTextToCompleteDatabase() // Compares the text with all texts in the database 
        {
            List<string> filePathsFalse = FindDatabaseFilePaths("All_articles", "False"); // Contains paths to all true articles with the given tag
            List<string> filePathsTrue = FindDatabaseFilePaths("All_articles", "True"); // Contains paths to all false articles with the given tag

            // Similarities is set to 0 before comparisons are initiated 
            FalseArticlesSimilarity = 0;
            TrueArticlesSimilarity = 0;

            FalseArticlesSimilarity = CompareWithTexts(filePathsFalse); // Gets the greatest similiarty obtained from false articles
            TrueArticlesSimilarity = CompareWithTexts(filePathsTrue); // Gets the greatest similiarty obtained from true articles
        }
        public virtual void CompareTextAccordingToTags() // Compares the text with all texts with the given tag/tags
        {
            // Similarities is set to 0 before comparisons are initiated 
            FalseArticlesSimilarity = 0;
            TrueArticlesSimilarity = 0;

            // Contains the temporary greatest similarity between texts with a given tag 
            decimal tempFalseArticlesJaccardSimilarity = 0;
            decimal temptrueArticlesJaccardSimilarity = 0;

            foreach (string tag in Tags)
            {
                List<string> filePathsFalse = FindDatabaseFilePaths(tag, "False"); // Contains paths to all true articles with the given tag
                List<string> filePathsTrue = FindDatabaseFilePaths(tag, "True"); // Contains paths to all false articles with the given tag

                // Similarities is set to 0 before comparisons are initiated 
                tempFalseArticlesJaccardSimilarity = 0;
                temptrueArticlesJaccardSimilarity = 0;

                tempFalseArticlesJaccardSimilarity = CompareWithTexts(filePathsFalse); // Gets the greatest similiarty obtained from false articles
                temptrueArticlesJaccardSimilarity = CompareWithTexts(filePathsTrue); // Gets the greatest similiarty obtained from true articles

                // Happens if the similairty between false texts, in the current tag, is the greatest so far 
                if (tempFalseArticlesJaccardSimilarity > FalseArticlesSimilarity)
                    FalseArticlesSimilarity = tempFalseArticlesJaccardSimilarity;

                // Happens if the similairty between true texts, in the current tag, is the greatest so far 
                if (temptrueArticlesJaccardSimilarity > TrueArticlesSimilarity)
                    TrueArticlesSimilarity = temptrueArticlesJaccardSimilarity;
            }
        }
        public virtual List<string> FindDatabaseFilePaths(string tag, string trueOrFalse) // Gets all file paths in the database according to the parameters 
        {
            string directoryName = "Nyheder_Database";
            string path = Directory.GetCurrentDirectory();

            path = Path.GetFullPath(Path.Combine(path, @"..\..\..\")); // Goes 3 steps up the directory hierarchy

            path = Path.Combine(path, directoryName, tag, trueOrFalse); // Combines the toal path to the wanted directory

            var directoryInformation = new DirectoryInfo(path); // Get information about the directory 

            var filePaths = new List<string>(); // Contains paths to all files in the given directory 

            foreach (FileInfo f in directoryInformation.GetFiles()) // Adds each filepath to the list 
            {
                filePaths.Add(f.FullName);
            }

            return filePaths;
        }

        public abstract decimal CompareWithTexts(List<string> paths);

    }
}
