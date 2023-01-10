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
public class SupplierController : ControllerBase
{
    public SupplierController()
    { }

    [HttpGet]
    public ActionResult<List<Supplier>> GetSuppliers() => SupplierService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Supplier> Get(int id)
    {
        var Supplier = SupplierService.Get(id);

        if (Supplier == null)
            return NotFound();

        return Supplier;
    }

    [HttpPost]
    public IActionResult Create(Supplier Supplier)
    {
        SupplierService.Add(Supplier);
        return CreatedAtAction(nameof(Get), new { id = Supplier.SupplierId }, Supplier);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Supplier Supplier)
    {
        if (id != Supplier.SupplierId)
            return BadRequest();

        var existingSupplier = SupplierService.Get(id);
        if (existingSupplier is null)
            return NotFound();

        SupplierService.Update(Supplier);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Supplier = SupplierService.Get(id);

        if (Supplier is null)
            return NotFound();

        SupplierService.Delete(id);

        return NoContent();
    }

}
