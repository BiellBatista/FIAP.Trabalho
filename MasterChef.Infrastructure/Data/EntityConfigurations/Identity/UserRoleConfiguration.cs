using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MasterChef.Infrastructure.Data.EntityConfigurations.Identity
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder
                .ToTable("AspNetUserRoles");

            builder
                .Property(ur => ur.UserId)
                .HasColumnType("nvarchar(450)");

            builder
                .Property(ur => ur.RoleId)
                .HasColumnType("nvarchar(450)");

            builder
                .HasKey("UserId", "RoleId");

            builder
                .HasIndex("RoleId");

            builder
                .HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                .WithMany()
                .HasForeignKey("RoleId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder
                .HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}