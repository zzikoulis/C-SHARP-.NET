using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductRazorMSSQLApp.DAO;
using ProductRazorMSSQLApp.DTO;
using ProductRazorMSSQLApp.Model;
using ProductRazorMSSQLApp.Service;

namespace ProductRazorMSSQLApp.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IProductDAO? productDAO = new ProductDAOImpl();
        private readonly IProductService? service;

        public DeleteModel()
        {
            service = new ProductServiceImpl(productDAO);
        }

      
        internal ProductDTO ProductDTO = new ProductDTO();
        public string ErrorMessage = "";

        public void OnGet()
        {
            try
            {
                Product? product;

                int id = int.Parse(Request.Query["id"]);
                ProductDTO.Id = id;
                product = service!.DeleteProduct(ProductDTO);
                Response.Redirect("/Products/Index");
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }
    }
}
