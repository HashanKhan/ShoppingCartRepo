using ShoppingCartApp.Domain.IRepositories;
using ShoppingCartApp.Domain.Models;
using ShoppingCartApp.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp.Persistence.Repositories
{
    public class CartRepository : BaseRepository, ICartRepository
    {
        public CartRepository(ShoppingCartContext context) : base(context)
        {
        }

        //Retrieve all cartItems from the db.
        public IEnumerable<Cart> GetAllCartItems()
        {
            return _context.Cart.ToList();
        }
    }
}
