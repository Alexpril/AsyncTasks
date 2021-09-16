using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ThirdTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ConsoleKey key;
            Console.WriteLine("\nPress number. Enter to exit.");
            Console.WriteLine("1.Group by category");
            Console.WriteLine("2.Total Quantity");
            Console.WriteLine("3.Total price");
            Console.WriteLine("4.Sort by name");

            List<Product> products = new();
            List<Product> resProd = new();

            int prodCount = 100;
            for (int i = 0; i < prodCount; i++)
            {
                Product prod = new Product();
                products.Add(prod);
            }

            do {
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    var prodgroups = from product in products group product by product.Category;

                    foreach (IGrouping<Categories, Product> g in prodgroups)
                    {
                        Console.Write("\n\n\n" + g.Key + "\n\n\n");
                        foreach (var t in g)
                            Console.Write("\n Name: {0}\n Category: {1}\n Price: {2}\n Quantity: {3}\n", t.Name, t.Category, t.Price, t.Quantity);
                    }
                } else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    double qty = 0;
                    foreach(Product prod in products)
                    {
                        qty += prod.Quantity;
                    }
                    Console.WriteLine("Total Quantity: {0}\n", qty);
                }
                else if(key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                {
                    double sum = 0;
                    foreach (Product prod in products)
                    {
                        sum += prod.Price * prod.Quantity;
                    }
                    Console.WriteLine("Total Price: {0}\n", sum);
                }
                else if(key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
                {
                    var sortprod = from product in products orderby product.Name select product;

                    foreach (Product prod in sortprod)
                    {
                        Console.Write("\n Name: {0}\n Category: {1}\n Price: {2}\n Quantity: {3}\n", prod.Name, prod.Category, prod.Price, prod.Quantity);
                    }
                    Console.WriteLine("Sort by name\n");
                }
            } while (key != ConsoleKey.Enter);

            XmlSerializer serialiser = new XmlSerializer(typeof(List<Product>));
            TextWriter filestream = new StreamWriter(@"output.xml");
            serialiser.Serialize(filestream, products);
            filestream.Close();
        }
    }
}
