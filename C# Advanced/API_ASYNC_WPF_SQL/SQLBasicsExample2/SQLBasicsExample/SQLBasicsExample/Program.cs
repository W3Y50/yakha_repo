using CsvHelper;
using SQLBasicsExample;
using System.Linq;
using ModelBib;


Data dbmanager = new Data();

//Insert new product

Models.Product product = new Models.Product();
product.Title = "Best Cookie";
product.Price = 2.55; 
product.isAvailable = true;

bool insertresult = dbmanager.InsertNewProduct(product);

Console.WriteLine(insertresult);



//Retrieve  title by id
/*
string title = dbmanager.RetrieveTitleById("7892ED6B-CA64-464A-928C-0FFAD8C5DA44");

Console.WriteLine(title);
*/

List<Models.Product> products = dbmanager.RetrieveAllProducts();


//var filterresult =  products.Where(p => p.Title.Contains("B")).ToList();


//Console.WriteLine(filterresult.FirstOrDefault().Title);

if (!(products == null)) 
{ 
    
    var newlist = new List<Models.Product>(products);

    if (newlist.Any(p => p.Price < 2))
    {

    }
}


/*
var singleresult = newlist.Find(p => p.Title.Contains("Beer")

bool filterresult = newlist.Remove());

Console.WriteLine(filterresult);*/