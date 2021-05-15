using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MasterChef.Infrastructure.Data.EntityConfigurations.Identity
{
    public class UserLoginConfiguration : IEntityTypeConfiguration<IdentityUserLogin<string>>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
        {
            builder
                .ToTable("AspNetUserLogins");

            builder
                .Property(ul => ul.LoginProvider)
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128);

            builder
                .Property(ul => ul.ProviderKey)
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128);

            builder
                .Property<string>("ProviderDisplayName")
                .HasColumnType("nvarchar(max)");

            builder
                .Property<string>("UserId")
                .IsRequired()
                .HasColumnType("nvarchar(450)");

            builder
                .HasKey("LoginProvider", "ProviderKey");

            builder
                .HasIndex("UserId");

            builder
                .HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}