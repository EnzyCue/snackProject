using Api.Application.Snack.Helpers;
using Api.Application.Snack.Services;
using Api.Domain.Snack.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Snack.Framework.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Application.Snack.Queries
{
    public static class GetProducts
    {
        public record Query() : IRequest<MediatorResponse>;

        public class Handler : IRequestHandler<Query, MediatorResponse>
        {
            private readonly ColesService _colesService;
            private readonly WoolworthsService _woolworthsService;
            private readonly CacheService _cacheService;

            public Handler(ColesService colesService, WoolworthsService woolworthsService, CacheService cacheService)
            {
                _colesService = colesService;
                _woolworthsService = woolworthsService;
                _cacheService = cacheService;
            }

            public Task<MediatorResponse> Handle(Query query, CancellationToken cancellationToken)
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
            }
        }
    }
}