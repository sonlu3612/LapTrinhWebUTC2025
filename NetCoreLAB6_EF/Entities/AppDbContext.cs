using Microsoft.EntityFrameworkCore;
using NetCoreLAB6_EF.Models;

namespace NetCoreLAB6_EF.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Banner> Banners { get; set; }


        public DbSet<StdClass> StdClasses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Mark> Marks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite key for Marks
            modelBuilder.Entity<Mark>()
                .HasKey(m => new { m.SubjectId, m.StudentId });
        }
    }
}
