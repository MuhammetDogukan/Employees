using Empoyee.Model;
using System.ComponentModel.DataAnnotations;

namespace Employees.Dtos
{
    public class EmployeeCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        
        public int Manager { get; set; }
    }
}
