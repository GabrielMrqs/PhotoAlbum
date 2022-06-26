using Shared.Domain;

namespace Albums.Domain
{
    public class Login : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid UserId { get; set; }

        public Login(string email, string password, Guid userId)
        {
            Email = email;
            Password = password;
            UserId = userId;
        }
    }
}
