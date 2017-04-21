using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckLinkTrustworthinessLibrary;

namespace TestCheckLink
{
    class Program
    {
        static void Main(string[] args)
        {
            string Linkbla = Console.ReadLine();
            CheckLinkTrustworthiness qer = new CheckLinkTrustworthiness(Linkbla);
            Console.ReadLine();
            
        }
    }
}
