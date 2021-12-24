using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Domain.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public int ProductCategoryId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal SubTotal { get; set; }
    }
}
