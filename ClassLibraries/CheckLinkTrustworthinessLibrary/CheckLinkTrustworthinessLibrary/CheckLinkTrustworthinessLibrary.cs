using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckLinkTrustworthinessLibrary.Properties;
using System.IO;

//- HUSK AT ÆNDRE FRA CONSOLE.READLINE OG CONSOLE.WRITELINE TIL WINFORM TING NÅR DET SKAL VIDERE

namespace CheckLinkTrustworthinessLibrary
{
    public class CheckLinkTrustworthiness
    {
        private string LinkFromPrompt;
        public bool DoesLinkToFakeNews = false;
        private int LengthOfList;
        private List<string> ListOfFakeNewsWebsites = new List<string>();
        
        public CheckLinkTrustworthiness(string linkFromPrompt)
        {
            this.LinkFromPrompt = linkFromPrompt;

            IsLinkNull();
        }

        private void IsLinkNull()
        {
            //Checks if link is null.
            if (LinkFromPrompt == null)
                throw new ArgumentNullException("Input was null.");
            else
            {
                CheckLink();
                PrintResult();
            }
        }

        private void CheckLink()
        {
            //Checks if the link the user has put in contains a fake domain.

            ListOfFakeNewsWebsites = Resources.FakeNewsWebsites.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();

            int NumberOfFakeNewsWebsites = ListOfFakeNewsWebsites.Count();

            for (int i = 0; i < NumberOfFakeNewsWebsites && DoesLinkToFakeNews != true; i++)
            {
                if (LinkFromPrompt.Contains(ListOfFakeNewsWebsites[i]))
                    DoesLinkToFakeNews = true;
            }
        }

        private void PrintResult()
        {
            //Prints if the link leads to a fake news domain.
            if (DoesLinkToFakeNews)
                Console.WriteLine("Link does not lead to a trustworthy site. ");
            else
                Console.WriteLine("");
        }
    }
}
