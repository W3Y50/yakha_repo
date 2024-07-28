namespace ModelBib
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
