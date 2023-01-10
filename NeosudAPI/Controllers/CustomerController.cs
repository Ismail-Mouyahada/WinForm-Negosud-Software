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
public class CustomerController : ControllerBase
{
    public CustomerController()
    { }

    [HttpGet]
    public ActionResult<List<Customer>> GetCustomers() => CustomerService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Customer> Get(int id)
    {
        var Customer = CustomerService.Get(id);

        if (Customer == null)
            return NotFound();

        return Customer;
    }

    [HttpPost]
    public IActionResult Create(Customer Customer)
    {
        CustomerService.Add(Customer);
        return CreatedAtAction(nameof(Get), new { id = Customer.CustomerId }, Customer);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Customer Customer)
    {
        if (id != Customer.CustomerId)
            return BadRequest();

        var existingCustomer = CustomerService.Get(id);
        if (existingCustomer is null)
            return NotFound();

        CustomerService.Update(Customer);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Customer = CustomerService.Get(id);

        if (Customer is null)
            return NotFound();

        CustomerService.Delete(id);

        return NoContent();
    }

}
