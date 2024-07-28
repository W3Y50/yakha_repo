using ZooClassLibrary.Enums;
namespace ZooClassLibrary.Models
{
    //Put classes and enums in relation to Users here
    public class User
    {
        public Guid Id { get; set; }
        public Guid StaffId { get; set; }
        public char Password { get; set; }
        public RoleEnum Role { get; set; }

    }

   
}
