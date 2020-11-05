using EmployeeStorage.DataAccess.Entities;
using System.Collections.Generic;

namespace EmployeeStorage.DataAccess.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        //IEnumerable<Employee> GetEmployees();
    }
}
