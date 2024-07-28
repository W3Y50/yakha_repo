using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLBasicsExample
{
    public class Data
    {
        // string connstring = "Data Source=DESKTOP-4CO4R70;Initial Catalog=SQLBasicsExampleDB;Integrated Security=True;Persist Security Info=False;";

        string connstring = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True";
        
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

        public bool UpdateProductTitle(string productid, string title)
        {
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE_ProductTitle", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("ProductId", productid);
                cmd.Parameters.AddWithValue("Title", title);


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
                    singleresult.Description = rd.IsDBNull(4) ? null :  rd.GetString(4);


                    results.Add(singleresult);
                }
                conn.Close();
                return results;
            } 
            catch (Exception e)
            {
                conn.Close();
  
                return null;
            } 
        }

        public List<Models.Product> SearchProduct(string keyword)
        {
            SqlConnection conn = new SqlConnection(connstring);
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("RETRIEVE_ProductsByName", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Keyword", keyword);


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
                    singleresult.Description = rd.IsDBNull(4) ? null : rd.GetString(4);


                    results.Add(singleresult);
                }
                conn.Close();
                return results;
            }
            catch (Exception e)
            {
                conn.Close();

                return null;
            }
        }
    }
}
