
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empoyee.Model
{
    public class Employee
    {

        [Required]
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        [ForeignKey("Manager")]
        public int? ManagerId { get; set; }

        public virtual Employee Manager { get; set; }

        public ICollection<Employee> Subordinates { get; set; }
    }
}
