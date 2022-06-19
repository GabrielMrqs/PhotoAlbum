using Shared.Domain;

namespace Albums.Domain
{
    public class User : Entity
    {
        public string Username { get; set; }
        public Login Login { get; set; }
        public Album Album { get; set; }

        public User()
        {
            Album = new();
        }

    }
}