namespace Mediator;

class Program
{
    static void Main(string[] args)
    {
        ChatMediatorImpl chatroom = new ChatMediatorImpl();

        UserImpl user1 = new UserImpl("Timo", chatroom);
        UserImpl user2 = new UserImpl("Cherian", chatroom);
        UserImpl user3 = new UserImpl("Alina", chatroom);
        UserImpl user4 = new UserImpl("Anna", chatroom);
        UserImpl user5 = new UserImpl("Bernd", chatroom);

        chatroom.AddUser(user1);
        chatroom.AddUser(user2);
        chatroom.AddUser(user3);
        chatroom.AddUser(user4);
        chatroom.AddUser(user5);

        user3.SendMessage("Hello, everyone!", user3, user4, true);  

        Console.WriteLine("-------------");
        user1.SendMessage($"Hi  {user2.Name}, what is going on?", user1, user2, false);
        Console.ReadKey();
    }
}

//IChatMediator
//User
//Impl
//UserImpl