using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLBasicsExample
{
    public class Models
    {

        public class Product
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public double Price { get; set; }
            public DateTime DateAdded { get; set; }
            public string Description { get; set; }

        }
    }
}
