using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_Task
{
    // Existing GoogleMailServer class
    public class GoogleMailServer
    {
        //Preparing GoogleMailServer Object
        public GoogleMailServer() 
        {
            BuildtConnection();
        }

        //Buildt a connection to an account...
        public void BuildtConnection()
        {
            Console.WriteLine("Connection to the mail account established!");
        }


        public void ConnectAndSendMail(string emailAdress, string content, string receiverName)
        {
            // Implementation to send email using Google Mail Server
            Console.WriteLine($"Sending email to: {emailAdress}  | with content: {content} | and the receiver is: {receiverName} | ");
        }
    }
}
