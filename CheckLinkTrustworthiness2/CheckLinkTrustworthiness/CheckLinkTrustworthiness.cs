using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadTextLibrary;
//- HUSK AT LAVE VIDERE KALD TIL NÆSTE KLASSE/METODE HVIS BRUGER VIL FORTSÆTTE EFTER DE HAR FÅET AT VIDE
//  AT DER LINKES TIL FAKE NEWS

//- HUSK AT ÆNDRE FRA CONSOLE.READLINE OG CONSOLE.WRITELINE TIL WINFORM TING NÅR DET SKAL VIDERE

namespace CheckLinkTrustworthiness
{
    public class CheckLinkTrustworthiness
    {
        private List<string> ListOfFakeNewsWebsites { get; set; }
        private string LinkFromPrompt;
        public bool DoesLinkToFakeNews = false;
        private int LengthOfList;

        public CheckLinkTrustworthiness(List<string> listOfFakeNewsWebsites, string linkFromPrompt)
        {
            this.ListOfFakeNewsWebsites = listOfFakeNewsWebsites;
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
            LengthOfList = ListOfFakeNewsWebsites.Count();
            //Checks if the link the user has put in contains a fake domain.
            for (int i = 0; i < LengthOfList && DoesLinkToFakeNews != true; i++)
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
