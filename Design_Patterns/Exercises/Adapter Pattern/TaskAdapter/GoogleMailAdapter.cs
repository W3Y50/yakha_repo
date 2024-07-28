using System;
namespace TaskAdapter
{
    public class GoogleMailAdapter : IEmailSender
    {
        private readonly GoogleMailServer _googleMailServer;

        public GoogleMailAdapter()
        {
            _googleMailServer = new GoogleMailServer();
        }

        public void ConnectAndSendEmail(string recipient, string subject, string body)
        {
            // Establish a connection to the Google Mail server.
            _googleMailServer.Connect();

            // Simulate email encryption.
            Console.WriteLine("Email successfully encrypted...");

            // Use GoogleMailServer to send the email.
            _googleMailServer.SendEmail(recipient, subject, body);
        }
    }
}

