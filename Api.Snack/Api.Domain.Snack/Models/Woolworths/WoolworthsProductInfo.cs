using System.Text.Json;

namespace Api.Domain.Snack.Models.Woolworths;

public class WoolworthsProductInfo
{
    public WoolworthsProduct Product { get; set; }
}

public class WoolworthsProduct
{
    public long Stockcode { get; set; }

    public string DisplayName { get; set; }

    public decimal Price { get; set; }

    public string LargeImageFile { get; set; }

    public decimal SavingsAmount { get; set; }

    public decimal CupPrice { get; set; }
}