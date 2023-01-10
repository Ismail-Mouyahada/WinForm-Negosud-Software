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
public class RegionController : ControllerBase
{


    public RegionController()
    { }

    [HttpGet]
    public ActionResult<List<Region>> GetRegions() => RegionService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Region> Get(int id)
    {
        var Region = RegionService.Get(id);

        if (Region == null)
            return NotFound();

        return Region;
    }

    [HttpPost]
    public IActionResult Create(Region Region)
    {
        RegionService.Add(Region);
        return CreatedAtAction(nameof(Get), new { id = Region.RegionId }, Region);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Region Region)
    {
        if (id != Region.RegionId)
            return BadRequest();

        var existingRegion = RegionService.Get(id);
        if (existingRegion is null)
            return NotFound();

        RegionService.Update(Region);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Region = RegionService.Get(id);

        if (Region is null)
            return NotFound();

        RegionService.Delete(id);

        return NoContent();
    }

}
