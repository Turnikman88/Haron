using Haron.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Haron.Infrastructure.Data.Identity.DBContext.EntityConfigurations
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.NormalizedEmail);

            builder.HasIndex(x => x.NormalizedUsername);

            builder.Property(x => x.Email).HasMaxLength(254).IsRequired();

            builder.Property(x => x.NormalizedEmail).HasMaxLength(254).IsRequired();

            builder.Property(x => x.Username).HasMaxLength(100).IsRequired();

            builder.Property(x => x.NormalizedUsername).HasMaxLength(100).IsRequired();

            builder.Property(x => x.FirstName).HasMaxLength(30).IsRequired();

            builder.Property(x => x.LastName).HasMaxLength(30).IsRequired();

            builder.Property(x => x.PasswordHash).IsRequired();
        }
    }
}