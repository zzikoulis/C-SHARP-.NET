namespace ProductDAOServiceApp.Model
{
    internal class Product : IComparable<Product>, IEquatable<Product>
    {
        public long Id { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public int CompareTo(Product? other)
        {
            return this.Id.CompareTo(other!.Id);
        }

        public bool Equals(Product? other)
        {
            if (other == null)
            {
                return false;
            }

            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || (GetType() != obj.GetType()))
            {
                return false;
            }

            return CompareTo((Product)obj) == 0;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string? ToString()
        {
            return $"Product with: id = {Id}, description = {Description}, quantity = {Quantity}, price = {Price}";
        }
    }
}
