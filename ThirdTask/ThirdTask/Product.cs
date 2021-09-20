using System.Linq;

namespace ThirdTask
{
    public enum Categories
    {
        Electronics,
        Grocery,
        Snacks,
        Drinks,
        Furniture
    }
    public class Product
    {
        public string name { get; set; }
        public Categories category { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }

        public Product()
        {
            name = Faker.Lorem.Words(1).First();
            category = Faker.Enum.Random<Categories>();
            price = Faker.RandomNumber.Next(1, 100);
            quantity = Faker.RandomNumber.Next(1, 1000);
        }
    }
}
