namespace ZooClassLibrary.Models
{

    //Put classes and enums in relation to Animals here

    public class Animal
    {
        public Guid Id { get; set; }
        public Guid Species_id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Health { get; set; }
    }
}
