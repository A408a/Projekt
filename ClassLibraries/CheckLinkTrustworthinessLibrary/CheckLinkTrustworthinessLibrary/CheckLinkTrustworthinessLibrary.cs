using System;
using System.Collections.Generic;
using System.Linq;
using CheckLinkTrustworthinessLibrary.Properties;

namespace CheckLinkTrustworthinessLibrary
{
    public class CheckLinkTrustworthiness
    {
        public CheckLinkTrustworthiness(string linkFromPrompt)
        {
            this.LinkFromPrompt = linkFromPrompt;
            this.DoesLinkToFakeNews = false;

            IsLinkNullOrEmpty();
        }

        private string LinkFromPrompt { get; set; }
        public bool DoesLinkToFakeNews { get; private set; }

        //Checks if link is null.
        //If link is not null call check link.
        private void IsLinkNullOrEmpty()
        {
            if (string.IsNullOrWhiteSpace(LinkFromPrompt))
                throw new ArgumentException("Input was incorrect");
            else
                CheckLink(LinkFromPrompt);
        }

        //Checks if the link from the user contains a fake domain.
        private void CheckLink(string linkToCheck)
        {
            //Uses the database as a resource which is read as a string. 
            //Splits the string at newlines into an array of strings,
            //which is turned to a list and assigned to ListOfFakeNewsWebsites.
            List<string> ListOfFakeNewsWebsites = Resources.FakeNewsWebsites.Split(new string[] { Environment.NewLine },
                                                                      StringSplitOptions.RemoveEmptyEntries).ToList();

            int NumberOfFakeNewsWebsites = ListOfFakeNewsWebsites.Count();

            //Checks if the domain of the fake news website is contained in the link from the prompt.
            for (int i = 0; i < NumberOfFakeNewsWebsites && DoesLinkToFakeNews != true; i++)
                if (linkToCheck.Contains(ListOfFakeNewsWebsites[i]))
                {
                    DoesLinkToFakeNews = true;
                    break;
                }
        }
    }
}
