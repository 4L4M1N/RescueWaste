using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RescueWaste.API.Models;

namespace RescueWaste.API.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){ }
        public DbSet<Test> Tests {get; set;}
        public DbSet<AppUser> AppUsers {get; set;}
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<Merchant> Merchants { get; set;}
        public DbSet<PromocodePhoto> PromocodePhotos { get; set; }
        public DbSet<Coin> Coins { get; set; }
        


        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);

        //     foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        //     {
        //         var table = entityType.Relational().TableName;
        //         if (table.StartsWith("AspNet")) {
        //             entityType.Relational().TableName = table.Substring(6);
        //         }
        //     };
        // } 
        //Change default Table name
        protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);

                // Override default AspNet Identity table names
                builder.Entity<IdentityUser>(entity => { entity.ToTable(name: "Users"); });
                builder.Entity<IdentityRole>(entity => { entity.ToTable(name: "Roles"); });
                builder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UserRoles"); });
                builder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaims"); });
                builder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogins"); });
                builder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserTokens"); });
                builder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RoleClaims"); });
        }

    }
}