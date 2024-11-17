using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Manager
{
    internal class Products
    {
        public int InsertProduct(string connectionString)
        {
            int categoryId=4;
            string name, descreaption, price, image;
            Console.WriteLine("please enter name:");
                name = Console.ReadLine();
            Console.WriteLine("please enter categoryId:");
            categoryId = int.Parse(Console.ReadLine());
            Console.WriteLine("please enter descreaption:");
            descreaption = Console.ReadLine();
            Console.WriteLine("please enter price:");
            price = Console.ReadLine();
            Console.WriteLine("please enter image:");
            image = Console.ReadLine();

            string query = "INSERT INTO Product  (categoryId,productName,price,image,descreaptionProduct)" +
                "VALUES(@categoryId,@productName,@price,@image,@descreaptionProduct)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@categoryId", SqlDbType.Int).Value = categoryId;
                cmd.Parameters.Add("@productName", SqlDbType.NVarChar, 100).Value= name;
                cmd.Parameters.Add("@price", SqlDbType.NVarChar, 50).Value = price;
                cmd.Parameters.Add("@image", SqlDbType.NVarChar, 100).Value = image;
                cmd.Parameters.Add("@descreaptionProduct", SqlDbType.NVarChar, 100).Value = descreaption;



                cn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                cn.Close();

                Console.WriteLine("Do you want to continue y/n");
                 string answer= Console.ReadLine();
                if (answer == "y")
                {
                    InsertProduct(connectionString);
                }
                return rowAffected;  
               
            }
        }
       public void GetAllProducts(string connectionString)
        {
            string query = "select * from Product";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                try
                {
                    cn.Open();
                    SqlDataReader product = cmd.ExecuteReader();
                    while (product.Read())
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", product[0], product[1], product[2], product[3], product[4], product[5]);
                    }
                    product.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();

            }
        }
    }
}
