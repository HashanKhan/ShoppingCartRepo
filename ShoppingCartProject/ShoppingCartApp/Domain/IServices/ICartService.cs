using ShoppingCartApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Domain.IServices
{
    public interface ICartService
    {
        IEnumerable<Cart> GetAllCartItems();
    }
}
