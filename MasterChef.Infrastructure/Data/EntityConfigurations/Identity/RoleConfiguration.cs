using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MasterChef.Infrastructure.Data.EntityConfigurations.Identity
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder
                .ToTable("AspNetRoles");

            builder
                .Property(r => r.Id)
                .HasColumnType("nvarchar(450)");

            builder
                .Property(r => r.ConcurrencyStamp)
                .IsConcurrencyToken()
                .HasColumnType("nvarchar(max)");

            builder
                .Property(r => r.Name)
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder
                .Property(r => r.NormalizedName)
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.HasKey("Id");

            builder
                .HasIndex(r => r.NormalizedName)
                .IsUnique()
                .HasName("RoleNameIndex")
                .HasFilter("[NormalizedName] IS NOT NULL");
        }
    }
}