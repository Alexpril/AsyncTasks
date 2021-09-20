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
        public string Name { get; set; }
        public Categories Category { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product()
        {
            Name = Faker.Lorem.Words(1).First();
            Category = Faker.Enum.Random<Categories>();
            Price = Faker.RandomNumber.Next(1, 100);
            Quantity = Faker.RandomNumber.Next(1, 1000);
        }
    }
}
