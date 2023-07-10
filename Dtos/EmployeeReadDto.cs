using Empoyee.Model;
using System.ComponentModel.DataAnnotations;

namespace Employees.Dtos
{
    public class EmployeeReadDto
    {
        public string Id { get; set; }
        public string Surname { get; set; }
        public string Manager { get; set; }
    }
}
