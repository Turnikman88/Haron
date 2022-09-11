using Haron.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haron.Infrastructure.Data.Identity.DBContext.EntityConfigurations
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();

            builder.HasIndex(x => x.NormalizedEmail).IsUnique();

            builder.Property(x => x.NormalizedEmail).HasMaxLength(100).IsRequired();

            builder.Property(x => x.Username).HasMaxLength(100).IsRequired();

            builder.HasIndex(x => x.NormalizedUsername).IsUnique();

            builder.Property(x => x.NormalizedUsername).HasMaxLength(100).IsRequired();

            builder.Property(x => x.FirstName).HasMaxLength(30).IsRequired();

            builder.Property(x => x.LastName).HasMaxLength(30).IsRequired();
        }
    }
}
