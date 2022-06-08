using Albums.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albums.Infra.PhotoModule
{
    public class PhotoEntityConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.ToTable("Photos");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Album)
                   .WithMany(x => x.Photos)
                   .HasForeignKey(x => x.AlbumId);
        }
    }
}
