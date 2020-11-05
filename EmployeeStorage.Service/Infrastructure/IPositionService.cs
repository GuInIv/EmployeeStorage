using EmployeeStorage.DataAccess.Entities;
using System.Collections.Generic;

namespace EmployeeStorage.Service.Infrastructure
{
    public interface IPositionService
    {
        IEnumerable<Position> GetAll();
        Position GetById(int id);
        void Create(Position position);
        void Update(Position position);
        void Delete(int id);
        void Dispose();
    }
}
