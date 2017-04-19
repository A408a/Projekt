using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using HtmlAgilityPack;

namespace WebArticleURLToText
{
    class NewsPage
    {
        public static Dictionary<string, Tuple<string, string>> websites = new Dictionary<string, Tuple<string, string>>();  // Instance

        protected HtmlDocument doc;         // Initialization
        private string domain;              // Initialization

        public NewsPage(string website)     //   
        {
            // Webpage name, ID(Potential) and div[]
            websites.Add("www.bbc.com", Tuple.Create("page", "//div[2]/div[2]/div/div[1]/div[1]"));
            websites.Add("www.theguardian.com", Tuple.Create("article", "//div[4]/div/div[1]/div[5]"));
            websites.Add("news.sky.com", Tuple.Create("", "//html/body/div[1]/div[2]/div[1]/div[3]/div"));
            websites.Add("www.washingtonpost.com", Tuple.Create("article-body", "//article"));
            websites.Add("www.huffingtonpost.com", Tuple.Create("us_58f66fece4b0de5bac41a5cd", "//div/div[1]/div[4]"));
            websites.Add("www.cbsnews.com", Tuple.Create("article-entry", "//div[2]"));
            websites.Add("tytnetwork.com", Tuple.Create("post-469222", "//div[2]/div"));
            websites.Add("abcnews.com.co", Tuple.Create("", "//html/body/div"));
            //websites.Add("abcnews.go.com", Tuple.Create("article-feed", "//article[1]/div"));
            //websites.Add("edition.cnn.com", Tuple.Create("body-text", "//div/div[1]"));
            //Fake
            websites.Add("www.breitbart.com", Tuple.Create("post-6443977", "//div"));
            websites.Add("www.cnn.com.de", Tuple.Create("post-705", "//div[3]"));
            //*[@id="us_58f66fece4b0de5bac41a5cd"]/div/div[1]/div[4]
            doc = GetWebsite(website);      // Initialization
        }

        protected HtmlNode GetArticleNode()              // Methode that gets article nods - (A node is any piece of individual content)
        {
            Tuple<string, string> vals = websites[domain];

            return doc.GetElementbyId(vals.Item1).SelectNodes(vals.Item2).Last();    // Gets ID and div.
        }

        protected HtmlDocument GetWebsite(string webaddress)  // Method that downloads the string from website.
        {
            HtmlDocument doc = new HtmlDocument();
            string websiteString = new WebClient().DownloadString(webaddress);
            domain = new Uri(webaddress).Host;
            doc.LoadHtml(websiteString);

            return doc;
        }

        public string GetArticleBody()   // Methode: Gets the article content.
        {
            string returns = "";
            foreach (HtmlNode node in GetArticleNode().SelectNodes("//p"))
            {
                if (node.ChildAttributes("class").Count() != 0)
                {
                    continue;
                }
                returns += node.InnerText + "\n";
            }
            return returns;
        }

        public string GetArticleHead()   // Methode: Gets the article content.
        {
            string returns = "";
            foreach (HtmlNode node in GetArticleNode().SelectNodes("//h1"))
            {
                returns += node.InnerText + "\n";
            }
            return returns;
        }
    }
}
