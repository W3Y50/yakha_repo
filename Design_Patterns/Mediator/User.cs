using System;
using System.Runtime.Intrinsics.X86;
namespace Mediator
{
    public abstract class User
    {
        public IChatMediator Mediator { get; set; } //so the User know where to sent the message to. 
        public string Name { get; set; }

        public User(string name, IChatMediator mediator)
        {
            Mediator = mediator;
            Name = name;
        }

        public abstract void SendMessage(string message, User user1, User user2, bool all);
        public abstract void ReceiveMessage(string message);
        //public abstract void SendMessageToOtherUser(string message, User user1, User user2);
    }
}