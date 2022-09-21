using ProductDAOServiceApp.Model;

namespace ProductDAOServiceApp.DAO
{
    internal interface IProductDAO
    {
        void InsertProduct(Product product);
        bool UpdatePrice(Product product, double price);
        Product? DeleteProduct(Product product);
        Product? GetProductOrNull(Product product);
    }
}
