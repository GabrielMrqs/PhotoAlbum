using Albums.Domain;
using Albums.Infra.UserModule;
using MediatR;
using PhotoAlbum.Application.PhotoModule.DTO_s;

namespace PhotoAlbum.Application.PhotoModule
{
    public class AddPhotoHandler : IRequestHandler<AddPhotoRequest>
    {
        private readonly UserRepository _userRepository;

        public AddPhotoHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(AddPhotoRequest request, CancellationToken cancellationToken)
        {
            var photoDTO = request.AddphotoDTO;

            var user = await _userRepository.GetById(photoDTO.UserId);

            var photo = new Photo(photoDTO.PhotoBase64, photoDTO.Description, photoDTO.Title);

            user.Album.AddPhoto(photo);

            await _userRepository.Update(user);

            return Unit.Value;
        }
    }
    public record AddPhotoRequest(AddPhotoDTO AddphotoDTO) : IRequest;
}
