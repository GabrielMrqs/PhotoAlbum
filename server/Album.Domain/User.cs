using Shared.Domain;

namespace Albums.Domain
{
    public class User : Entity
    {
        public string Username { get; set; }
        public Album Album { get; set; }

        public User(string username)
        {
            Album = new();
            Username = username;
        }

    }
}