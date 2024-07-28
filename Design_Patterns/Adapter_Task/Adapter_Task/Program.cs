// Client code
using Adapter_Task;

public class Client
{
    public static void Main()
    {
        IMailServer mailServer = new GoogleMailServerAdapter();
        mailServer.ConnectAndSendMail("testmail@example.com", "Hello, what is going on?", "This is a test email.");
    }
}
