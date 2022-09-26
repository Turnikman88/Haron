using Haron.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Haron.Infrastructure.Data.Identity.DBContext.EntityConfigurations
{
    internal class PermissionConfig : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.Name, x.AccessLevel }).IsUnique();

            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
        }
    }
}