using ShoppingCartApp.Domain.Models;
using System.Collections.Generic;

namespace ShoppingCartApp.Domain.IServices
{
    public interface IProductsService
    {
        IEnumerable<ProductCategory> GetAllProductCategories();

        IEnumerable<Product> GetAllProductsByCategoryID(int categoryID);

        Product FindProductByName(string Name);

        string AddNewCartItem(Cart cart);
    }
}
