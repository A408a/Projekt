using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChangeDatabase
{
    class AutomaticRemoveFromDatabase
    {
        
        public void FindOutdateFolder()
        {
            string DirectoryName = "Testfolder";
            string Path = Directory.GetCurrentDirectory();
            
            // removes \ChangeDatabase\bin\Debug from directory.
            Path = Path.Remove(Path.Length - 25); //DETTE SKAL OPTIMERES OG IKKE EKSPLICIT. ****
            Path = System.IO.Path.Combine(Path, DirectoryName);
            DirectoryInfo Dir = new DirectoryInfo(Path);

            foreach (FileInfo file in Dir.GetFiles())
                FindOutdatedFile(file.ToString(), file);
        }

        private void FindOutdatedFile(string File, FileInfo FileInformation)
        {
            try
            {
                int month = Int32.Parse(File.Substring(3, 2));
                int year = Int32.Parse(File.Substring(6, 4));

                if (year > DateTime.Now.Year || year < 0 || month > 12 || month < 0)
                    throw new ArgumentException();

                // If current year is equal to article year
                if (year == DateTime.Now.Year)
                {
                    // If article is less than 3 months old
                    if (month > DateTime.Now.Month - 3)
                        Console.WriteLine(File);
                    else
                        RemoveFile(FileInformation);
                }
                else
                {
                    RemoveFile(FileInformation);
                }

                Console.ReadLine();
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
                string CurrentDate = DateTime.Now.Day.ToString() + "_" 
                                   + DateTime.Now.Month.ToString() + "_"
                                   + DateTime.Now.Year.ToString() + "_";
                string TargetPath = FileInformation.DirectoryName;

                Title = "\\" + CurrentDate + Title;
                TargetPath = Path.Combine(TargetPath + Title);
                File.Move(FileInformation.FullName, TargetPath);
            }
        }
    }
}
