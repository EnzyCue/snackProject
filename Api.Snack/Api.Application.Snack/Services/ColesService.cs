using Api.Application.Snack.Helpers;
using Api.Domain.Snack.Models;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace Api.Application.Snack.Services
{
    public class ColesService
    {
        private readonly string _colesProductEndpoint = "https://www.coles.com.au/product/";

        public async Task GetColesProduct(Product product, ProductOptions options)
        {
            // go from id -> html url
            string url = $"{_colesProductEndpoint}{product.Id}";

            // use html agility pack to extract the information about the product
            var web = new HtmlWeb();
            var htmlDoc = web.Load(url);

            // ---- Scrape data ----

            //Scrape Image
            var image = htmlDoc.DocumentNode.SelectSingleNode("//img[contains(@data-testid, 'product-image-0')]").NextSibling.OuterHtml;
            var startIndex = image.IndexOf("https://productimages.coles.com.au");
            var endIndex = image.IndexOf(" ", startIndex);
            image = image.Substring(startIndex, endIndex - startIndex);

            //Scrape Price
            var price = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='price__value']")?.InnerHtml;

            //Scrape Name
            var name = htmlDoc.DocumentNode.SelectSingleNode("//h1[@class='LinesEllipsis  product__title']")?.InnerHtml;
            name = Regex.Replace(name ?? string.Empty, "<.*?>|&.*?;", string.Empty);

            //Scrape Save Amount
            var saveAmount = htmlDoc.DocumentNode.SelectSingleNode("//section[@class='badge-label']")?.InnerHtml;

            //Scrape Price Per Hundred Grams
            var pricePerHundredGrams = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='price__calculation_method']")?.InnerHtml;

            //Map data
            product.Price = price == null ? 0 : Helper.ConvertToPrice(price);
            product.Image = image;
            product.Name = name;
            product.SaveAmount = saveAmount == null ? 0 : Helper.ConvertToPrice(saveAmount);
            product.PricePerHundredGrams = pricePerHundredGrams == null ? 0 : Helper.ConvertToPrice(pricePerHundredGrams);
        }
    }
}