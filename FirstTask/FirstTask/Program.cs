using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstTask
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int ForksCount = 2;

            User User1 = new("Alex1");
            User User2 = new("Alex2");
            User User3 = new("Alex3");
            User User4 = new("Alex4");
            User User5 = new("Alex5");

            var Users = new List<Task<User>> { User1.UserStart(), User2.UserStart(), User3.UserStart(), User4.UserStart(), User5.UserStart() };

            while(Users.Count > 0)
            {
                Task<User> readyUser = await Task.WhenAny(Users);
                var User = readyUser.Result;
                
                if(ForksCount > 0)
                {
                    
                    Console.WriteLine("Pick Fork User name {0}",User.name);
                    ForksCount--;
                } else
                {
                    Console.WriteLine("Not enough forks");
                }
                Users.Remove(readyUser);
            }
        }
    }
}
