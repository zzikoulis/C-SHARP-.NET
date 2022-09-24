using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductRazorMSSQLApp.DAO;
using ProductRazorMSSQLApp.DTO;
using ProductRazorMSSQLApp.Model;
using ProductRazorMSSQLApp.Service;
using ProductRazorMSSQLApp.Validator;

namespace ProductRazorMSSQLApp.Pages.Products
{
    public class UpdateModel : PageModel
    {
        private readonly IProductDAO productDAO = new ProductDAOImpl();
        private readonly IProductService? service;

        public UpdateModel()
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
                product = service!.GetProduct(id);
                ProductDTO = ConvertToDto(product!);            
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }

        public void OnPost()
        {
            ErrorMessage = "";

            try
            {
                // Get DTO
                ProductDTO.Id = int.Parse(Request.Form["id"]);
                ProductDTO.Description = Request.Form["description"];
                ProductDTO.Quantity = int.Parse(Request.Form["quantity"]);
            }
            catch (FormatException)
            {
                ErrorMessage = "Quantity must be an integer (empty quantity or charactes are not allowed)";
                return;
            }

            // Validate DTO
            ErrorMessage = ProductValidator.Validate(ProductDTO);

            // If Error return
            if (!ErrorMessage.Equals("")) return;

            // Update product  
            try
            {
                service!.UpdateProduct(ProductDTO);
                Response.Redirect("/Products/Index");
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }

        private ProductDTO ConvertToDto(Product product) 
        {
            ProductDTO dto = new ProductDTO(); 
            dto.Id = product.Id;
            dto.Description = product.Description;
            dto.Quantity = product.Quantity;

            return dto;
        }
    }
}
