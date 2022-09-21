using ProductDAOServiceApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDAOServiceApp.DAO
{
    internal class ProductDAOImpl : IProductDAO
    {
        private static IDictionary<long, Product> products = new Dictionary<long, Product>();
        public static IDictionary<long, Product> Products { get => new Dictionary<long, Product>(products);}

        public void InsertProduct(Product product)
        {
           products.Add(product.Id, product);
        }

        public Product? DeleteProduct(Product product)
        {
            if(!products.Remove(product.Id))
            {
                return null;
            }

            return product;
        }

        public bool UpdatePrice(Product product, double price)
        {
            if (products.ContainsKey(product.Id))
            {
                products[product.Id].Price = price;
                return true;
            }

            return false;
        }

        public Product? GetProductOrNull(Product? product)
        {
            return (products.ContainsKey(product!.Id)) ? products[product.Id] : null;
        }
    }
}
