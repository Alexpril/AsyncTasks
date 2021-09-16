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
        public string Name;
        public Categories Category;
        public double Price;
        public int Quantity;

        public Product()
        {
            Name = Faker.Lorem.Words(1).First();
            Category = Faker.Enum.Random<Categories>();
            Price = Faker.RandomNumber.Next(1, 100);
            Quantity = Faker.RandomNumber.Next(1, 1000);
        }
    }
}
