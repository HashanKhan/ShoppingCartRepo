using ShoppingCartApp.Domain.Models;
using System.Collections.Generic;

namespace ShoppingCartApp.Domain.IServices
{
    public interface IProductsService
    {
        IEnumerable<ProductCategory> GetAllProductCategories();
    }
}
