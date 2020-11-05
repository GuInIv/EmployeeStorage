using EmployeeStorage.Api.Models;
using EmployeeStorage.DataAccess.Entities;
using EmployeeStorage.Service.Infrastructure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EmployeeStorage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        readonly IEmployeeService service;
        public EmployeesController(IEmployeeService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public Employee GetEmployee(int id)
        {
            return service.GetById(id);
        }

        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            return service.GetAll();
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeData employeeData)
        {
            //var errors = service.CanAddEmployee(employee).ToList();
            //ModelState.AddModelErrors(errors);
            if (ModelState.IsValid)
            {
                Employee employee = employeeData.Employee;
                service.Create(employee);
                return Ok(employee.Id);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] JsonPatchDocument<EmployeeData> patch)
        {
            if (ModelState.IsValid)
            {
                Employee employee = service.GetById(id);
                EmployeeData employeeData = new EmployeeData { Employee = employee };
                patch.ApplyTo(employeeData);

                service.UpdateOrSave();
                return Ok(employeeData);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public void DeleteEmployee(int id)
        {
            service.Delete(id);
        }
    }
}
