using Api.Snack.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.Json;

namespace Api.Snack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly string _colesProductEndpoint = "https://www.coles.com.au/product/";

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            //Get list of products
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fileProducts = System.IO.File.ReadAllText($"{currentDirectory}\\products.json");
            var products = JsonSerializer.Deserialize<List<ProductComparison>>(fileProducts, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

/*            // go from id -> html url
            string url = $"{_colesProductEndpoint}{_colesProductEndpoint}";

            // use html agility pack to extract the information about the product
            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(url);

            //Scrape price
            var price = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='price__value']").InnerHtml;*/

            return new OkObjectResult(products);
        }

        // encode the information into an object
        // send the object back to the user through api
    }
}