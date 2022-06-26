using Albums.Domain;
using Albums.Infra.UserModule;
using AutoMapper;
using MediatR;
using PhotoAlbum.Application.PhotoModule.DTO_s;

namespace PhotoAlbum.Application.PhotoModule
{
    public class GetPhotoAlbumHandler : IRequestHandler<GetPhotoAlbumRequest, IList<ViewPhotoDTO>>
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetPhotoAlbumHandler(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IList<ViewPhotoDTO>> Handle(GetPhotoAlbumRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.UserId);

            var album = user.Album;

            var photos = _mapper.Map<List<Photo>, List<ViewPhotoDTO>>(album.Photos);

            return photos;
        }
    }
    public record GetPhotoAlbumRequest(Guid UserId) : IRequest<IList<ViewPhotoDTO>>;
}