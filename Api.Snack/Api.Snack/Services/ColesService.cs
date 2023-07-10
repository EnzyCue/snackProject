using Api.Snack.Helpers;
using Api.Snack.Models;
using HtmlAgilityPack;
using System.Text;

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
            var web = new HtmlWeb();
            var htmlDoc = web.Load(url);

            //Scrape data
            var image = htmlDoc.DocumentNode.SelectSingleNode("//img[contains(@data-testid, 'product-image-0')]").NextSibling.OuterHtml;
            var startIndex = image.IndexOf("https://productimages.coles.com.au");
            var endIndex = image.IndexOf(" ", startIndex);
            image = image.Substring(startIndex, endIndex - startIndex);

            var price = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='price__value']")?.InnerHtml;
            var name = htmlDoc.DocumentNode.SelectSingleNode("//h1[@class='LinesEllipsis  product__title']")?.InnerHtml;
            
            var saveAmount = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='badge-label']")?.InnerHtml;
            var pricePerHundredGrams = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='price__calculation_method']")?.InnerHtml;

            //Map data
            product.Price = price == null ? 0 : Convert.ToDecimal(Helper.TakeDigits(price));
            product.Image = image;
        }
    }
}