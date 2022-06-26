namespace PhotoAlbum.Application.PhotoModule.DTO_s
{
    public class AddPhotoDTO
    {
        public string PhotoBase64 { get; set; }
        public Guid UserId { get; set; }
    }
}
