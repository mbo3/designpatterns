namespace Builder.Models
{
    class OrderProduct
    {
        public Product Product { get; }
        public int Quanity { get; set; }

        public OrderProduct(Product product, int quanity)
        {
            Product = product;
            Quanity = quanity;
        }

        public override string ToString()
        {
            return $"{Product.Name} {Quanity} x {Product.Price.ToString("0.00")}";
        }
    }
}
