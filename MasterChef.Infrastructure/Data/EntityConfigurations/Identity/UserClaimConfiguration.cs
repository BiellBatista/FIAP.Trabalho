using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MasterChef.Infrastructure.Data.EntityConfigurations.Identity
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            builder
                .ToTable("AspNetUserClaims");

            builder
                .Property(uc => uc.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Property(uc => uc.ClaimType)
                .HasColumnType("nvarchar(max)");

            builder
                .Property(uc => uc.ClaimValue)
                .HasColumnType("nvarchar(max)");

            builder
                .Property(uc => uc.UserId)
                .IsRequired()
                .HasColumnType("nvarchar(450)");

            builder
                .HasKey("Id");

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