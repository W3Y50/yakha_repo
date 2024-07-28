using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfZooAdnministration.Clients
{
    class UserClient
    {
        public string uri { get; set; } //localhost...
        public string token { get; set; }

        public ObservableCollection<Object> userList;


        public UserClient(string uri)
        {
            this.uri = uri;
            this.token = "";
            userList = new ObservableCollection<Object>();
        }

        //Get the token
        public async Task<string> Login(Object user)
        {
            throw new NotImplementedException();
        }

        //GetAllUsers
        public async Task<ObservableCollection<Object>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        //CreateNewUser
        public async Task<bool> PostUserRequest(Object user)
        {

            throw new NotImplementedException();

        }

        //UpdateUser
        public async Task<bool> UpdateUserRequest()
        {

            throw new NotImplementedException();

        }
    }
}
