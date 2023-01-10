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
public class CustomerOrderController : ControllerBase
{
    public CustomerOrderController()
    { }

    [HttpGet]
    public ActionResult<List<CustomerOrder>> GetCustomerOrders() => CustomerOrderService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<CustomerOrder> Get(int id)
    {
        var CustomerOrder = CustomerOrderService.Get(id);

        if (CustomerOrder == null)
            return NotFound();

        return CustomerOrder;
    }

    [HttpPost]
    public IActionResult Create(CustomerOrder CustomerOrder)
    {
        CustomerOrderService.Add(CustomerOrder);
        return CreatedAtAction(nameof(Get), new { id = CustomerOrder.CustomerOrderId }, CustomerOrder);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, CustomerOrder CustomerOrder)
    {
        if (id != CustomerOrder.CustomerOrderId)
            return BadRequest();

        var existingCustomerOrder = CustomerOrderService.Get(id);
        if (existingCustomerOrder is null)
            return NotFound();

        CustomerOrderService.Update(CustomerOrder);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var CustomerOrder = CustomerOrderService.Get(id);

        if (CustomerOrder is null)
            return NotFound();

        CustomerOrderService.Delete(id);

        return NoContent();
    }

}
