using Albums.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albums.Infra.ClientModule
{
    public class ClientEntityConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username).IsRequired();

            builder.Property(x => x.Password).IsRequired();

            builder.Property(x => x.Email).IsRequired();

            builder.HasOne(x => x.Album)
                   .WithOne(x => x.Client)
                   .HasForeignKey<Album>(x => x.ClientId);
        }
    }
}
