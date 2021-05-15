using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MasterChef.Infrastructure.Data.EntityConfigurations.Identity
{
    public class RoleClaimConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<string>>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> builder)
        {
            builder
                .ToTable("AspNetRoleClaims");

            builder
                .Property(rc => rc.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder
                .Property(rc => rc.ClaimType)
                .HasColumnType("nvarchar(max)");

            builder
                .Property(rc => rc.ClaimValue)
                .HasColumnType("nvarchar(max)");

            builder
                .Property(rc => rc.RoleId)
                .IsRequired()
                .HasColumnType("nvarchar(450)");

            builder
                .HasKey(rc => rc.Id);

            builder
                .HasIndex(rc => rc.RoleId);

            builder
                .HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                .WithMany()
                .HasForeignKey("RoleId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}