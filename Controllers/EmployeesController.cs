﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Empoyee.Model;
using Empoyees.Data;

namespace Empoyees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeesController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();

            var rootEmployees = employees.Where(e => e.Manager == null);

            var result = rootEmployees.Select(e => GetEmployeeWithSubordinates(e));

            return Ok(result);
        }

        // GET: api/Employees/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(string id)
        {
            var employee = await _context.Employees
                .Include(e => e.Subordinate)
                .Include(e => e.Manager)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
                return NotFound();

            var result = GetEmployeeWithSubordinates(employee);

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
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            if (employee.Manager != null)
            {
                var manager = await _context.Employees.FindAsync(employee.Manager);
                if (manager == null)
                    return NotFound("The specified manager couldn't be found.");

                manager.Subordinate.Add(employee);
                await _context.SaveChangesAsync();

            }
            if (employee.Subordinate != null)
            {
                var subordinate = await _context.Employees.FindAsync(employee.Subordinate);
                if (subordinate == null)
                    return NotFound("The specified subotinate couldn't be found.");
                if (subordinate.Manager!=null)
                    return NotFound("the specified subotinate already has a manager.");

                subordinate.Manager =employee.Id;

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
            //herhangi bir yöneticinin sorumlu olduğu kısımdaysa ordan çıkarmak için
            var subordinatOf= await _context.Employees.SingleOrDefaultAsync(e => e.Manager == employee.Id);
            if (subordinatOf != null)
            {
                subordinatOf.Subordinate.Remove(employee);
                await _context.SaveChangesAsync();
            }
            //Silinen çalışanın sorumlu olduğu kişileri yöneticisine atamak için
            /*    
            var manager = await _context.Employees.FindAsync(employee.Manager);
            foreach (var item in employee.Subordinate)
            {
                manager.Subordinate.Add(item);
            }
            */
            

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private object GetEmployeeWithSubordinates(Employee employee)
        {
            var result = new
            {
                employee.Id,
                employee.Name,
                employee.Surname,
                Subordinates = employee.Subordinate.Select(e => GetEmployeeWithSubordinates(e))
            };

            return result;
        }
    }

}