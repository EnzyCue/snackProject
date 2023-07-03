using Api.Snack.Models;
using HtmlAgilityPack;

namespace Api.Snack.Services
{
    public class ColesService
    {

        private readonly string _colesProductEndpoint = "https://www.coles.com.au/product/";
        
        public async Task GetColesProduct(Product product)
        {
            // go from id -> html url
            string url = $"{_colesProductEndpoint}{product.Id}";

            // use html agility pack to extract the information about the product
            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(url);

            //Scrape price
            var price = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='price__value']").InnerHtml;

            product.Price = price == null ? 0 : Convert.ToDecimal(price);
        }
    }
}
