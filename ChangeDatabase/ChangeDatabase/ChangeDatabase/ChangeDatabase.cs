using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// Remove article: Fjern inde i trashbin
// Fjerne = navn
// Tilføj = list

namespace ChangeDatabase
{
    class ChangeDatabase
    {
        #region Members
        private List<string> Article = new List<string>();

        // File fields. Disse er måske arvet.
        private string FileName = "test.txt";
        private string SourcePath = @"C:\Users\Jesper\Dropbox\AAU\P2\Program\Folder_test";
        private string TargetPath = @"C:\Users\Jesper\Dropbox\AAU\P2\Program\Folder_test\folder";

        #endregion

        // Input from User Input or Fake News result. - BRUGES TIL ADD
        public ChangeDatabase(List<string> Article) //Input her vil være den tekst som skal rettes. Hvad indlæses den som? Tror List.
        {
            this.Article = Article;
        }
        
        // HER SKAL INDLÆSES STRING - BRUGES TIL REMOVE
        public ChangeDatabase()
        {// this is a test
        }

        public void RemoveArticle()
        {
            /*
             For bare at fjerne filen:
             System.IO.File.Delete(sourceFile);
             */

            // I stedet for at fjerne artiklen helt, kan det i stedet være en ide at rykke den over i en anden mappe.
            // https://msdn.microsoft.com/en-us/library/cc148994.aspx

            // Creating source and destionation path for file.
            string sourceFile = System.IO.Path.Combine(SourcePath, FileName);
            string destFile = System.IO.Path.Combine(TargetPath, FileName);

            // If folder is not found, create one.
            if (!Directory.Exists(TargetPath))
            {
                Directory.CreateDirectory(TargetPath);
            }
            // Copy file to chosen file. Overwrite if file is already there
            File.Copy(sourceFile, destFile, true);

            // If file is in both source and dest. Delete file in source.
            if (File.Exists(destFile) && System.IO.File.Exists(sourceFile))
                File.Delete(sourceFile);

            Console.WriteLine("done");
            Console.ReadLine();
        }

        public void AddArticle()
        {
            //Den valgte artikel ligger som field.
            //Her programmet kun tilføje artiklen til databasen. 
            // for at lave en txtfil, brug File.WriteAllLines
            // https://msdn.microsoft.com/da-dk/library/8bh11f1k.aspx

            // Tilføjer dato til filnavnet på nyhedsartiklen. 
            Console.WriteLine("Please enter the date, the newsarticle was written in format dd_mm_yy_Name");
            string dateOfArticle = Console.ReadLine();
            FileName = dateOfArticle + FileName;

            // Opretter path for fil og filens tekst.
            string destFile = System.IO.Path.Combine(SourcePath, FileName);
            string text = "YabbaDabbaDUUU";

            // Sikre sig at der ikke bliver overwrited.
            if (!File.Exists(destFile))
                File.WriteAllText(destFile, text);
            else
                Console.WriteLine("Article already in database");

            // Kontrol af, at alt virkede.
            if(File.Exists(destFile))
                Console.WriteLine("Done");
            else
                Console.WriteLine("Fail");
            Console.ReadLine();
        }

    }
}