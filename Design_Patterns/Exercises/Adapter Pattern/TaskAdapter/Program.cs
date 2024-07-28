namespace TaskAdapter;

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of the adapter.
        IEmailSender emailSender = new GoogleMailAdapter();

        // Use the adapter to send an email through the GoogleMailServer.
        emailSender.ConnectAndSendEmail("example@domain.com", "Subject", "Email body content");

        Console.ReadKey();
    }
}

