using Api.Domain.Snack.Models;
using System.Net.Http.Json;
using Api.Domain.Snack.Models.Woolworths;
using Api.Application.Snack.Helpers;
using Api.Application.Snack.Interfaces;

namespace Api.Application.Snack.Services
{
    public class WoolworthsService : IStoreService
    {
        private readonly string _woolworthsProductEndpoint = "https://www.woolworths.com.au/apis/ui/product/detail/";
        private readonly string _user_agent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36";
        public ProductOptions ProductOptions { get; set; }

        public WoolworthsService()
        {
            ProductOptions = new ProductOptions();
            ProductOptions.Cookies = Helper.GetWoolworthsCookies();
        }

        public async Task GetStoreProduct(Product product)
        {
            // go from id -> html url
            string url = $"{_woolworthsProductEndpoint}{product.Id}";

            // create http client and make request
            var client = new HttpClient();
            var message = new HttpRequestMessage(new HttpMethod("GET"), url);
            message.Headers.Add("user-agent", _user_agent);
            message.Headers.Add("cookie", ProductOptions.Cookies);

            var response = await client.SendAsync(message);

            var woolworthsproductinfo = await response.Content.ReadFromJsonAsync<WoolworthsProductInfo>();

            product.Price = woolworthsproductinfo!.Product.Price;
            product.Image = woolworthsproductinfo.Product.LargeImageFile;
            product.Name = woolworthsproductinfo.Product.DisplayName;
            product.SaveAmount = woolworthsproductinfo.Product.SavingsAmount;
            product.PricePerHundredGrams = woolworthsproductinfo.Product.CupPrice;
        }
    }
}