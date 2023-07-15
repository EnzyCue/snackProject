using Api.Snack.Models;
using System.Net;
using System;
using Api.Snack.Models.Woolworths;
using System.Text.Json;
using Api.Snack.Helpers;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Api.Snack.Services
{
    public class WoolworthsService
    {
        private readonly string _woolworthsProductEndpoint = "https://www.woolworths.com.au/apis/ui/product/detail/";
        private readonly string _user_agent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36";

        public async Task GetWoolworthsProduct(Product product)
        {
            // go from id -> html url
            string url = $"{_woolworthsProductEndpoint}{product.Id}";
            var cookies = GetCookies(url);
            
            // create http client and make request
            var client = new HttpClient();
            var message = new HttpRequestMessage(new HttpMethod("GET"), url);
            message.Headers.Add("user-agent", _user_agent);
            message.Headers.Add("cookie", );

            var response = await client.SendAsync(message);

            var woolworthsproductinfo = await response.Content.ReadFromJsonAsync<WoolworthsProductInfo>();

            product.Price = woolworthsproductinfo.Product.Price;
            product.Image = woolworthsproductinfo.Product.LargeImageFile;
            product.Name = woolworthsproductinfo.Product.DisplayName;
            product.SaveAmount = woolworthsproductinfo.Product.SavingsAmount;
            product.PricePerHundredGrams = woolworthsproductinfo.Product.CupPrice;
           
        }

        
    }
}