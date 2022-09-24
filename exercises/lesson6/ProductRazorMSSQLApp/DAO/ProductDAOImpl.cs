using ProductRazorMSSQLApp.DAO.DBUtil;
using ProductRazorMSSQLApp.Model;
using System.Data.SqlClient;

namespace ProductRazorMSSQLApp.DAO
{
    public class ProductDAOImpl : IProductDAO
    {
        public void Insert(Product? product)
        {
            if (product == null)
            {
                return;
            }

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                conn!.Open();
                string sql = "INSERT INTO PRODUCTS " +
                             "(DESCRIPTION, QUANTITY) VALUES " +
                             "(@description, @quantity)";
                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@description", product!.Description);
                command.Parameters.AddWithValue("@quantity", product.Quantity);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Update(Product? product)
        {
            if (product == null)
            {
                return;
            }

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                conn!.Open();
                string sql = "UPDATE PRODUCTS SET DESCRIPTION=@description, QUANTITY=@quantity WHERE ID=@id";
                ;
                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@id", product!.Id);
                command.Parameters.AddWithValue("@description", product!.Description);
                command.Parameters.AddWithValue("@quantity", product.Quantity);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public Product? Delete(Product? product)
        {
            if (product == null)
            {
                return null;
            }

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                conn!.Open();
                string sql = "DELETE FROM PRODUCTS " +
                             "WHERE ID=@id";
                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@id", product!.Id);

                int rowsAffected = command.ExecuteNonQuery();

                return (rowsAffected == 1) ? product : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public Product? GetProductById(int id)
        {
            try
            {
                Product? product = null;
                using SqlConnection? conn = DBHelper.GetConnection();

                conn!.Open();
                string sql = "SELECT * FROM PRODUCTS WHERE ID=@id";

                using SqlCommand command = new(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    product = new Product()
                    {
                        Id = reader.GetInt32(0),
                        Description = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                }

                return product;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }


        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                conn!.Open();
                string sql = "SELECT * FROM PRODUCTS";

                using SqlCommand command = new(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        Id = reader.GetInt32(0),
                        Description = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };

                    products.Add(product);
                }

                return products;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }       
    }
}
