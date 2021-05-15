using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MasterChef.Infrastructure.Data.EntityConfigurations.Identity
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<IdentityUserToken<string>>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
        {
            builder
                .ToTable("AspNetUserTokens");

            builder
                .Property(ut => ut.UserId)
                .HasColumnType("nvarchar(450)");

            builder
                .Property(ut => ut.LoginProvider)
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128);

            builder
                .Property(ut => ut.Name)
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128);

            builder
                .Property(ut => ut.Value)
                .HasColumnType("nvarchar(max)");

            builder
                .HasKey("UserId", "LoginProvider", "Name");

            builder
                .HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}