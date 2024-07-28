using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml.Schema;
//using Assignment3.Models;

namespace WpfZooAdnministration.Clients
{
    class AnimalClient
    {
        public string uri { get; set; } //localhost...
        public string token { get; set; }

        public ObservableCollection<Object> animalList;


        public AnimalClient(string uri, string token)
        {
            this.uri = uri;
            this.token = token;
            animalList = new ObservableCollection<Object>();
        }

        //GetAllAnimals
        public async Task<ObservableCollection<Object>> GetAllAnimalsRequest()
        {
            throw new NotImplementedException();
        }


        //CreateNewAnimal
        public async Task<bool> PostAnimalRequest(Object animal)
        {

            throw new NotImplementedException(); 
        
        }

        //UpdateAnimals
        public async Task<bool> UpdateAllAnimalsRequest()
        {

            throw new NotImplementedException();
                
        }

        public async Task<ObservableCollection<Object>> GetAnimalByLocation(Object location)
        {

            throw new NotImplementedException(); 
        
        }


    }
}
