using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeosudAPI.Services;
using NeosudAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace NeosudAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CityController : ControllerBase
{
    public CityController()
    { }

    [HttpGet]
    public ActionResult<List<City>> GetCitys() => CityService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<City> Get(int id)
    {
        var City = CityService.Get(id);

        if (City == null)
            return NotFound();

        return City;
    }

    [HttpPost]
    public IActionResult Create(City City)
    {
        CityService.Add(City);
        return CreatedAtAction(nameof(Get), new { id = City.CityId }, City);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, City City)
    {
        if (id != City.CityId)
            return BadRequest();

        var existingCity = CityService.Get(id);
        if (existingCity is null)
            return NotFound();

        CityService.Update(City);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var City = CityService.Get(id);

        if (City is null)
            return NotFound();

        CityService.Delete(id);

        return NoContent();
    }

}
