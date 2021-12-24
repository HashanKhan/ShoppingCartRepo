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


        
    }
}
