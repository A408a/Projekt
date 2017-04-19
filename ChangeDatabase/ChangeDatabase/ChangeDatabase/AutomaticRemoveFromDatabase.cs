using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// Efter "3" måneder, skal en artikel fjernes.
// For dato på artikel:
// dd_mm_yy_NAVN



    // Se fil navn - se directoryinfo
    // kontrol af dato
    // Fjern fil
    // I ADD skal der tilføjes dd_mm_yy 


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

            catch (FormatException)
            {
                // month or year was not converted to int. It will simply be ignored.
                
            }
        }

        private void RemoveFile(FileInfo FileInformation)
        {
            // SKAL VI HAVE EN "FOUND X OUTDATED ARTICLE. SHOULD THEY BE REMOVED? "YES" "NO?"
            FileInformation.Delete();
        }
    }
}
