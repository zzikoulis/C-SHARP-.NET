namespace ProductRazorMSSQLApp.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }

        public override string? ToString() => "{" + Id + ", " + Description + ", " + Quantity + "}";
    }
}
