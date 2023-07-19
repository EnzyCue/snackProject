using Api.Application.Snack.Queries;
using Microsoft.AspNetCore.Mvc;
using Snack.Framework.AspNetCore.Controllers;
using Snack.Framework.Mediator.Extensions;

namespace Api.Snack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : MediatorController
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var resp = await Mediator.Send(new GetProducts.Query());
            return resp.ToHttpResponse();
        }

        // encode the information into an object
        // send the object back to the user through api
    }
}