using Microsoft.EntityFrameworkCore;
using _05_Model.Models;

namespace _05_Model.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FullName = "Nguyen Van A",
                    Gender = "Male",
                    Phone = "0901234567",
                    Email = "vana@example.com",
                    Salary = 1200.50m,
                    Status = "Active"
                },
                new Employee
                {
                    Id = 2,
                    FullName = "Tran Thi B",
                    Gender = "Female",
                    Phone = "0912345678",
                    Email = "thib@example.com",
                    Salary = 1500.00m,
                    Status = "Inactive"
                },
                new Employee
                {
                    Id = 3,
                    FullName = "Le Van C",
                    Gender = "Male",
                    Phone = "0987654321",
                    Email = "vanc@example.com",
                    Salary = 1800.75m,
                    Status = "Active"
                }
            );
        }
    }
}
