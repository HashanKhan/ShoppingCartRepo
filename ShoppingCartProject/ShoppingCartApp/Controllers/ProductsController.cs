using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Domain.IServices;
using ShoppingCartApp.Domain.Models;
using ShoppingCartApp.Extensions;
using System.Collections.Generic;

namespace ShoppingCartApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        //Get All ProductCategories.
        [HttpGet]
        public IEnumerable<ProductCategory> GetAllProductCategories()
        {
            var productCategories = _productsService.GetAllProductCategories();

            return productCategories;
        }

        //Get All ProductsForCategory.
        //[HttpGet("categoryProducts")]
        //public IEnumerable<Product> GetAllProductCategories()
        //{
        //    var productCategories = _productsService.GetAllProductCategories();

        //    return productCategories;
        //}
    }
}
