using Shared.Domain;

namespace Albums.Domain
{
    public class Photo : Entity
    {
        public string ImageBase64 { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }

        public Photo(string imageBase64, string description, string title)
        {
            ImageBase64 = imageBase64;
            Description = description;
            Title = title;
        }
    }
}