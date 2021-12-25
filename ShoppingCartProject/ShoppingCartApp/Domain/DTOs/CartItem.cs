﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Domain.DTOs
{
    public class CartItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int ProductCategoryId { get; set; }

        public string UUID { get; set; }

        public bool? Remove { get; set; }
    }
}
