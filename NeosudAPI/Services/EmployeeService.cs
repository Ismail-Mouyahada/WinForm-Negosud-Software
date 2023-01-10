using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeosudAPI.Models;

namespace NeosudAPI.Services;
public static class EmployeeService
{

    static List<Employee> Employees { get; set; }
    static int nextId = 0;
    static EmployeeService()
    {
        Employees = new List<Employee>
        {
            new Employee {EmployeeId = 1 },
            new Employee {EmployeeId = 2 },

        };
    }
    public static List<Employee> GetAll() => Employees;
    public static Employee? Get(int id) => Employees.FirstOrDefault(s => s.EmployeeId == id);
    public static void Add(Employee Employee)
    {
        Employee.EmployeeId = nextId++;

        Employees.Add(Employee);
    }
    public static void Delete(int id)
    {

        var Employee = Get(id);
        if (Employee is null)
            return;

        Employees.Remove(Employee);

    }

    public static void Update(Employee Employee)
    {
        var Index = Employees.FindIndex(s => s.EmployeeId == Employee.EmployeeId);
        if (Index == -1)
            return;

        Employees[Index] = Employee;
    }
}