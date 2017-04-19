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

        //        public AutomaticRemoveFromDatabase(){        }
        public void FindOutdatedFile()
        {
            string DirectoryName = "Testfolder";
            string Path = Directory.GetCurrentDirectory();
            // removes \ChangeDatabase\bin\Debug from directory.
            Path = Path.Remove(Path.Length - 25);
            Path = System.IO.Path.Combine(Path, DirectoryName);
            Console.WriteLine(Directory.GetFiles(Path));
            Console.WriteLine(Path);
            Console.ReadLine();

        }

    }
}
