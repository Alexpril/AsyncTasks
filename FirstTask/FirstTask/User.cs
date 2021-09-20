namespace FirstTask
{
    public class User
    {
        public string Name { get; set; }
        public bool HaveFork { get; set; }
        public User(string name)
        {
            this.Name = name;
            this.HaveFork = false;
        }
    }
}