using Microsoft.EntityFrameworkCore;
using BulkyWebRazor_Temp.Model;

namespace BulkyWebRazor_Temp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) // from ef migration builder
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Stationary", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Electronics", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 });
        }
    }
}

