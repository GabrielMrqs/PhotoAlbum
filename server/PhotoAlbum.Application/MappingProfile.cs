using Albums.Domain;
using AutoMapper;
using PhotoAlbum.Application.PhotoModule.DTO_s;

namespace PhotoAlbum.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Photo, ViewPhotoDTO>()
                .ForMember(dest => dest.ImageBase64, opt => opt.MapFrom(src => src.ImageBase64))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
