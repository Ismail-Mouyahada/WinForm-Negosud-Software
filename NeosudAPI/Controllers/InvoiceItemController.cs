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
public class InvoiceItemController : ControllerBase
{
    public InvoiceItemController()
    { }

    [HttpGet]
    public ActionResult<List<InvoiceItem>> GetInvoiceItems() => InvoiceItemService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<InvoiceItem> Get(int id)
    {
        var InvoiceItem = InvoiceItemService.Get(id);

        if (InvoiceItem == null)
            return NotFound();

        return InvoiceItem;
    }

    [HttpPost]
    public IActionResult Create(InvoiceItem InvoiceItem)
    {
        InvoiceItemService.Add(InvoiceItem);
        return CreatedAtAction(nameof(Get), new { id = InvoiceItem.InvoiceItemId }, InvoiceItem);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, InvoiceItem InvoiceItem)
    {
        if (id != InvoiceItem.InvoiceItemId)
            return BadRequest();

        var existingInvoiceItem = InvoiceItemService.Get(id);
        if (existingInvoiceItem is null)
            return NotFound();

        InvoiceItemService.Update(InvoiceItem);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var InvoiceItem = InvoiceItemService.Get(id);

        if (InvoiceItem is null)
            return NotFound();

        InvoiceItemService.Delete(id);

        return NoContent();
    }

}
