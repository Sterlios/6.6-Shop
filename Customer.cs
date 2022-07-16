using System;
using System.Collections.Generic;

namespace Shop
{
    class Customer: Person
    {
        private readonly Dictionary<string, List<Product>> _inventory;

        public Customer(string name, uint money) : base(name, money)
        {
            _inventory = new Dictionary<string, List<Product>>();
        }

        public void ShowInventory()
        {
            Products = new List<Product>();

            foreach (List<Product> products in _inventory.Values)
            {
                Products.Add(products[0]);
            }

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
                    AddProduct(product);
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

            text += " Количество: " + _inventory[product.Name].Count;

            return text;
        }

        private void AddProduct(Product product)
        {
            if (CompareProducts(product))
            {
                _inventory[product.Name].Add(product);
            }
            else
            {
                List<Product> products = new List<Product>() { product };
                _inventory.Add(product.Name, products);
            }
        }

        private bool CompareProducts(Product product)
        {
            foreach (List<Product> items in _inventory.Values)
            {
                if (items[0].Compare(product))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
