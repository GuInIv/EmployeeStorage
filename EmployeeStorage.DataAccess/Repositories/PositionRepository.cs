using EmployeeStorage.DataAccess.Configuration;
using EmployeeStorage.DataAccess.Entities;
using EmployeeStorage.DataAccess.Interfaces;

namespace EmployeeStorage.DataAccess.Repositories
{
    internal class PositionRepository : Repository<Position>, IPositionRepository
    {
        public PositionRepository(EmployeeStorageContext context)
            : base(context)
        { }
    }
}