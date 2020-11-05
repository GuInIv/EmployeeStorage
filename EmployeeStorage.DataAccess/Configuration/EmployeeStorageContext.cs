using EmployeeStorage.DataAccess.Entities;
using EmployeeStorage.DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EmployeeStorage.DataAccess.Configuration
{
    public class EmployeeStorageContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }        

        public EmployeeStorageContext(DbContextOptions<EmployeeStorageContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.AddConfiguration(new EmployeeConfiguration());
          //  modelBuilder.AddConfiguration(new PositionConfiguration());
        }

    }
}
