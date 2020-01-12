using System;
namespace devWebFeed.Model
{
    public class Post
    {
        public string title { get; set; }
        public string url { get; set; }
        public string domain { get; set; }
        public DateTime submitted { get; set; }
        public Submitter submitter { get; set; }
        public string author { get; set; }
        public string color { get; set; }
    }
}
