using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstTask
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int forksCount;

            User user1 = new("Alex1");
            User user2 = new("Alex2");
            User user3 = new("Alex3");
            User user4 = new("Alex4");
            User user5 = new("Alex5");

            Console.Write("\nPress enter to exit");

            while (true)
            {
                Console.Write("\n\nNew round\n\n");
                forksCount = 2;
                user1.haveFork = false;
                user2.haveFork = false;
                user3.haveFork = false;
                user4.haveFork = false;
                user5.haveFork = false;

                List<Task<User>> userTasks = new() { UserStartAsync(user1), UserStartAsync(user2), UserStartAsync(user3), UserStartAsync(user4), UserStartAsync(user5) };

                while (userTasks.Count > 0)
                {
                    Task<User> userTask = await Task.WhenAny(userTasks);

                    if (forksCount > 0)
                    {
                        userTask.Result.haveFork = true;
                        Console.WriteLine("{0} pick a fork", userTask.Result.name);
                        forksCount--;
                    }
                    else
                    {
                        Console.WriteLine("Not enough forks");
                    }

                    userTasks.Remove(userTask);
                }

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }

        static async Task<User> UserStartAsync(User user)
        {
            Random rand = new();
            await Task.Delay(rand.Next(1000, 5000));
            return user;
        }
    }
}
