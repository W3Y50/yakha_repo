using System;
namespace Mediator
{
    public interface IChatMediator
    {
        void SendMessage(string message, User user1, User user2, bool all);
        //void SendMessageToOtherUser(string message, User user1, User user2); 
        void AddUser(User user);
    }
}

