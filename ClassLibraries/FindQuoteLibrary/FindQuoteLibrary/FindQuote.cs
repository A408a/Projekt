using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevenshteinDistanceSingleStringLibrary;

namespace FindQuoteLibrary
{
    public class FindQuote
    {
        #region Peoperties, fields and constructor
        private string TextFromUser { get; set; }
        private List<double> ListOfLevenshteinDistances;

        public FindQuote(string textFromUser)
        {
            this.TextFromUser = textFromUser;

            CheckQuote();
        }
        #endregion

        #region Methods

        private bool CheckQuote()
        {
            if (ContainsQuote(TextFromUser))
            {
                string[] ArrayOfStringsUser = TextFromUser.Split(new string[] { "â?o", "\"", "&ldquo;", "â??", "&rdquo;" },
                                                                 StringSplitOptions.None);
                string[] ArrayOfStringsDatabase = Resource.QuoteDatabase.Split(new string[] { }, StringSplitOptions.None);

                int AmountOfQuotesFromUser = ArrayOfStringsUser.Count();
                int AmountOfQuotesFromDatabase = ArrayOfStringsDatabase.Count();

                for (int i = 1; i <= (AmountOfQuotesFromUser - 1); i += 2)
                {
                    for (int j = 0; j < AmountOfQuotesFromDatabase; j++)
                    {
                        LevenshteinDistance LD = new LevenshteinDistance(ArrayOfStringsUser[i], ArrayOfStringsDatabase[j]);
                        ListOfLevenshteinDistances.Add(LD.CompareTexts());
                    }
                }

                return true;
            }
            else
                return false;
        }

        private bool ContainsQuote(string textToFindQuote)
        {
            if (textToFindQuote.Contains("â?o") || textToFindQuote.Contains("\"") ||
                textToFindQuote.Contains("&ldquo;") || textToFindQuote.Contains("â??") ||
                textToFindQuote.Contains("&rdquo;"))
                return true;
            else
                return false;
        }

        #endregion
    }
}
