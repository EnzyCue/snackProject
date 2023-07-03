using Api.Snack.Helpers;
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

            //Scrape data
            var price = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='price__value']")?.InnerHtml;
            var name = htmlDoc.DocumentNode.SelectSingleNode("//h1[@class='LinesEllipsis  product__title']")?.InnerHtml;
            var image = htmlDoc.DocumentNode
                .SelectSingleNode("//div[@class='coles-targeting-ProductImagesWrapper']")?
                .FirstChild?
                .ChildNodes?
                .FirstOrDefault(x => x.Name == "img")?
                .Attributes?
                .FirstOrDefault(x => x.Name == "src");

            var saveAmount = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='badge-label']")?.InnerHtml;
            var pricePerHundredGrams = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='price__calculation_method']")?.InnerHtml;

            //Map data
            product.Price = price == null ? 0 : Convert.ToDecimal(Helper.TakeDigits(price));
        }
    }
}