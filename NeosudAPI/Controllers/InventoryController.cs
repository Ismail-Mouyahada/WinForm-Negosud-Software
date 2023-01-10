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
public class InventoryController : ControllerBase
{
    public InventoryController()
    { }

    [HttpGet]
    public ActionResult<List<Inventory>> GetInventorys() => Inventorieservice.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Inventory> Get(int id)
    {
        var Inventory = Inventorieservice.Get(id);

        if (Inventory == null)
            return NotFound();

        return Inventory;
    }

    [HttpPost]
    public IActionResult Create(Inventory Inventory)
    {
        Inventorieservice.Add(Inventory);
        return CreatedAtAction(nameof(Get), new { id = Inventory.InventoryId }, Inventory);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Inventory Inventory)
    {
        if (id != Inventory.InventoryId)
            return BadRequest();

        var existingInventory = Inventorieservice.Get(id);
        if (existingInventory is null)
            return NotFound();

        Inventorieservice.Update(Inventory);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Inventory = Inventorieservice.Get(id);

        if (Inventory is null)
            return NotFound();

        Inventorieservice.Delete(id);

        return NoContent();
    }

}
