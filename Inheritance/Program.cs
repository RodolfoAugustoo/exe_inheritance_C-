using System;
using System.Globalization;
using System.Collections.Generic;
using Inheritance.Entities;


namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            Console.Write("Enter the  number of products: ");
            int num = int.Parse(Console.ReadLine());

            for(int i=0; i < num; i++)
            {
                Console.Write($"Product #{i+1} data:\r\nCommon, used or imported (c/u/i)? ");
                char op = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(op == 'c')
                {
                    products.Add(new Product(name, price));
                }

                else if(op == 'i')
                {
                    Console.Write("Customs fee: ");
                    double customFee = double.Parse(Console.ReadLine());

                    products.Add(new ImportedProduct(name, price, customFee));
                }

                else if(op == 'u' || op == 'U')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime manufDate = DateTime.Parse(Console.ReadLine());
                    products.Add(new UsedProduct(name, price, manufDate));
                }
            }

            Console.WriteLine("\r\nPRICE TAGS");
            foreach(Product p in products)
            {
                Console.WriteLine(p.PriceTag());
            }
        }
    }
}
