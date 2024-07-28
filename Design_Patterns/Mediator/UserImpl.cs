using System;
namespace Mediator
{
    public class UserImpl : User
    {
        public UserImpl(string name, IChatMediator mediator) : base(name, mediator) { }

        public override void ReceiveMessage(string message)
        {
            Console.WriteLine(Name + " has received a message"); 
            Console.WriteLine($"{Name} received the following message: {message}");
        }

        public override void SendMessage(string message, User user1, User user2, bool all)
        {
           Console.WriteLine(Name + $": {message} // User {user1.Name} has send a message to {user2.Name}");
           Mediator.SendMessage(message, user1, user2, all);
        }

    }
}

