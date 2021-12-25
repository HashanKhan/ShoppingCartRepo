using ShoppingCartApp.Domain.IRepositories;
using ShoppingCartApp.Domain.IServices;
using ShoppingCartApp.Domain.Models;
using System.Collections.Generic;

namespace ShoppingCartApp.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productRepository;

        public ProductsService(IProductsRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        //Get all productCategories service.
        public IEnumerable<ProductCategory> GetAllProductCategories()
        {
            return _productRepository.GetAllProductCategories();
        }

        //Get all productsForCategory service.
        public IEnumerable<Product> GetAllProductsByCategoryID(int categoryID)
        {
            return _productRepository.GetAllProductsByCategoryID(categoryID);
        }

        //Get a product by the name.
        public Product FindProductByName(string Name)
        {
            return _productRepository.FindProductByName(Name);
        }

        //Add new CartItem.
        public string AddNewCartItem(Cart cart)
        {
            var result = _productRepository.AddNewCartItem(cart);

            return result;
        }
    }
}
