using System;
namespace Observer
{
	public class Newsletter
    {
        public string Topic { get; set; }
        public string Content { get; set; }

        public Newsletter(string topic, string content)
         {
            Topic = topic;
            Content = content;
         }
    }
}

