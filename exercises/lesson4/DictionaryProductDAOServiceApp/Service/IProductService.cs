using ProductDAOServiceApp.DTO;
using ProductDAOServiceApp.Model;
using System.Drawing;

namespace ProductDAOServiceApp.Service
{
    internal interface IProductService
    {
        void InsertProduct(ProductDTO? productDTO);
        Product? DeleteProduct(ProductDTO? productDTO);
        bool UpdatePrice(ProductDTO? productDTO, double price);
        Product? GetProductOrNull(ProductDTO? productDTO);
        IDictionary<long, Product>? GetAllProducts();
    }
}
