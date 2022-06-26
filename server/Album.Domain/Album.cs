using Shared.Domain;

namespace Albums.Domain
{
    public class Album : Entity
    {
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
