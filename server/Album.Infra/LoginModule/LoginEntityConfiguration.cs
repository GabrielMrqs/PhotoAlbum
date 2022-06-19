using Albums.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albums.Infra.LoginModule
{
    public class LoginEntityConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.ToTable("Login");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Password).IsRequired();

            builder.Property(x => x.Email).IsRequired();

            builder.HasOne(x => x.User)
                   .WithOne(x => x.Login)
                   .HasForeignKey<Album>(x => x.UserId);
        }
    }
}
