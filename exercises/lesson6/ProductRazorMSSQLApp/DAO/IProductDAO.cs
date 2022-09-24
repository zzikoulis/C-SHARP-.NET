using ProductRazorMSSQLApp.Model;

namespace ProductRazorMSSQLApp.DAO
{
    public interface IProductDAO
    {
        void Insert(Product? product);
        void Update(Product? product);
        Product? Delete(Product? product);
        Product? GetProductById(int id);
        List<Product> GetAll();
    }
}
