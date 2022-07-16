namespace Shop
{
    class Product
    {
        public string Name { get; private set; }
        public uint Price { get; private set; }

        public Product(string name, uint price)
        {
            Name = name;
            Price = price;
        }

        public Product ToCopy()
        {
            return new Product(Name, 0);
        }

        public bool Compare(Product product)
        {
            return product.Name == Name;
        }
    }   
}
