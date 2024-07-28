using System;
using ZooClassLibrary.Enums;

namespace ZooClassLibrary.Models
{
    //Put classes and enums in relation to Tasks here
    public class Tasks
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public LocationEnum Location { get; set; }
        public Animal Animal { get; set; }
        public IntervallEnum Interval { get; set; }
        public StatusEnum Status { get; set; }
        public bool IsActive { get; set; }
    }
}

