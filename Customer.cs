using System;

namespace Shop
{
    class Customer: Person
    {
        public Customer(string name, uint money) : base(name, money) { }

        public void ShowInventory()
        {
            ShowInventory(new Position(50, 0));
        }

        public int GetNumber()
        {
            int.TryParse(Console.ReadLine(), out int number);
            return number;
        }

        public void TryAddProduct(Product product, uint price)
        {
            if (product is Product)
            {
                if (price <= Money)
                {
                    Products.Add(product);
                    Money -= price;
                }
                else
                {
                    WriteMessage("Недостаточно денег.");
                }
            }
            else
            {
                WriteMessage("Товар не получен");
            }
        }

        protected override sealed string GetProductText(Product product)
        {
            string text = base.GetProductText(product);
            int productCount = 0;

            foreach(Product item in Products)
            {
                if (item.Compare(product))
                {
                    productCount++;
                }
            }

            text += " Количество: " + productCount;

            return text;
        }
    }
}
