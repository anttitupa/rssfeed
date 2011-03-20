
namespace RssFeed
{
    public class Message
    {

        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set ;}
        public string guid  { get; set; }
        public string pubDate { get;  set;}

        public override string ToString()
        {
            return string.Format("title:{0}\n link:{1}\n description:{2}\n guid:{3} pubDate: {4}\n",
                                    title, link , description, guid, pubDate);
        }
    }

}
