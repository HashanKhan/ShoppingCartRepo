using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }

        [ForeignKey("ProductCategory")]
        public int ProductCategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
