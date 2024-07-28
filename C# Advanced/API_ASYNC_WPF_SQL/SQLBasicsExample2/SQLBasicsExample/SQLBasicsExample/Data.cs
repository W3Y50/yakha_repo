using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using ModelBib;

namespace SQLBasicsExample
{
    public class Data
    {
        // string connstring = "Data Source=DESKTOP-4CO4R70;Initial Catalog=SQLBasicsExampleDB;Integrated Security=True;Persist Security Info=False;";

        string connstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=newsqldatabase;Integrated Security=True";
        
        public string RetrieveTitleById(string id)
        {
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("RETRIEVE_TitleForProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", id);


                string title = (cmd.ExecuteScalar()).ToString();
                conn.Close();
                return title;
            }
            catch (Exception e)
            {
                conn.Close();
             
                return null;
            }
        }

        public bool InsertNewProduct(Models.Product product)
        {
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                conn.Open();
           
                SqlCommand cmd = new SqlCommand("INSERT_Product", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Title", product.Title);
                cmd.Parameters.AddWithValue("Price", product.Price);
                cmd.Parameters.AddWithValue("isAvailable", product.isAvailable);


                int result = cmd.ExecuteNonQuery();
                conn.Close();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                conn.Close();

                return false;
            }
        }


        public List<Models.Product> RetrieveAllProducts()
        {
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("RETRIEVE_AllProducts", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                SqlDataReader rd = cmd.ExecuteReader();

                

                if (!rd.HasRows)
                {
                    return null;
                }

                List<Models.Product> results = new List<Models.Product>();

                while (rd.Read())
                {
                    Models.Product singleresult = new Models.Product();

                    singleresult.Id = rd.GetValue(0).ToString();
                    singleresult.Title = rd.GetString(1);
                    singleresult.Price = rd.GetDouble(2);
                    singleresult.DateAdded = rd.GetDateTime(3);
                    singleresult.isAvailable = rd.GetBoolean(4);

                    results.Add(singleresult);
                }
                conn.Close();

                //print out in csv on this place
                if (CreateCSV(results, "SQL Command RETRIEVE_AllProducts").IsCompleted == true) 
                {
                    return results;
                }
                return null;
            }
            catch (Exception e)
            {
                conn.Close();

                return null;
            }
        }

        public static async Task<List<Models.Product>> CreateCSV(List<Models.Product> csvList, string sourceStr)
        {

            string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CSVTraining";
            bool exists = System.IO.Directory.Exists(folderpath);

            if (!exists)
            {
                System.IO.Directory.CreateDirectory(folderpath);
            }

            //var testlist = new List<CSVDataModel>();

           // for (int i = 0; i < 12; i++)
           // {
           //     testlist.Add(new CSVDataModel() { val1 = i, val2 = "test" + i.ToString() });
           // }

            var writer = new StreamWriter($"{folderpath}\\file.csv");
            var csvwriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csvwriter.WriteRecords(csvList);
            csvwriter.WriteComment($"Export Time: {DateTime.Now} Source: {sourceStr}");
            //csvwriter.WriteRecords($"Export Time: {DateTime.Now} Source: {sourceStr}");

            csvwriter.Dispose();
            writer.Dispose();

            var reader = new StreamReader($"{folderpath}\\file.csv");
            var csvreader = new CsvReader(reader, CultureInfo.InvariantCulture);

            var output = csvreader.GetRecords<Models.Product>().ToList();
            return output;
        }

        //class CSVDataModel
       // {
       //     public int val1 { get; set; }
       //     public string val2 { get; set; }
       // }
    }
}
