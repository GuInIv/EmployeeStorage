using EmployeeStorage.DataAccess.Configuration;
using EmployeeStorage.DataAccess.Entities;
using EmployeeStorage.DataAccess.Interfaces;
using System;

namespace EmployeeStorage.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeStorageContext db;

        private IEmployeeRepository employeeRepository;

        private IPositionRepository positionRepository;

        public UnitOfWork(EmployeeStorageContext db)
        {
            this.db = db;
        }

        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(db);
                return employeeRepository;
            }
        }

        public IRepository<Position> Positions
        {
            get
            {
                if (positionRepository == null)
                    positionRepository = new PositionRepository(db);
                return positionRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
