﻿using Empoyee.Model;
using System.ComponentModel.DataAnnotations;

namespace Employees.Dtos
{
    public class EmployeeUpdateDto
    {
        [Required]
        public int Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public List<Employee> Subordinate { get; set; }
        [StringLength(11)]
        public string Manager { get; set; }
    }
}

