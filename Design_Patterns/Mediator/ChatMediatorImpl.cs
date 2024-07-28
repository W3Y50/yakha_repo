using System;
namespace Mediator
{
    class ChatMediatorImpl : IChatMediator
    {
        private List<User> userList; // a list of users so the Mediator can communicate (and reference the users) with them for example when a new user joins the chat or leaves

        public ChatMediatorImpl()
        {
            userList = new List<User>();
        }

        public void AddUser(User user)
        {
            userList.Add(user); //we add a user to the list
        }

        public void SendMessage(string message, User user1, User user2, bool all) //this is the user who sends a message.
        {

            //--> boolean flag - send to all or to a specific user
            if (all == true) 
            {
                foreach (User u in userList)
                {
                    // Ensure the user does not receive their own message
                    if (u != user1)
                    {
                        u.ReceiveMessage(message);
                    }
                }

            } 
            else
            {
               user2.ReceiveMessage(message);
            }
        }
    }
}

