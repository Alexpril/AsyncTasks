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
            ConsoleKey key;
            Console.WriteLine("\nPress number. Enter to exit.");
            Console.WriteLine("1.Group by category");
            Console.WriteLine("2.Total Quantity");
            Console.WriteLine("3.Total price");
            Console.WriteLine("4.Sort by name");

            List<Product> products = new();
            List<Product> resProd = new();


            if (!(File.Exists(@"output.xml")))
            {
                int prodCount = 100;
                for (int i = 0; i < prodCount; i++)
                {
                    Product product = new();
                    products.Add(product);
                }
                XmlSerializer serialiser = new XmlSerializer(typeof(List<Product>));
                TextWriter filestream = new StreamWriter(@"output.xml");
                serialiser.Serialize(filestream, products);
                filestream.Close();
            } else
            {
                XmlSerializer serializer = new(typeof(List<Product>));
                StreamReader reader = new(@"output.xml");
                products = (List<Product>)serializer.Deserialize(reader);
                reader.Close();
            }
                
            do {
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    var productGroups = from product in products group product by product.Category;

                    foreach (IGrouping<Categories, Product> group in productGroups)
                    {
                        Console.Write("\n\n\n" + group.Key + "\n\n\n");
                        foreach (var groupProduct in group)
                            Console.Write("\n Name: {0}\n Category: {1}\n Price: {2}\n Quantity: {3}\n", groupProduct.Name, groupProduct.Category, groupProduct.Price, groupProduct.Quantity);
                    }
                } else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    int quantity = 0;
                    foreach(Product product in products)
                    {
                        quantity += product.Quantity;
                    }
                    Console.WriteLine("Total Quantity: {0}\n", quantity);
                } else if(key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                {
                    double sum = 0;
                    foreach (Product product in products)
                    {
                        sum += product.Price * product.Quantity;
                    }
                    Console.WriteLine("Total Price: {0}\n", sum);
                } else if(key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
                {
                    var sortprod = from product in products orderby product.Name select product;

                    foreach (Product prod in sortprod)
                    {
                        Console.Write("\n Name: {0}\n Category: {1}\n Price: {2}\n Quantity: {3}\n", prod.Name, prod.Category, prod.Price, prod.Quantity);
                    }
                    Console.WriteLine("Sort by name\n");
                }
            } while (key != ConsoleKey.Enter);

            
        }
    }
}
