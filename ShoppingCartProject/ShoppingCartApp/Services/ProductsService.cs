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

    }
}
