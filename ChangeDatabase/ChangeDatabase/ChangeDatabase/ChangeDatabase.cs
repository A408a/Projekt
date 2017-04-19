using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChangeDatabase
{
    class ChangeDatabase
    {
        #region Members
        private List<string> Article = new List<string>();

        // File fields. Disse er måske arvet.
        private string FileName;
        private string Source = "Folder_test";
        private string Target = "Folder_test\\folder";
        private string SourcePath;
        private string TargetPath;
        #endregion

        // Input from User Input or Fake News result. - BRUGES TIL ADD
        public ChangeDatabase(List<string> Article) //Input her vil være den tekst som skal rettes. Hvad indlæses den som? Tror List.
        {
            this.Article = Article;
            PathMaker();
        }
        
        public ChangeDatabase(string FileName)
        {
            this.FileName = FileName;
            PathMaker();
        }

        private void PathMaker()
        { 
            string Path = Directory.GetCurrentDirectory();
            // removes \ChangeDatabase\bin\Debug from directory.
            Path = Path.Remove(Path.Length - 25); //DETTE SKAL OPTIMERES OG IKKE EKSPLICIT. ****
            SourcePath = System.IO.Path.Combine(Path, Source);
            TargetPath = System.IO.Path.Combine(Path, Target);
        }

        public void RemoveArticle()
        {
            // Creating source and destionation path for file.
            string sourceFile = Path.Combine(SourcePath, FileName);
            string destFile = Path.Combine(TargetPath, FileName);

            // If folder is not found, create one.
            if (!Directory.Exists(TargetPath))
            {
                Directory.CreateDirectory(TargetPath);
            }

            if (Directory.Exists(sourceFile))
            {
                // Copy file to chosen file. Overwrite if file is already there
                File.Copy(sourceFile, destFile, true);
            }
            
            // If file is in both source and dest. Delete file in source.
            if (File.Exists(destFile) && File.Exists(sourceFile))
                File.Delete(sourceFile);

            Console.WriteLine("done");
            Console.ReadLine();
        }

        public void AddArticle()
        {
            #region writelines

            // DETTE SKAL GØRES I WINFORM, MEN LIGGE PÅ NUVÆRENDE TIDSPUNKT SOM HARDCODE
            Console.WriteLine("Please enter the date, the newsarticle was written in format dd_mm_yy_Name");
            Console.WriteLine("First enter day of the month with _, then press enter");
            string dayOfArticle = Console.ReadLine();
            Console.WriteLine("Then enter month with _, press enter afterwarts");
            string monthOfArticle = Console.ReadLine();
            Console.WriteLine("Enter the year");
            string yearOfArticle = Console.ReadLine();
            string dateOfArticle = dayOfArticle + monthOfArticle + yearOfArticle;
            Console.WriteLine("Enter article name");
            string articleName = Console.ReadLine();
            string localFile = dateOfArticle + articleName + ".txt";
            #endregion 
            // localFile = hele navnet på filen.
            
            // Opretter path for fil og filens tekst.
            string destFile = Path.Combine(SourcePath, localFile);
            
            // Sikre sig at der ikke bliver overwrited.
            if (!File.Exists(destFile))
            {
                foreach (string word in Article)
                {
                    FileName += word + " ";
                }
                File.WriteAllText(destFile, FileName);
            }
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