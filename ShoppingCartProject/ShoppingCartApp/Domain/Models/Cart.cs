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
