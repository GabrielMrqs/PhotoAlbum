using Shared.Domain;

namespace Albums.Domain
{
    public class Login : Entity
    {
        public User User { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Login(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
