using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChangeDatabase
{
    public class ChangeDatabase
    {
        #region Members
        private List<string> Article = new List<string>();

        private string Source = "TestFolder"; // Change_Database
        private string Target; // Navnet på tag.
        private string FileName;
        private string SourcePath;
        private string TargetPath;
        private string path;
        private string TrueOrFalse;
        private string Tag;
        #endregion

        // Input from User Input or Fake News result. - BRUGES TIL ADD
        public ChangeDatabase(List<string> Article /* string TrueOrFalse */) //Input her vil være den tekst som skal rettes. Hvad indlæses den som? Tror List.
        {
            this.Article = Article;
            // this.TrueOrFalse = TrueOrFalse;
            PathMaker();
        }

        // Removes all instances of certain article.
        public ChangeDatabase(string FileName)
        {
            this.FileName = FileName;
            PathMaker();
        }

        // Removes single instance of certain article.
        //public ChangeDatabase(string FileName /* Tag */ /* string TrueOrFalse */)
        //{
        //  this.FileName = FileName;
        // this.TrueOrFalse = TrueOrFalse;
        // Something for the tag.
        // PathMaker();
//            TargetPath = Path.Combine(path, Target);
        //}

        private void PathMaker()
        {
            path = Directory.GetCurrentDirectory();
            //Path goes 3 folders up.
            path = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));
            SourcePath = Path.Combine(path, Source);
        }

        public void RemoveArticleFromDatabase()
        {
            // Directory info of Database.
            DirectoryInfo DatabaseDirectories = new DirectoryInfo(SourcePath);
            // Goes through all tags in database
            foreach(DirectoryInfo Tags in DatabaseDirectories.GetDirectories())
            {
                // Goes through the Tag True and False folders.
                foreach(DirectoryInfo TrueOrFalseFolder in Tags.GetDirectories())
                {
                    // Goes through all articles in of the Tag true or False folder.
                    foreach(FileInfo Article in TrueOrFalseFolder.GetFiles())
                    {
                        // If article matches the input article, remove it.
                        if(Article.Name == FileName)
                        {
                            Article.Delete();
                        }
                    }
                }
            }
        }

        //Denne skal måske fjernes, hvis den ikke 
        public void RemoveArticleFromTag(string Tag, string TrueOrFalse)
        {
            this.Tag = Tag;
            this.TrueOrFalse = TrueOrFalse;

            // Creating source and destionation path for file.
            string TargetPath = Path.Combine(SourcePath, Tag, TrueOrFalse, FileName);
            FileInfo Article = new FileInfo(TargetPath);
            Console.WriteLine(Article);
            if (Article.Exists)
            {
                Article.Delete();
            }
            else
            {
                Console.WriteLine("Article not found.");
            }
        }

        private void FindTag(/*TrueOrFalse*/)
        {
            // Input vil være stien til databasen.
            // I midlertidige writelines skal vi finde det nødvendige tag, eller oprette en ny.

            // Her skal programmet finde, hvilken tag som den valgte artikel skal ligge inde under.
            // Det kunne altså være en ide, at det kom som noget af det sidste.
            // Om det bliver indsat i falsk eller sandt, er vel et input.
            bool done = false;
            DirectoryInfo dirInfo;
            do
            {
                dirInfo = MidlertidigUserinput();
                Console.WriteLine("Enter current tag(1), new tag(2) or are you done(3)?");
                string userChoice = Console.ReadLine();
                if (userChoice == "1")
                {
                    Console.WriteLine("Under what tag?");
                    string tag = Console.ReadLine();
                     CreateFile(Path.Combine(dirInfo.ToString(), tag));
                }
                else if (userChoice == "2")
                {
                    Console.WriteLine("What is your new tag?");
                    string tag = Console.ReadLine();
                    string pathToTag = Path.Combine(dirInfo.ToString(), tag);
                    CreateDirectoryTag(pathToTag);
                    CreateFile(pathToTag);
                }
                else
                    done = true;
            }
            while (done != true);

            CreateFile(Path.Combine(dirInfo.ToString(), "All_articles"));
            Console.WriteLine("done");
            Console.ReadLine();
        }

        private void CreateDirectoryTag(string path)
        {
            Directory.CreateDirectory(path);
            //Directory.CreateDirectory(Path.Combine())
            Directory.CreateDirectory(path + "\\" + "True");
            Directory.CreateDirectory(path + "\\" + "False");
        }

        // Dette skal gøres i winform. Den spørger om tag.
        private DirectoryInfo MidlertidigUserinput()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(SourcePath);

            foreach (DirectoryInfo Dir in dirInfo.GetDirectories())
            {
                Console.WriteLine(Dir);
            }

            return dirInfo;
        }

        // TrueFalse skal måske laves i property, da den er irreterende at flytte rundt i prog.
        public void AddArticle(/*(string TrueFalse*/)
        {
            // localFile = hele navnet på filen.


            FindTag();
        }

        // DirInfo = Sti information
        private void CreateFile(string PathToTag /*string TrueOrFalse*/)
        {
            //string localFile = UserCreateFileName(); // Her laves filens navn. Skal måske laves i winform.
            string localFile = "01_02_2007_testfile.txt";
            string TrueOrFalse = "True";

            PathToTag = Path.Combine(PathToTag, TrueOrFalse);
            
            // Opretter path for fil og filens tekst.
            string destFile = Path.Combine(PathToTag, localFile);

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
        }

        public string UserCreateFileName()
        {
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
            return localFile;
        }

    }

}