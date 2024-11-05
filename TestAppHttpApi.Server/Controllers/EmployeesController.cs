using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAppHttpApi.Server;
using TestAppHttpApi.Server.Data;

namespace TestAppHttpApi.Server.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly TestAppHttpApiServerContext _context;

        public EmployeesController(TestAppHttpApiServerContext context)
        {
            _context = context;
        }

        [ActionName("employees")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await _context.Employee.ToListAsync();
        }

        [ActionName("employee")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int? id)
        {
            var employee = await _context.Employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [ActionName("fire")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int? id, Employee employee)
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
                if (!EmployeeExists(id))
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

        [ActionName("hire")]
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        [ActionName("delete")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int? id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int? id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
