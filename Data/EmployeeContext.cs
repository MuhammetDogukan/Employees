using Empoyee.Model;
using Microsoft.EntityFrameworkCore;

namespace Empoyees.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }
        
        public DbSet<Employee> Employees { get; set; }
    }
}
