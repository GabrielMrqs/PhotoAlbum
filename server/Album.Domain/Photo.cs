using Shared.Domain;

namespace Albums.Domain
{
    public class Photo : Entity
    {
        public string ImageBase64 { get; set; }
        public Album Album { get; set; }
        public Guid AlbumId { get; set; }

        public Photo(string imageBase64)
        {
            ImageBase64 = imageBase64;
        }
    }
}