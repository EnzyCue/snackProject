using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Snack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColesController : ControllerBase
    {
        private readonly ILogger<ColesController> _logger;
        private readonly string _colesProductEndpoint = "https://www.coles.com.au/product/";

        public ColesController(ILogger<ColesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            // go from id -> html url
            string url = $"{_colesProductEndpoint}{id}";

            // use html agility pack to extract the information about the product
            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(url);

            //Scrape price
            var price = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='price__value']").InnerHtml;

            return new OkObjectResult(price);
        }

        // encode the information into an object
        // send the object back to the user through api
    }
}