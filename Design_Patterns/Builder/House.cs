using System;
namespace Builder
{
    public class House
    {
        public string Material { get; set; } 
        public string Basement { get; set; } 
        public string Kitchen { get; set; } 
        public string Roof { get; set; } 

        public override string ToString()
        {
            string text = "Material:" + Material + "\n" +
                          "Basement:" + Basement + "\n" +
                          "Kitchen:" + Kitchen + "\n" +
                          "Roof:" + Roof;
                          
            return text;
        }
    }
}
