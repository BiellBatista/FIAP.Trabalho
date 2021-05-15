using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MasterChef.Infrastructure.Data.EntityConfigurations.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder
               .ToTable("AspNetUsers");

            builder
                .Property(u => u.Id)
                .HasColumnType("nvarchar(450)");

            builder
                .Property(u => u.AccessFailedCount)
                .HasColumnType("int");

            builder
                .Property(u => u.ConcurrencyStamp)
                .IsConcurrencyToken()
                .HasColumnType("nvarchar(max)");

            builder
                .Property(u => u.Email)
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(u => u.EmailConfirmed)
                .HasColumnType("bit");

            builder
                .Property(u => u.LockoutEnabled)
                .HasColumnType("bit");

            builder
                .Property(u => u.LockoutEnd)
                .HasColumnType("datetimeoffset");

            builder
                .Property(u => u.NormalizedEmail)
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder
                .Property(u => u.NormalizedUserName)
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder
                .Property(u => u.PasswordHash)
                .HasColumnType("nvarchar(max)");

            builder
                .Property(u => u.PhoneNumber)
                .HasColumnType("nvarchar(max)");

            builder
                .Property(u => u.PhoneNumberConfirmed)
                .HasColumnType("bit");

            builder
                .Property(u => u.SecurityStamp)
                .HasColumnType("nvarchar(max)");

            builder
                .Property(u => u.TwoFactorEnabled)
                .HasColumnType("bit");

            builder
                .Property(u => u.UserName)
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder
                .HasKey("Id");

            builder
                .HasIndex("NormalizedEmail")
                .HasName("EmailIndex");

            builder
                .HasIndex("NormalizedUserName")
                .IsUnique()
                .HasName("UserNameIndex")
                .HasFilter("[NormalizedUserName] IS NOT NULL");
        }
    }
}