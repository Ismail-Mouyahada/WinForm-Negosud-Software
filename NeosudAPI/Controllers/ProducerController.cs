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
public class ProducerController : ControllerBase
{
    
    public ProducerController()
    { }

    [HttpGet]
    public ActionResult<List<Producer>> GetProducers() => ProducerService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Producer> Get(int id)
    {
        var Producer = ProducerService.Get(id);

        if (Producer == null)
            return NotFound();

        return Producer;
    }

    [HttpPost]
    public IActionResult Create(Producer Producer)
    {
        ProducerService.Add(Producer);
        return CreatedAtAction(nameof(Get), new { id = Producer.ProducerId }, Producer);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Producer Producer)
    {
        if (id != Producer.ProducerId)
            return BadRequest();

        var existingProducer = ProducerService.Get(id);
        if (existingProducer is null)
            return NotFound();

        ProducerService.Update(Producer);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Producer = ProducerService.Get(id);

        if (Producer is null)
            return NotFound();

        ProducerService.Delete(id);

        return NoContent();
    }

}
