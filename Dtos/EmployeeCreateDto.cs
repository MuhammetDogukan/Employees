using Empoyee.Model;
using System.ComponentModel.DataAnnotations;

namespace Empoyees.Dtos
{
    public class EmployeeCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [StringLength(11)]
        public string Manager { get; set; }
    }
}
