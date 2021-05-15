using MasterChef.Infrastructure.Data.EntityConfigurations.API;
using MasterChef.Infrastructure.Data.EntityConfigurations.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MasterChef.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<IdentityRoleClaim<string>> RoleClaim { get; set; }
        public DbSet<IdentityRole> Role { get; set; }
        public DbSet<IdentityUserClaim<string>> UserClaim { get; set; }
        public DbSet<IdentityUser> User { get; set; }
        public DbSet<IdentityUserLogin<string>> UserLogin { get; set; }
        public DbSet<IdentityUserRole<string>> UserRole { get; set; }
        public DbSet<IdentityUserToken<string>> UserToken { get; set; }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Receita> Receita { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleClaimConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserLoginConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserTokenConfiguration());

            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new ReceitaConfiguration());
        }
    }
}