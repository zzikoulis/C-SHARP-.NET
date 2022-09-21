namespace ProductDAOServiceApp.DTO
{
    internal class ProductDTO
    {
        public long Id { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
