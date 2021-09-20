namespace FirstTask
{
    public class User
    {
        public string name { get; set; }
        public bool haveFork { get; set; }
        public User(string name)
        {
            this.name = name;
            this.haveFork = false;
        }
    }
}