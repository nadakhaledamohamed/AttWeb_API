using AttWeb_API.Models;
using Microsoft.EntityFrameworkCore;

namespace AttWeb_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<StudentDetails> StudentDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDetails>().HasNoKey(); // For stored procedure mapping
            modelBuilder.Entity<StudentDetails>().HasNoKey();
        }
    }
}
