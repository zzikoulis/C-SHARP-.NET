using ProductRazorMSSQLApp.DTO;

namespace ProductRazorMSSQLApp.Validator
{
    public class ProductValidator
    {
        private ProductValidator() { }

        public static string Validate(ProductDTO? dto)
        {
            if (dto == null)
            {
                return "Product can not be empty!";
            }

            if ((dto.Description!.Length == 0))
            {
                return "Description can not be empty";
            }

            return "";
        }
    }
}
