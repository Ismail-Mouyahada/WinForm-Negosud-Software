using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeosudAPI.Models;

namespace NeosudAPI.Services;
public static class CategoryService
{

    static List<Category> Categorys { get; set; }
    static int nextId = 0;
    static CategoryService()
    {
        Categorys = new List<Category>
        {
            new Category {CategoryId = 1, CategoryName="Category1"},
            new Category {CategoryId = 2, CategoryName="Category2" },

        };
    }
    public static List<Category> GetAll() => Categorys;
    public static Category? Get(int id) => Categorys.FirstOrDefault(s => s.CategoryId == id);
    public static void Add(Category Category)
    {
        Category.CategoryId = nextId++;
        Category.CategoryName = "Category";

        Categorys.Add(Category);
    }
    public static void Delete(int id)
    {

        var Category = Get(id);
        if (Category is null)
            return;

        Categorys.Remove(Category);

    }

    public static void Update(Category Category)
    {
        var Index = Categorys.FindIndex(s => s.CategoryId == Category.CategoryId);
        if (Index == -1)
            return;

        Categorys[Index] = Category;
    }
}