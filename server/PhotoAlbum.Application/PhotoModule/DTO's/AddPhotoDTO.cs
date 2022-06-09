using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Application.PhotoModule.DTO_s
{
    public class AddPhotoDTO
    {
        public string PhotoBase64 { get; set; }
        public Guid ClientId { get; set; }
    }
}
