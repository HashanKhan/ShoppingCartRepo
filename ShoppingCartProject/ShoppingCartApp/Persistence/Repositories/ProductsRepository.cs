using ShoppingCartApp.Domain.IRepositories;
using ShoppingCartApp.Domain.Models;
using ShoppingCartApp.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp.Persistence.Repositories
{
    public class ProductsRepository : BaseRepository, IProductsRepository
    {
        public ProductsRepository(ShoppingCartContext context) : base(context)
        {
        }

        //Retrieve all productCategories from the db.
        public IEnumerable<ProductCategory> GetAllProductCategories()
        {
            return _context.ProductCategory.ToList();
        }

        //Retrieve all products for category ID from the db.
        public IEnumerable<Product> GetAllProductsByCategoryID(int categoryID)
        {
            var products = _context.Product.Where(p => p.ProductCategoryId == categoryID).ToList();

            return products;
        }

        //Retrieve a product by name from the db. 
        public Product FindProductByName(string Name)
        {
            return _context.Product.SingleOrDefault(p => p.Name == Name);
        }

        //Add new product record to the db.
        public string AddNewCartItem(Cart cart)
        {
                _context.Cart.Add(cart);
                _context.SaveChanges();

                return "The Product Registered Successfully.";
        }
    }
}
