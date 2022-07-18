using System;
using System.Collections.Generic;

namespace Shop
{
    class Person
    {
        protected string Name;
        protected uint Money;
        protected List<Product> Products;
        protected Position InventoryPosition;

        public Person(string name, uint money)
        {
            Name = name;
            Money = money;
            Products = new List<Product>();
        }

        protected void ShowInventory(Position inventoryPosition)
        {
            int productNumber = 0;

            InventoryPosition = inventoryPosition;
            Console.WriteLine(Name);

            InventoryPosition.SetNextLine();
            ShowMoney();

            InventoryPosition.SetNextLine();
            Console.WriteLine("Инвентарь:");

            List<Product> uniqueProducts = new List<Product>();

            foreach (Product product in Products)
            {
                bool isUnique = true;
                foreach (Product uniqueProduct in uniqueProducts)
                {
                    if (uniqueProduct.Compare(product))
                    {
                        isUnique = false;
                        break;
                    }
                }

                if (isUnique)
                {
                    uniqueProducts.Add(product);
                }
            }

            foreach (Product product in uniqueProducts)
            {
                productNumber++;
                string seperator = ") ";
                string productNumberText = productNumber + seperator;
                string maxNumberText = uniqueProducts.Count + seperator;
                productNumberText = productNumberText.PadRight(maxNumberText.Length);

                InventoryPosition.SetNextLine();
                Console.WriteLine(productNumberText + GetProductText(product));
            }
        }

        protected void ShowMoney()
        {
            Console.Write("В кошельке: ");
            Position moneyPosition = new Position(Console.CursorLeft, Console.CursorTop);
            ClearText(uint.MaxValue.ToString(), moneyPosition);
            Console.SetCursorPosition(moneyPosition.X, moneyPosition.Y);
            Console.WriteLine(Money);
        }

        protected virtual string GetProductText(Product product)
        {
            int nameFieldLength = 20;
            return product.Name.PadRight(nameFieldLength, '.');
        }

        protected void WriteMessage(string massage = "")
        {
            string secondLine = "---------------------------------------------------";
            string thirdLine = "Нажмите любую клавишу для продолжения!";

            Position firstLinePosition = new Position(Console.CursorLeft, Console.CursorTop);
            Console.WriteLine(massage);

            Position secondLinePosition = new Position(Console.CursorLeft, Console.CursorTop);
            Console.WriteLine(secondLine);

            Position thirdLinePosition = new Position(Console.CursorLeft, Console.CursorTop);
            Console.WriteLine(thirdLine);

            Console.ReadKey();

            ClearText(massage, firstLinePosition);
            ClearText(secondLine, secondLinePosition);
            ClearText(thirdLine, thirdLinePosition);
        }

        protected void ClearText(string text, Position position)
        {
            Console.SetCursorPosition(position.X, position.Y);

            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(" ");
            }
        }
    }
}
