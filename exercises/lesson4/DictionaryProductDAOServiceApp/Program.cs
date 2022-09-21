using ProductDAOServiceApp.DAO;
using ProductDAOServiceApp.DTO;
using ProductDAOServiceApp.Model;
using ProductDAOServiceApp.Service;

namespace ProductDAOServiceApp
{
    internal class Program
    {
        static readonly IProductDAO dao = new ProductDAOImpl();
        static readonly IProductService service = new ProductServiceImpl(dao);

        static void Main(string[] args)
        {
            ProductDTO p1 = new() { Id = 1, Description = "Product1", Quantity = 1, Price = 1.1 };
            ProductDTO p2 = new() { Id = 2, Description = "Product2", Quantity = 2, Price = 2.2 };
            ProductDTO p3 = new() { Id = 3, Description = "Product3", Quantity = 3, Price = 3.3 };
            ProductDTO p4 = new() { Id = 4, Description = "Product4", Quantity = 4, Price = 4.4 };
            ProductDTO p5 = new() { Id = 5, Description = "Product5", Quantity = 5, Price = 5.5 };

            service.InsertProduct(p2);
            service.InsertProduct(p1);
            service.InsertProduct(p3);
            service.InsertProduct(p4);
            service.InsertProduct(p5);

            foreach (KeyValuePair<long, Product> p in service.GetAllProducts()!)
            {
                Console.WriteLine(p.Value);
            }
            Console.WriteLine();

            service.UpdatePrice(p2, 22.22);
            service.DeleteProduct(p4);
            Console.WriteLine("After Deleting Product4 and Updating Product2's price:");
            foreach (KeyValuePair<long, Product> p in service.GetAllProducts()!)
            {
                Console.WriteLine(p.Value);
            }
            Console.WriteLine();


            if (service.GetProductOrNull(p4) == null)
            {
                Console.WriteLine("Product with id: {0} not found", p4.Id);
            }

            if (service.GetProductOrNull(p5) != null)
            {
                Console.WriteLine("Product with id: {0} found", p5.Id);
            }
        }
    }
}