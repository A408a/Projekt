using System;
using System.Collections.Generic;
using System.Linq;
using CheckLinkTrustworthinessLibrary.Properties;

namespace CheckLinkTrustworthinessLibrary
{
    public class CheckLinkTrustworthiness
    {
        //Checks if linkToCheck is in the correct form.
        public bool IsLinkValid(string linkToCheck)
        {
            if (Uri.IsWellFormedUriString(linkToCheck, UriKind.Absolute))
                return true;
            else
                throw new ArgumentException("Format was invalid!");
        }

        //Checks if the link from the user contains a fake domain.
        public bool CheckLink(string linkToCheck)
        {

            //Uses the database as a resource which is read as a string. 
            //Splits the string at newlines into an array of strings,
            //which is turned to a list and assigned to ListOfFakeNewsWebsites.
            List<string> ListOfFakeNewsWebsites = Resources.FakeNewsWebsites.Split(new string[] { Environment.NewLine },
                                                                                   StringSplitOptions.RemoveEmptyEntries)
                                                                                   .ToList();

            int NumberOfFakeNewsWebsites = ListOfFakeNewsWebsites.Count();

            //Checks if the domain of the fake news website is contained in the link from the prompt.
            for (int i = 0; i < NumberOfFakeNewsWebsites; i++)
            {
                if (linkToCheck.Contains(ListOfFakeNewsWebsites[i]))
                    return true;
            }
            return false;
        }

    }
}
