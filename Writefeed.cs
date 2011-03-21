using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace RssFeed
{
    class Writefeed
    {
        public List<Message> rssFeed { get; set; }

        public bool AddNewMessage(Message newMessage)
        {
            if (newMessage != null)
            {
                rssFeed.Add(newMessage);
                return true;
            }
            else return false;
        }

        public bool ParseFeedToXML(string fileName)
        { 
            try{
                XDocument rssFeed = new XDocument(
                new XDeclaration("1.0", "utf-8","true"),
                new XElement("rss",
                                new XAttribute("version", "2.0"),
                                new XElement("channel", this.CreateBody())
                               ));
                rssFeed.Save(fileName + ".xml");
                return true;
            
            //Bad habit, but I wasn't sure which exception program should catch.
            }catch(Exception e)
            {
                Console.Write(e);
                return false;
            }
        }

        private IEnumerable<XElement> CreateBody()
        {
            List<XElement> elementFeed = new List<XElement>();
           
            foreach (Message message in rssFeed)
            { 
                XElement item = new XElement("item", 
                                    new XElement("title", message.title), new XElement("link", message.link), new XElement("description", message.description),
                                    new XElement("guid", message.guid), new XElement("pubdate", message.pubDate));
                
                elementFeed.Add(item);
            }
            return elementFeed;
        }

        public bool ParseFeedToText(string fileName)
        {
            try
            {
                TextWriter textWriter = new StreamWriter(fileName);

                foreach (Message message in rssFeed)
                {
                    textWriter.Write(message);
                }

                textWriter.Close();
                return true;
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
