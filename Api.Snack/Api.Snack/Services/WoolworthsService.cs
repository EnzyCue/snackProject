using Api.Snack.Models;

namespace Api.Snack.Services
{
    public class WoolworthsService
    {
        private readonly string _woolworthsProductEndpoint = "https://www.woolworths.com.au/api/v3/ui/schemaorg/product/";

        public async Task GetWoolworthsProduct(Product product)
        {
            // go from id -> html url
            string url = $"{_woolworthsProductEndpoint}{product.Id}";

            // create http client and make request
            var client = new HttpClient();
            var response = await client.GetAsync(url);

        }

    }
}
