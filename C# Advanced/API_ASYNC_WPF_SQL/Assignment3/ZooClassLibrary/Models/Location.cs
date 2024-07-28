using ZooClassLibrary.Enums;
namespace ZooClassLibrary.Models
{
    //Put classes and enums in relation to Locations
    //here
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Capacity { get; set; }
        public string LocationName { get; set; }
        public LocationEnum Type { get; set; }
        public bool IsActive { get; set; }

    }

    
}
