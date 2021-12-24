using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Domain.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
