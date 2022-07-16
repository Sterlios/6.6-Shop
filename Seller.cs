using System;
using System.Collections.Generic;

namespace Shop
{
    class Seller: Person
    {
        private Customer _customer;
        private Position _requestPosition;

        public Seller(string name) : base(name, 0)
        {
            Products = new List<Product>() {
                    new Product("Хлеб", 60),
                    new Product("Топор", 10000),
                    new Product("Лук", 12000),
                    new Product("Стрелы", 500),
                    new Product("Элексир маны", 100),
                    new Product("Элексир здоровья", 100),
                    new Product("Кирка", 400),
                    new Product("Камень бессмертных", 1000),
                    new Product("Знак преступника", 800),
                    new Product("Бронежилет", 8000),
                    new Product("Кольцо", 4000),
                    new Product("Знамя", 7500)
                };
        }

        public void Serve(Customer customer)
        {
            bool isContinue = true;
            _customer = customer;

            while (isContinue)
            {
                ShowInventory(new Position(0, 0));
                _requestPosition = new Position(Console.CursorLeft, Console.CursorTop + 1);
                _customer.ShowInventory();
                int numberProduct = RequestProduct();
                _customer.TryAddProduct(Products[numberProduct].ToCopy(), Products[numberProduct].Price);
            }
        }

        private int RequestProduct()
        {
            int numberProduct = -1;
            bool isCorrectNumber = false;

            Console.SetCursorPosition(_requestPosition.X, _requestPosition.Y);
            Console.WriteLine("Какой предмет хочешь купить, путник?");
            Console.Write("Введи номер предмета: ");

            Position numberPosition = new Position(Console.CursorLeft, Console.CursorTop);

            while (isCorrectNumber == false)
            {
                Console.SetCursorPosition(numberPosition.X, numberPosition.Y);
                numberProduct = _customer.GetNumber() - 1;

                if (numberProduct >= Products.Count || numberProduct < 0)
                {
                    WriteMessage("Такого товара у меня нет.");
                    ClearText(numberProduct.ToString(), numberPosition);
                }
                else
                {
                    isCorrectNumber = true;
                }
            }

            ClearText(numberProduct.ToString(), numberPosition);
            return numberProduct;
        }

        protected override sealed string GetProductText(Product product)
        {
            string text = base.GetProductText(product);

            text += " Цена: " + product.Price;

            return text;
        }
    }
}
