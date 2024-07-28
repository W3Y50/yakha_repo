using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfZooAdnministration.Clients
{
    class LocationClient
    {
        public string uri { get; set; } //localhost...
        public string token { get; set; }

        public ObservableCollection<Object> locationList;


        public LocationClient(string uri, string token)
        {
            this.uri = uri;
            this.token = token;
            locationList = new ObservableCollection<Object>();
        }

        //GetAllLocations
        public async Task<ObservableCollection<Object>> GetAllLocationsRequest()
        {
            throw new NotImplementedException();
        }


        //CreateNewLocation
        public async Task<bool> PostLocationRequest(Object location)
        {

            throw new NotImplementedException();

        }

        //UpdateLocation
        public async Task<bool> UpdateAllLocationsRequest()
        {

            throw new NotImplementedException();

        }

        
    }
}
