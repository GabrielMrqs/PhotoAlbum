using Shared.Domain;

namespace Albums.Domain
{
    public class Album : Entity
    {
        public User User { get; set; }
        public Guid UserId { get; set; }
        public List<Photo> Photos { get; set; }

        public Album()
        {
            Photos = new();
        }
        public void AddPhoto(Photo photo)
        {
            Photos.Add(photo);
        }
    }
}
