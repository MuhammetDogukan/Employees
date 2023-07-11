
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

        [ForeignKey(nameof(Employee))]
        public int Manager { get; set; }
    }
}
