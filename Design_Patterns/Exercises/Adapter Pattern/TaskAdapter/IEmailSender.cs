using System;
namespace TaskAdapter
{
	public interface IEmailSender
    {
        void ConnectAndSendEmail(string recipient, string subject, string body);
    }
}

