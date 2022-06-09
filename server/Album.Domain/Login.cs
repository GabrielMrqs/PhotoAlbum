using Shared.Domain;

namespace Albums.Domain
{
    public class Login : Entity
    {
        public Client Client { get; set; }
        public Guid ClientId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Login(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
