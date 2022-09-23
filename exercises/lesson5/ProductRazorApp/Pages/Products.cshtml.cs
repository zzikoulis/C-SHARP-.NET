using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProductRazorApp.Pages
{
    public class ProductsModel : PageModel
    {
        public IEnumerable<string>? Products { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Products Razor Page";
            Products = new[]
            {
                "Product1",
                "Product2",
                "Product3",
            };
        }
    }
}
