using Empoyee.Model;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Employees.Dtos
{
    public class EmployeeCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [AllowNull ]
        public int? ManagerId { get; set; }
    }
}
