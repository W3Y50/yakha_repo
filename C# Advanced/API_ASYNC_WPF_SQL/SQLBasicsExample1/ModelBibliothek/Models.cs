using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ModelBibliothek
{
    public class Models
    {

        public class Product
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public double Price { get; set; }
            public DateTime DateAdded { get; set; }
            public bool isAvailable { get; set; }

        }
    }
}
