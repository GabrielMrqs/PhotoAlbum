using Albums.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albums.Infra.UserModule
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username).IsRequired();

            builder.HasOne(x => x.Album)
                   .WithOne(x => x.User)
                   .HasForeignKey<Album>(x => x.UserId);

            builder.HasOne(x => x.Login)
                   .WithOne(x => x.User)
                   .HasForeignKey<Login>(x => x.UserId);
        }
    }
}
