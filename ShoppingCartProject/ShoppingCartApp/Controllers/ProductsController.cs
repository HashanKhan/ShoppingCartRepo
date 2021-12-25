using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Domain.DTOs;
using ShoppingCartApp.Domain.IServices;
using ShoppingCartApp.Domain.Models;
using ShoppingCartApp.Extensions;
using System.Collections.Generic;
using System.Linq;

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
        [HttpGet("{categoryID:int}")]
        public IEnumerable<Product> GetAllProductsByCategoryID(int categoryID)
        {
            var productsForCategory = _productsService.GetAllProductsByCategoryID(categoryID);

            return productsForCategory;
        }

        //Update the ShoppingCart.
        [HttpPost("checkAvailability")]
        public ActionResult<string> UpdateShoppingCart([FromBody] CartItem[] cartItemArray)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var itemResult = from cartItem in cartItemArray
                             group cartItem by cartItem.Name into g
                             let count = g.Count()
                             select new { Value = g.Key, Count = count };

            foreach (var i in itemResult)
            {
                var Product = _productsService.FindProductByName(i.Value);

                var cart = new Cart()
                {
                    ProductCategoryId = Product.ProductCategoryId,
                    ProductId = Product.Id,
                    ProductName = Product.Name,
                    Quantity = i.Count,
                    SubTotal = Product.Price*i.Count
                };

                var result = _productsService.AddNewCartItem(cart);
            }
            return "The Cart is Updated.";
        }
    }
}
