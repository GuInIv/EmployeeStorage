using EmployeeStorage.DataAccess.Entities;
using EmployeeStorage.DataAccess.Interfaces;
using EmployeeStorage.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EmployeeStorage.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        IUnitOfWork DataBase { get; set; }

        public EmployeeService(IUnitOfWork uow)
        {
            this.DataBase = uow;
        }

        public void Create(Employee employee)
        {
            DataBase.Employees.Create(employee);
            Save();
        }

        public void Delete(int id)
        {
            DataBase.Employees.Delete(new Employee { Id = id });
            Save();
        }

        public void UpdateOrSave()
        {
            Save();
        }

        public IEnumerable<Employee> GetAll()
        {
            return DataBase.Employees.GetAll();
        }

        public Employee GetById(int id)
        {
            //return ((IEmployeeRepository)DataBase.Employees).GetEmployees().FirstOrDefault(e => e.Id == id);
            return DataBase.Employees.GetById(id);
        }

        public IEnumerable<Employee> GetMany()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            DataBase.Save();
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
