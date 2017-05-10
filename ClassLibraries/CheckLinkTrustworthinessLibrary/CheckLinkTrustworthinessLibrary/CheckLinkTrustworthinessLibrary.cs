using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckLinkTrustworthinessLibrary.Properties;

namespace CheckLinkTrustworthinessLibrary
{
    public class CheckLinkTrustworthiness
    {
        private string LinkFromPrompt;
        public bool DoesLinkToFakeNews = false;
        private List<string> ListOfFakeNewsWebsites = new List<string>();
        
        public CheckLinkTrustworthiness(string linkFromPrompt)
        {
            this.LinkFromPrompt = linkFromPrompt;

            IsLinkNull();
        }

        //Checks if link is null.
        //If link is not null call check link.
        private void IsLinkNull()
        {
            if (LinkFromPrompt == null)
                throw new ArgumentNullException("Input was null.");
            else
                CheckLink();
        }

        //Checks if the link the user has put in contains a fake domain.
        private void CheckLink()
        {
            //Uses the database as a resource which is read as a string. 
            //Splits the string at newlines into an array of strings,
            //which is turned to a list and assigned to ListOfFakeNewsWebsites.
            ListOfFakeNewsWebsites = Resources.FakeNewsWebsites.Split(new string[] { Environment.NewLine },
                                                                      StringSplitOptions.RemoveEmptyEntries).ToList();

            int NumberOfFakeNewsWebsites = ListOfFakeNewsWebsites.Count();

            for (int i = 0; i < NumberOfFakeNewsWebsites && DoesLinkToFakeNews != true; i++)
                if (LinkFromPrompt.Contains(ListOfFakeNewsWebsites[i]))
                    DoesLinkToFakeNews = true;
        }

        //Prints if the link leads to a fake news domain.
        //private void PrintResult()
        //{
        //    if (DoesLinkToFakeNews)
        //        Console.WriteLine("Link does not lead to a trustworthy site. ");
        //    else
        //        Console.WriteLine("");
        //}
    }
}
