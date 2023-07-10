using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Empoyee.Model;
using Empoyees.Data;
using Empoyees.Dtos;
using AutoMapper;

namespace Empoyees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeContext _context;
        public EmployeesController(EmployeeContext context, IMapper mapper)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            var rootEmployees = employees.Where(e => e.Manager == null).ToList();
            var result = new List<object>();

            foreach (var rootEmployee in rootEmployees)
            {
                var employeeWithSubordinates = GetEmployeeWithSubordinates(rootEmployee, employees);
                result.Add(employeeWithSubordinates);
            }

            return Ok(result);
        }

        // GET: api/Employees/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(string id)
        {
            var rootEmployee = await _context.Employees.FindAsync(id);
            if (rootEmployee == null)
                return NotFound();

            var employees = await _context.Employees.ToListAsync();
            var result = GetEmployeeWithSubordinates(rootEmployee, employees);

            return Ok(result);
        }

        // PUT: api/Employees/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(string id, Employee employee)
        {

            if (id != employee.Id)
            {
                return BadRequest();
            }

            if (employee.Manager != null)
            {
                var manager = await _context.Employees.FindAsync(employee.Manager);
                if (manager == null)
                    return NotFound("The specified manager couldn't be found.");
            }
            
            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Employees.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(EmployeeCreateDto employeeCreateDto)
        {
            Employee employee = new()
            {
                Id = Guid.NewGuid().ToString("N").Substring(0, 11),
                Name = employeeCreateDto.Name,
                Surname = employeeCreateDto.Surname,
                Manager = employeeCreateDto.Manager,
            };

            if (employee.Manager != null)
            {
                var manager =await _context.Employees.FindAsync(employee.Manager);
                if (manager == null)
                    return NotFound("The specified manager couldn't be found.");
            }

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            
            var employee = await _context.Employees.FindAsync(id);

            
            if (employee == null)
            {
                return NotFound();
            }

            //herhangi bir çalışanların yöneticisi ise onlara null atar
            /*
            var employees = await _context.Employees.ToListAsync();
            var managerOf = employees.Where(e => e.Manager == employee.Id).ToList(); 
            foreach (var item in managerOf)
            {
                item.Manager = null;
                _context.Entry(item).State = EntityState.Modified;
            }
            */

            //herhangi bir çalışanların yöneticisi ise onlara kendi yöneticisini atar
            /*
            var employees = await _context.Employees.ToListAsync();
            var managerOf = employees.Where(e => e.Manager == employee.Id).ToList(); 
            foreach (var item in managerOf)
            {
                item.Manager = employee.Manager;
                _context.Entry(item).State = EntityState.Modified;
            }
            */

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private object GetEmployeeWithSubordinates(Employee employee, List<Employee> allEmployees)
        {
            var result = new
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                Subordinates = allEmployees
            .Where(e => e.Manager == employee.Id)
            .Select(e => GetEmployeeWithSubordinates(e, allEmployees))
            };

            return result;
        }
    }

}
