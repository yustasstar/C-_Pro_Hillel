namespace Lesson7
{
    public class User : IDisposable
    {
        public string Name { get; set; }
        
        public string Email { get; set; }
        public User(string name, string email) 
        {
            Name = name;
            Email = email;
        }

        public void Dispose()
        {
            Console.WriteLine($"User {Name} - {Email} disposed!");
        }
    }
}
