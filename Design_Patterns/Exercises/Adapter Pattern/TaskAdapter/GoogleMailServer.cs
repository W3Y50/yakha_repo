using System;
namespace TaskAdapter
{
	public class GoogleMailServer
	{
        public void Connect()
        {
            Console.WriteLine("Connected to Google Mail Server...");
        }

        public void SendEmail(string recipient, string subject, string body)
        {
            Console.WriteLine($"Sending email to {recipient} with subject: {subject}");
        }
    }
}

