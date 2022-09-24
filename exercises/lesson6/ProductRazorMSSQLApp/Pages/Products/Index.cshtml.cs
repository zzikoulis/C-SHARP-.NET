using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductRazorMSSQLApp.DAO;
using ProductRazorMSSQLApp.Model;
using ProductRazorMSSQLApp.Service;

namespace ProductRazorMSSQLApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductDAO dao = new ProductDAOImpl();
        private readonly IProductService service;

        public List<Product> Products = new();

        public IndexModel()
        {
            service = new ProductServiceImpl(dao);
        }

        public void OnGet()
        {
            try
            {
                Products = service.GetAllProducts();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}
