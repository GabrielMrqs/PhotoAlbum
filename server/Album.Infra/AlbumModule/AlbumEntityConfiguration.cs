using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Albums.Domain;

namespace Albums.Infra.AlbumModule
{
    public class AlbumEntityConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Albums");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Photos);

            builder.HasOne(x => x.Client)
                   .WithOne(x => x.Album)
                   .HasForeignKey<Album>(x => x.ClientId);

            builder.HasMany(x => x.Photos)
                   .WithOne(x => x.Album)
                   .HasForeignKey(x => x.AlbumId);
        }
    }
}
