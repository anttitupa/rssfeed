using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace RssFeed
{
    class ReadFeed
    {

        public List<Message> rssFeed {get; set;}

        public ReadFeed(string address)
        {
            XElement xmlFeed = Downloadfeed(address);
            rssFeed = XmlToRssFeed(xmlFeed);
        }

        private XElement Downloadfeed(string address)
        {
            try
            {
                return XElement.Load(@address);
            }
            catch (ArgumentException e) 
            {
                Console.WriteLine(e);
                return null;  
            }
        }
        
        private List<Message> XmlToRssFeed(XElement rssDoc)
        {
            return (from message in rssDoc.Elements("channel").Elements("item")
                    select new Message
                           {
                               title = message.Element("title").Value,
                               link = message.Element("link").Value,
                               description = message.Element("description").Value,
                               guid = message.Element("guid").Value,
                               pubDate = message.Element("pubDate").Value
                           }).ToList();
        }

        public override string ToString()
        {
            string rss="";
            foreach (Message message in rssFeed)
            {
                rss += message;
            }

            return rss;
        }
    }
}
