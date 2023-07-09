
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Empoyee.Model
{
    public class Employee
    {
        [StringLength(11)]
        [Required]
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public List<Employee> Subordinate { get; set; }
        [StringLength(11)]
        public string Manager { get; set; }
    }
}
