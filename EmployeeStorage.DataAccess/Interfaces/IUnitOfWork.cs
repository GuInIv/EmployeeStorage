using EmployeeStorage.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeStorage.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Employee> Employees { get; }
        IRepository<Position> Positions { get; }
        void Save();

    }
}
