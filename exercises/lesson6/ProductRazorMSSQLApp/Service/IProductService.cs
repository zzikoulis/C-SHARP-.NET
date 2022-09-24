using ProductRazorMSSQLApp.DTO;
using ProductRazorMSSQLApp.Model;

namespace ProductRazorMSSQLApp.Service
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        void InsertProduct(ProductDTO? dto);
        void UpdateProduct(ProductDTO? dto);
        Product? DeleteProduct(ProductDTO? dto);
        Product? GetProduct(int id);
    }
}
