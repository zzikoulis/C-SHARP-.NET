using ProductRazorMSSQLApp.DAO;
using ProductRazorMSSQLApp.DTO;
using ProductRazorMSSQLApp.Model;

namespace ProductRazorMSSQLApp.Service
{
    public class ProductServiceImpl : IProductService
    {
        private readonly IProductDAO dao;

        public ProductServiceImpl(IProductDAO dao)
        {
            this.dao = dao;
        }

        public void InsertProduct(ProductDTO? dto)
        {
            if (dto == null) return;

            Product product = Convert(dto);

            try
            {
                dao.Insert(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateProduct(ProductDTO? dto)
        {
            if (dto == null) return;

            Product product = Convert(dto);

            try
            {
                dao.Update(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Product? DeleteProduct(ProductDTO? dto)
        {
            if (dto == null) return null;

            Product product = Convert(dto);

            try
            {
                return dao.Delete(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Product? GetProduct(int id)
        {
            try
            {
                return dao.GetProductById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<Product> GetAllProducts()
        {
            try
            {
                return dao.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private Product Convert(ProductDTO? dto)
        {
            return new Product()
            {
                Id = dto!.Id,
                Description = dto!.Description!,
                Quantity = dto!.Quantity!
            };
        }
    }
}
