using Shared.Domain;

namespace Albums.Domain
{
    public class Album : Entity
    {
        public Client Client { get; set; }
        public Guid ClientId { get; set; }
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
