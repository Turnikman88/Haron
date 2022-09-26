using Haron.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Haron.Infrastructure.Data.Identity.DBContext.EntityConfigurations
{
    internal class RolePermissionConfig : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.RoleId, x.PermissionId }).IsUnique();

            builder.HasOne(x => x.Role)
                   .WithMany(x => x.RolePermissions)
                   .HasForeignKey(x => x.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Permission)
                   .WithMany(x => x.RolePermissions)
                   .HasForeignKey(x => x.PermissionId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}