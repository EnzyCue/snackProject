using Api.Application.Snack.Helpers;
using Api.Domain.Snack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.Snack.Interfaces
{
    public interface IStoreService
    {
        public ProductOptions ProductOptions { get; set; }

        public Task GetStoreProduct(Product product);
    }
}