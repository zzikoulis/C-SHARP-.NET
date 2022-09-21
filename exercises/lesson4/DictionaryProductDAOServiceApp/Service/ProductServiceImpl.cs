using ProductDAOServiceApp.DAO;
using ProductDAOServiceApp.DTO;
using ProductDAOServiceApp.Model;

namespace ProductDAOServiceApp.Service
{
    internal class ProductServiceImpl : IProductService
    {
        private readonly IProductDAO? dao;

        public ProductServiceImpl(IProductDAO? dao)
        {
            this.dao = dao;
        }

        public void InsertProduct(ProductDTO? productDTO)
        {
            dao!.InsertProduct(DtoToProduct(productDTO!));
        }

        public Product? DeleteProduct(ProductDTO? productDTO)
        {
            return dao!.DeleteProduct(DtoToProduct(productDTO!));
        }

        public bool UpdatePrice(ProductDTO? productDTO, double price)
        {
            return dao!.UpdatePrice(DtoToProduct(productDTO!), price);
        }

        public Product? GetProductOrNull(ProductDTO? productDTO)
        {
            return dao!.GetProductOrNull(DtoToProduct(productDTO!));
        }

        public IDictionary<long, Product>? GetAllProducts()
        {
            return ProductDAOImpl.Products;
        }

        private Product DtoToProduct(ProductDTO dto)
        {
            return new Product() { Id = dto.Id, Description = dto.Description, Quantity = dto.Quantity, Price = dto.Price };
        }
    }
}
