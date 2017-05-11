using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using HtmlAgilityPack;

namespace WebArticleURLToText
{
    public class NewsPage
    {
        //Dictionary comtainning information partating to the way we read a HTML site/article for a specific newssite 
        private static Dictionary<string, Tuple<string, string>> websites = new Dictionary<string, Tuple<string, string>>();
        //HTMLDocument: Provides top-level programmatic access to a HTML document hosted by the WebBrowser control.
        private HtmlDocument doc;
        private string domain;           
        public string Headline { get; private set; }
        public List<string> BodyText = new List<string>();

        public NewsPage(string webaddress)   
        {
            InitializeWebsite();
            doc = GetWebsite(webaddress);    
            GetArticleHead();
            GetArticleBody();
        }

        //Method that downloads the HTMLcode from website.
        private HtmlDocument GetWebsite(string webaddress)  
        {
            HtmlDocument doc1 = new HtmlDocument();
            //Intanciates a WebClient and specifies the encoding type to UTF8 to prevent weird characters
            WebClient client = new WebClient { Encoding = System.Text.Encoding.UTF8 };
            //Fetches Html document of the webite
            string websiteString = client.DownloadString(webaddress);          
            //Loads the websiteString to a HtmlDocument type              
            doc1.LoadHtml(websiteString);
            //Gets the host name of a website eks. "http:/www.123.com/1341341 --> www.123.com
            domain = new Uri(webaddress).Host;

            return doc1;
            
        }

        //Methode that gets article nods - (A node is any piece of individual content)
        private HtmlNode GetArticleNode()    
        {
            //Gets the Xpath from the dictionary
            //A turple contains a set of values in this case 2
            Tuple<string, string> vals = websites[domain];
            //GetElementById: Retrieves a single HtmlElement using the element's ID attribute as a search key.
            //SelectNodes: Return a list of nodes matching the Xpath expression, but we only want the nodes at the end of the path -> Last();
            return doc.GetElementbyId(vals.Item1).SelectNodes(vals.Item2).Last(); 
            
        }

        //Methode: Gets the article title.
        private void GetArticleHead()   
        {
            //We have one node which is converted to a list of childnodes wherein
            //we search nodes classified with h1. h1: Headline 1, the biggest headline in Htmlcode  
            foreach (HtmlNode node in GetArticleNode().SelectNodes("//h1"))
            {
                //Gets the InnerText inside Html-tags <h1>Innertext</h1>
                Headline = node.InnerText + "\n";
            }
        }

        //Methode: Gets the article content.
        private void GetArticleBody()   
        {
            //We have one node which is converted to a list of childnodes wherein
            //we search nodes classified with p. p: paragraph, for regular text in Htmlcode  
            foreach (HtmlNode node in GetArticleNode().SelectNodes("//p"))
            {
                //If the node is a p class node, the node is ignored
                if (node.ChildAttributes("class").Count() != 0)
                {
                    continue;
                }
                //Gets the InnerText inside Html-tags <p>Innertext</p> and adds it to a list
                BodyText.Add(node.InnerText);
            }
        }

        //Initiaizes preinserted newssites 
        private void InitializeWebsite()
        {
            //Dictionary(Key: Webpage hostname, Value: Turple(Xpath))
            //Xpath: Contains the id/pointer for a newsspecific overall <div class> and a path to where the body text is located
            websites.Add("www.bbc.com", Tuple.Create("page", "//div[2]/div[2]/div/div[1]/div[1]"));
            websites.Add("www.theguardian.com", Tuple.Create("article", "//div[4]/div/div[1]/div[5]"));
            websites.Add("news.sky.com", Tuple.Create("", "//html/body/div[1]/div[2]"));
            websites.Add("www.washingtonpost.com", Tuple.Create("article-body", "//article"));
            websites.Add("www.cbsnews.com", Tuple.Create("article-entry", "//div[2]"));
            //websites.Add("www.huffingtonpost.com", Tuple.Create("us_jhhcvkh6546", "//div"));
            //websites.Add("tytnetwork.com", Tuple.Create("post-469222", "//div[2]/div"));
            //websites.Add("abcnews.go.com", Tuple.Create("article-feed", "//article[1]/div"));
            //websites.Add("edition.cnn.com", Tuple.Create("body-text", "//div/div[1]"));
            //Fake
            websites.Add("abcnews.com.co", Tuple.Create("", "//html/body/div"));
            //websites.Add("www.breitbart.com", Tuple.Create("post-6594146", "//div"));
            //websites.Add("www.cnn.com.de", Tuple.Create("post-705", "//div[3]"));
        }
    }
}
