using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfZooAdnministration.Clients
{
    class StaffClient
    {

        public string uri { get; set; } //localhost...
        public string token { get; set; }

        public ObservableCollection<Object> staffList;


        public StaffClient(string uri, string token)
        {
            this.uri = uri;
            this.token = token;
            staffList = new ObservableCollection<Object>();
        }

        //GetAllStaffMembers
        public async Task<ObservableCollection<Object>> GetStaffMembersRequest()
        {
            throw new NotImplementedException();
        }


        //CreateNewStaffMember
        public async Task<bool> PostStaffMemberRequest(Object staffMember)
        {

            throw new NotImplementedException();

        }

        //UpdateStaffMember
        public async Task<bool> UpdateAllStaffMembersRequest()
        {

            throw new NotImplementedException();

        }

       
    }
}
