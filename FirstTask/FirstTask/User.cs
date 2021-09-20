using System;
using System.Threading.Tasks;

namespace FirstTask
{
    public class User
    {
        public string name;
        public bool haveFork;

        public User(string name)
        {
            this.name = name;
            this.haveFork = false;
        }

        public async Task<User> UserStart()
        {
            Random rand = new();
            await Task.Delay(rand.Next(1000, 5000));
            return this;
        }
    }
}