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

            foreach (Product product in Products)
            {
                productNumber++;
                string productNumberText = productNumber.ToString() + ") ";
                
                for (int i = (int)Math.Log10(productNumber); i < (int)Math.Log10(Products.Count); i++)
                {
                    productNumberText += " ";
                }

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
            string text = "";

            for (int i = 0; i < nameFieldLength; i++)
            {
                text += i < product.Name.Length ? product.Name[i].ToString() : ".";
            }

            return text;
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
