using Haron.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Haron.Infrastructure.Data.Identity.DBContext.EntityConfigurations
{
    internal class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
        }
    }
}