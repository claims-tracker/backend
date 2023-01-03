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

        public DbSet<BaseEntityDTO> Entities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ModelsTraining
            var entitiesBuilder = modelBuilder.
                Entity<BaseEntityDTO>().
                ToTable("ModelTraining");

            entitiesBuilder.
                Property(b => b.CreatedOn).
                HasDefaultValueSql("getdate()");
        }
    }
}
