using System;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using System.Linq;

namespace GoldFish.Web.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Network> Networks { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }

        //public override int SaveChanges()
        //{
        //    var entities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

        //    foreach (var entity in entities)
        //    {
        //        switch (entity.State)
        //        {
        //            case EntityState.Added:
        //                entity.Property("CreatedDate").CurrentValue = DateTime.UtcNow;
        //                break;
        //            case EntityState.Modified:
        //                entity.Property("ModifiedDate").CurrentValue = DateTime.UtcNow;
        //                break;
        //        }

        //    }
        //    return base.SaveChanges();
        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserGroup>()
                .HasKey(x => new { x.UserId, x.GroupId });
        }
    }
}
