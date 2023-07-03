namespace Api.Snack.Models
{
    public class Product
    {
        public string Id { get; init; }

        public decimal Price { get; init; }

        public string Name { get; init; }
        
        public string Image { get; init; }

        public decimal SaveAmount { get; init; }

        public decimal PricePerHundredGrams { get; init; }
    }
}
