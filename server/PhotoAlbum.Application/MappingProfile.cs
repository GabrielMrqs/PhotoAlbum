using Albums.Domain;
using AutoMapper;
using PhotoAlbum.Application.PhotoModule.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Photo, ViewPhotoDTO>()
                .ForMember(dest => dest.ImageBase64, opt => opt.MapFrom(src => src.ImageBase64));
        }
    }
}
