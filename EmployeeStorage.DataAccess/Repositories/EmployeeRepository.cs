using EmployeeStorage.DataAccess.Configuration;
using EmployeeStorage.DataAccess.Entities;
using EmployeeStorage.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeStorage.DataAccess.Repositories
{
    internal class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeStorageContext context)
            : base(context)
        { }

        //public IEnumerable<Employee> GetEmployees()
        //{
        //    return Employees.Include(p => p.Position);
        //}
    }
}