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
public class StoreController : ControllerBase
{
    
    public StoreController()
    { }

    [HttpGet]
    public ActionResult<List<Store>> GetStores() => StoreService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Store> Get(int id)
    {
        var Store = StoreService.Get(id);

        if (Store == null)
            return NotFound();

        return Store;
    }

    [HttpPost]
    public IActionResult Create(Store Store)
    {
        StoreService.Add(Store);
        return CreatedAtAction(nameof(Get), new { id = Store.StoreId }, Store);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Store Store)
    {
        if (id != Store.StoreId)
            return BadRequest();

        var existingStore = StoreService.Get(id);
        if (existingStore is null)
            return NotFound();

        StoreService.Update(Store);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Store = StoreService.Get(id);

        if (Store is null)
            return NotFound();

        StoreService.Delete(id);

        return NoContent();
    }

}
