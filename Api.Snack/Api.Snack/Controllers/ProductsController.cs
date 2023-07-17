using Api.Application.Snack.Services;
using Api.Snack.Helpers;
using Api.Snack.Models;
using Api.Snack.Services;
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
        private readonly ColesService _colesService;
        private readonly WoolworthsService _woolworthsService;
        private readonly CacheService _cacheService;

        public ProductsController(ILogger<ProductsController> logger, ColesService colesService, WoolworthsService woolworthsService, CacheService cacheService)
        {
            _logger = logger; 
            _colesService = colesService;
            _woolworthsService = woolworthsService;
            _cacheService = cacheService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            // check if its cached
            if (_cacheService.TryGetCache<List<ProductComparison>>("Products", out var cache))
            {
                return new OkObjectResult(cache);
            }

            //Get list of products
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fileProducts = System.IO.File.ReadAllText($"{currentDirectory}\\products.json");
            var productComparisons = JsonSerializer.Deserialize<List<ProductComparison>>(fileProducts, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var cookies = Helper.GetCookies();

            foreach (var productComparison in productComparisons)
            {
                await _colesService.GetColesProduct(productComparison.Coles);

                await _woolworthsService.GetWoolworthsProduct(productComparison.Woolworths, cookies);
            }

            _cacheService.SetCacheKey("Products", productComparisons);

            return new OkObjectResult(productComparisons);
        }

        // encode the information into an object
        // send the object back to the user through api
    }
}