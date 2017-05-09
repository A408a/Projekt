using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChangeDatabase
{
    public class AutomaticRemoveFromDatabase
    {
        
        public string Dir()
        {
            string path = Directory.GetCurrentDirectory();
            path = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\"));
            return path;
        }

        public void FindOutdatedFolder()
        {
            string DirectoryName = "TestFolder"; //Nyheder_Database
            string path = Directory.GetCurrentDirectory();
            
            //Path goes 3 folders up.
            path = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\"));

            path = Path.Combine(path, DirectoryName);
            DirectoryInfo Dir = new DirectoryInfo(path);

            foreach (DirectoryInfo Tag in Dir.GetDirectories())
            {
                BrowseTags(Tag);
            }
        }

        private void BrowseTags(DirectoryInfo Dir)
        {
            DirectoryInfo DirTrue = new DirectoryInfo(Path.Combine(Dir.FullName, "True"));
            DirectoryInfo DirFalse = new DirectoryInfo(Path.Combine(Dir.FullName, "False"));

            // Goes through all true articles
            foreach (FileInfo file in DirTrue.GetFiles())
                FindOutdatedFile(file.ToString(), file);

            // Goes through all false articles
            foreach (FileInfo file in DirFalse.GetFiles())
                FindOutdatedFile(file.ToString(), file);
        }

        private void FindOutdatedFile(string File, FileInfo FileInformation)
        {
            try
            {
                int month = Int32.Parse(File.Substring(3, 2));
                int year = Int32.Parse(File.Substring(6, 4));

                // If an article has an invalid Date.
                if (year > DateTime.Now.Year || year < 0 || month > 12 || month < 0)
                    throw new ArgumentException();

                // If current year is equal to article year
                if (year == DateTime.Now.Year)
                {
                    // If article is less than 3 months old
                    if (month < DateTime.Now.Month - 3)
                        RemoveFile(FileInformation);
                }
                else
                {
                    RemoveFile(FileInformation);
                }
            }

            // month or year was not converted to int.
            catch (FormatException)
            {
                HandleException(FileInformation);
            }

            // Date was invalid
            catch (ArgumentException)
            {
                HandleException(FileInformation);
            }
        }

        private void RemoveFile(FileInfo FileInformation)
        {
            FileInformation.Delete();
        }

        private void HandleException(FileInfo FileInformation)
        {
            
            // DETTE SKAL LAVES I WINFORM
            Console.WriteLine($"Found invalid article. \n{FileInformation.FullName}");
            Console.WriteLine("Remove the article(0), or change the date to today?(1)");
            string UserChoice = Console.ReadLine();


            if (UserChoice == "0")
                FileInformation.Delete();
            else
            {
                // DETTE SKAL LAVES I WINFORM
                Console.WriteLine("Enter title on article");
                string Title = Console.ReadLine() + ".txt";
                string CurrentDate = DateTime.Now.ToString("dd_MM_yyyy_");
                string TargetPath = FileInformation.DirectoryName;

                Title = "\\" + CurrentDate + Title;
                TargetPath = Path.Combine(TargetPath + Title);
                File.Move(FileInformation.FullName, TargetPath);
            }
        }
    }
}
