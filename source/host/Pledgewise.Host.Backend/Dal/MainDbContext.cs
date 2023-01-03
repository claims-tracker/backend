using Pledgewise.Common.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Pledgewise.Host.Backend.Dal
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {
        }

        public DbSet<EntityDTO> Entities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ModelsTraining
            var entitiesBuilder = modelBuilder.
                Entity<EntityDTO>().
                ToTable("Entity");

            entitiesBuilder.
                Property(b => b.CreatedOn).
                HasDefaultValueSql("getdate()");
        }
    }
}