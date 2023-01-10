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
public class CustomerOrderItemController : ControllerBase
{
    public CustomerOrderItemController()
    { }

    [HttpGet]
    public ActionResult<List<CustomerOrderItem>> GetCustomerOrderItems() => CustomerOrderItemService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<CustomerOrderItem> Get(int id)
    {
        var CustomerOrderItem = CustomerOrderItemService.Get(id);

        if (CustomerOrderItem == null)
            return NotFound();

        return CustomerOrderItem;
    }

    [HttpPost]
    public IActionResult Create(CustomerOrderItem CustomerOrderItem)
    {
        CustomerOrderItemService.Add(CustomerOrderItem);
        return CreatedAtAction(nameof(Get), new { id = CustomerOrderItem.CustomerOrderItemId }, CustomerOrderItem);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, CustomerOrderItem CustomerOrderItem)
    {
        if (id != CustomerOrderItem.CustomerOrderItemId)
            return BadRequest();

        var existingCustomerOrderItem = CustomerOrderItemService.Get(id);
        if (existingCustomerOrderItem is null)
            return NotFound();

        CustomerOrderItemService.Update(CustomerOrderItem);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var CustomerOrderItem = CustomerOrderItemService.Get(id);

        if (CustomerOrderItem is null)
            return NotFound();

        CustomerOrderItemService.Delete(id);

        return NoContent();
    }

}
