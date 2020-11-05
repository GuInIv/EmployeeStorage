using EmployeeStorage.DataAccess.Entities;
using System.Collections.Generic;

namespace EmployeeStorage.Service.Infrastructure
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        IEnumerable<Employee> GetMany();
        Employee GetById(int id);
        void Create(Employee employee);
        void UpdateOrSave();
        void Delete(int id);
        void Dispose();
    }
}
