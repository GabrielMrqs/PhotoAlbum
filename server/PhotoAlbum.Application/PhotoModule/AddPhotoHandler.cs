using Albums.Domain;
using Albums.Infra.AlbumModule;
using MediatR;
using PhotoAlbum.Application.PhotoModule.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Application.PhotoModule
{
    public class AddPhotoHandler : IRequestHandler<AddPhotoRequest>
    {
        private readonly AlbumRepository _albumRepository;

        public AddPhotoHandler(AlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<Unit> Handle(AddPhotoRequest request, CancellationToken cancellationToken)
        {
            var photoDTO = request.AddphotoDTO;

            var album = await _albumRepository.GetByClientIdAsync(photoDTO.ClientId);

            var photo = new Photo(photoDTO.PhotoBase64);

            album.AddPhoto(photo);

            await _albumRepository.Update(album);

            return Unit.Value;
        }
    }
    public record AddPhotoRequest(AddPhotoDTO AddphotoDTO) : IRequest;
}
