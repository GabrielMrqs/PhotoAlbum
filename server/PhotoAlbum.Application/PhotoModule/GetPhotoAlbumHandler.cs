using Albums.Domain;
using Albums.Infra.AlbumModule;
using AutoMapper;
using MediatR;
using PhotoAlbum.Application.PhotoModule.DTO_s;

namespace PhotoAlbum.Application.PhotoModule
{
    public class GetPhotoAlbumHandler : IRequestHandler<GetPhotoAlbumRequest, IList<ViewPhotoDTO>>
    {
        private readonly AlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public GetPhotoAlbumHandler(AlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        public async Task<IList<ViewPhotoDTO>> Handle(GetPhotoAlbumRequest request, CancellationToken cancellationToken)
        {
            var album = await _albumRepository.GetByClientIdAsync(request.ClientId);
            var photos = _mapper.Map<List<Photo>, List<ViewPhotoDTO>>(album.Photos);
            return photos;
        }
    }
    public record GetPhotoAlbumRequest(Guid ClientId) : IRequest<IList<ViewPhotoDTO>>;
}