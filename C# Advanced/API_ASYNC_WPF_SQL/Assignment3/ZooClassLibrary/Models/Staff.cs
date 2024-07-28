namespace ZooClassLibrary.Models
{
    //Put classes and enums in relation to Staffmember etc. here
    public class Staff
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public DateTime JoinDate { get; set; }

    }
}
