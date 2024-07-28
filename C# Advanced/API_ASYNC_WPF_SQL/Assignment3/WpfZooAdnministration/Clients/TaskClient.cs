using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfZooAdnministration.Clients
{
    class TaskClient
    {
        public string uri { get; set; } //localhost...
        public string token { get; set; }

        public ObservableCollection<Object> taskList;


        public TaskClient(string uri, string token)
        {
            this.uri = uri;
            this.token = token;
            taskList = new ObservableCollection<Object>();
        }

        //GetAllTasks
        public async Task<ObservableCollection<Object>> GetAllTasksRequest()
        {
            throw new NotImplementedException();
        }


        //CreateNewTask
        public async Task<bool> PostTaskRequest(Object task)
        {

            throw new NotImplementedException();

        }

        //UpdateTasks
        public async Task<bool> UpdateAllTasks()
        {

            throw new NotImplementedException();

        }
    }
}
