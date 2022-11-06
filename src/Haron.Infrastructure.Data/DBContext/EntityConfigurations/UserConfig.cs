using Haron.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Haron.Infrastructure.Data.Identity.DBContext.EntityConfigurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.NormalizedEmail).IsUnique();

            builder.HasIndex(x => x.NormalizedUserName).IsUnique();

            builder.Property(x => x.Email).HasMaxLength(300).IsRequired();

            builder.Property(x => x.NormalizedEmail).HasMaxLength(300).IsRequired();

            builder.Property(x => x.UserName).HasMaxLength(100).IsRequired();

            builder.Property(x => x.NormalizedUserName).HasMaxLength(100).IsRequired();

            builder.Property(x => x.FirstName).HasMaxLength(30).IsRequired();

            builder.Property(x => x.MiddleName).HasMaxLength(30);

            builder.Property(x => x.LastName).HasMaxLength(30).IsRequired();

            builder.Property(x => x.PasswordHash).IsRequired();

            builder.Property(x => x.AvatarUrl).HasMaxLength(500);

            builder.Property(x => x.CreatedOn).IsRequired();
        }
    }
}