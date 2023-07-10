using Empoyee.Model;
using System.ComponentModel.DataAnnotations;

namespace Empoyees.Dtos
{
    public class EmployeeReadDto
    {
        public string Id { get; set; }
        public string Surname { get; set; }
        public string Manager { get; set; }
    }
}
