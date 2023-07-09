using Empoyee.Model;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace Empoyees.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Id)
                .HasDefaultValueSql("dbo.GenerateRandomId(11)")
                .ValueGeneratedOnAdd();
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
