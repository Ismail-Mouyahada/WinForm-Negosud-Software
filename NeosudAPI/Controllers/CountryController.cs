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
public class CountryController : ControllerBase
{
    public CountryController()
    { }

    [HttpGet]
    public ActionResult<List<Country>> GetCountrys() => CountryService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Country> Get(int id)
    {
        var Country = CountryService.Get(id);

        if (Country == null)
            return NotFound();

        return Country;
    }

    [HttpPost]
    public IActionResult Create(Country Country)
    {
        CountryService.Add(Country);
        return CreatedAtAction(nameof(Get), new { id = Country.CountryId }, Country);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Country Country)
    {
        if (id != Country.CountryId)
            return BadRequest();

        var existingCountry = CountryService.Get(id);
        if (existingCountry is null)
            return NotFound();

        CountryService.Update(Country);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Country = CountryService.Get(id);

        if (Country is null)
            return NotFound();

        CountryService.Delete(id);

        return NoContent();
    }

}
