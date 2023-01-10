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
public class CategoryController : ControllerBase
{
    public CategoryController()
    { }

    [HttpGet]
    public ActionResult<List<Category>> GetCategorys() => CategoryService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Category> Get(int id)
    {
        var Category = CategoryService.Get(id);

        if (Category == null)
            return NotFound();

        return Category;
    }

    [HttpPost]
    public IActionResult Create(Category Category)
    {
        CategoryService.Add(Category);
        return CreatedAtAction(nameof(Get), new { id = Category.CategoryId }, Category);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Category Category)
    {
        if (id != Category.CategoryId)
            return BadRequest();

        var existingCategory = CategoryService.Get(id);
        if (existingCategory is null)
            return NotFound();

        CategoryService.Update(Category);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Category = CategoryService.Get(id);

        if (Category is null)
            return NotFound();

        CategoryService.Delete(id);

        return NoContent();
    }

}
