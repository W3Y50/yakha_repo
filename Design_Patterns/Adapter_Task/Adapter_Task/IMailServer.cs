using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_Task
{
    // New interface
    public interface IMailServer
    {
        void ConnectAndSendMail(string emailAdress, string content, string receiverName);
    }
}
