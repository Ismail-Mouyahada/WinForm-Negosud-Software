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
public class InvoiceController : ControllerBase
{
    public InvoiceController()
    { }

    [HttpGet]
    public ActionResult<List<Invoice>> GetInvoices() => InvoiceService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Invoice> Get(int id)
    {
        var Invoice = InvoiceService.Get(id);

        if (Invoice == null)
            return NotFound();

        return Invoice;
    }

    [HttpPost]
    public IActionResult Create(Invoice Invoice)
    {
        InvoiceService.Add(Invoice);
        return CreatedAtAction(nameof(Get), new { id = Invoice.InvoiceId }, Invoice);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Invoice Invoice)
    {
        if (id != Invoice.InvoiceId)
            return BadRequest();

        var existingInvoice = InvoiceService.Get(id);
        if (existingInvoice is null)
            return NotFound();

        InvoiceService.Update(Invoice);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Invoice = InvoiceService.Get(id);

        if (Invoice is null)
            return NotFound();

        InvoiceService.Delete(id);

        return NoContent();
    }

}
