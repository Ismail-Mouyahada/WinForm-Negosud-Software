using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeosudAPI.Models;
using NeosudAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace NeosudAPI.Controllers;
 
   
    [ApiController]
    [Route("api/[controller]")]
    
    public class BottleController : ControllerBase
    {
        public BottleController()
        { }

        [HttpGet]
        public ActionResult<List<Bottle>> GetBottles() => BottleService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Bottle> Get(int id)
        {
            var Bottle = BottleService.Get(id);

            if (Bottle == null)
                return NotFound();

            return Bottle;
        }

        [HttpPost]
        public IActionResult Create(Bottle Bottle)
        {
            BottleService.Add(Bottle);
            return CreatedAtAction(nameof(Get), new { id = Bottle.BottleId }, Bottle);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Bottle Bottle)
        {
            if (id != Bottle.BottleId)
                return BadRequest();

            var existingBottle = BottleService.Get(id);
            if (existingBottle is null)
                return NotFound();

            BottleService.Update(Bottle);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Bottle = BottleService.Get(id);

            if (Bottle is null)
                return NotFound();

            BottleService.Delete(id);

            return NoContent();
        }

    }
 