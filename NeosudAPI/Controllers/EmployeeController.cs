using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeosudAPI.Models;
using NeosudAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace NeosudAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    public EmployeeController()
    { }

    [HttpGet]
    public ActionResult<List<Employee>> GetEmployees() => EmployeeService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Employee> Get(int id)
    {
        var Employee = EmployeeService.Get(id);

        if (Employee == null)
            return NotFound();

        return Employee;
    }

    [HttpPost]
    public IActionResult Create(Employee Employee)
    {
        EmployeeService.Add(Employee);
        return CreatedAtAction(nameof(Get), new { id = Employee.EmployeeId }, Employee);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Employee Employee)
    {
        if (id != Employee.EmployeeId)
            return BadRequest();

        var existingEmployee = EmployeeService.Get(id);
        if (existingEmployee is null)
            return NotFound();

        EmployeeService.Update(Employee);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Employee = EmployeeService.Get(id);

        if (Employee is null)
            return NotFound();

        EmployeeService.Delete(id);

        return NoContent();
    }

}
