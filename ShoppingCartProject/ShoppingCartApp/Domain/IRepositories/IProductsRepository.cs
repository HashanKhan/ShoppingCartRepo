using ShoppingCartApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Domain.IRepositories
{
    public interface IProductsRepository
    {
        IEnumerable<ProductCategory> GetAllProductCategories();

        IEnumerable<Product> GetAllProductsByCategoryID(int categoryID);

        Product FindProductByName(string Name);

        string AddNewCartItem(Cart cart);
    }
}
