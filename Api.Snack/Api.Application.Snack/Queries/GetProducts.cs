using Api.Application.Snack.Helpers;
using Api.Application.Snack.Interfaces;
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
            private readonly IEnumerable<IStoreService> _storeServices;
            private readonly CacheService _cacheService;

            public Handler(IEnumerable<IStoreService> storeServices, CacheService cacheService)
            {
                _storeServices = storeServices;
                _cacheService = cacheService;
            }

            public async Task<MediatorResponse> Handle(Query query, CancellationToken cancellationToken)
            {
                // check if its cached
                if (_cacheService.TryGetCache<List<ProductComparison>>("Products", out var cache))
                {
                    return MediatorResponse.Ok(cache);
                }

                //Get list of products
                string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var fileProducts = System.IO.File.ReadAllText($"{currentDirectory}\\products.json");
                var productComparisons = JsonSerializer.Deserialize<List<ProductComparison>>(fileProducts, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                foreach (var productComparison in productComparisons)
                {
                    foreach (var storeService in _storeServices)
                    {
                        var product = Helper.GetProductByStoreService(storeService, productComparison);

                        await storeService.GetStoreProduct(product);
                    }
                }

                _cacheService.SetCacheKey("Products", productComparisons);

                return MediatorResponse.Ok(productComparisons);
            }
        }
    }
}