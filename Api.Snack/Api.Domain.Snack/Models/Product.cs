namespace Api.Domain.Snack.Models
{
    public class Product
    {
        public string Id { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public decimal SaveAmount { get; set; }

        public decimal PricePerHundredGrams { get; set; }
    }
}
