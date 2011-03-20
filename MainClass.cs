using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;


namespace RssFeed
{
    class MainClass
    {
       public static void Main(string[] args)
       {
           ReadFeed readRssFeed = new ReadFeed("http://www.iltasanomat.fi/rss/uutiset.xml");
           Console.WriteLine(readRssFeed);
           Writefeed writeRssFeed = new Writefeed();
           writeRssFeed.rssFeed = readRssFeed.rssFeed;
           writeRssFeed.ParseFeedToText("test.txt");
           writeRssFeed.ParseFeedToXML("test");
           Console.WriteLine("Done");
       }
    }
}
