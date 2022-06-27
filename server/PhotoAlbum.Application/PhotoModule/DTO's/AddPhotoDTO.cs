namespace PhotoAlbum.Application.PhotoModule.DTO_s
{
    public class AddPhotoDTO
    {
        public string PhotoBase64 { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public Guid UserId { get; set; }
    }
}
