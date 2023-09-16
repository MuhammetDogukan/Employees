using Empoyee.Model;
using System.ComponentModel.DataAnnotations;

namespace Employees.Dtos
{
    public class EmployeeReadDto
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public int? ManagerId { get; set; }
    }
}
