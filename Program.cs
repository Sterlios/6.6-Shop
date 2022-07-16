namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Seller seller = new Seller("Торговец");
            Customer customer = new Customer("Покупатель", 20000);

            seller.Serve(customer);
        }
    }
}
