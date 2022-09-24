using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductRazorMSSQLApp.DAO;
using ProductRazorMSSQLApp.DTO;
using ProductRazorMSSQLApp.Service;
using ProductRazorMSSQLApp.Validator;

namespace ProductRazorMSSQLApp.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductDAO productDAO = new ProductDAOImpl();
        private readonly IProductService service;

        public CreateModel()
        {
            service = new ProductServiceImpl(productDAO);
        }

        internal ProductDTO ProductDTO = new ProductDTO();
        public string ErrorMessage = "";
        public string SuccessMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            ErrorMessage = "";
            SuccessMessage = "";
            try
            {
                // Get DTO
                ProductDTO.Description = Request.Form["description"];
                ProductDTO.Quantity = int.Parse(Request.Form["quantity"]);
            } catch (FormatException)
            {
                ErrorMessage = "Quantity must be an integer (empty quantity or charactes are not allowed)";
                return;
            }

            // Validate DTO
            ErrorMessage = ProductValidator.Validate(ProductDTO);
            
            // If Error return
            if (!ErrorMessage.Equals("")) return;

            // Insert product  
            try
            {
                service.InsertProduct(ProductDTO);
                /*
                 * All the following comments hold if we stay
                 * in page
                 * SuccessMessage = "New Product inserted successfuly";
                 * //If success reset fields for the new insert
                 *  ResetFields();
                 */

                // On Success
                Response.Redirect("/Products/Index");
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }

        private void ResetFields()
        {
            ProductDTO.Description = "";
            ProductDTO.Quantity = 0;
        }
    }
}

