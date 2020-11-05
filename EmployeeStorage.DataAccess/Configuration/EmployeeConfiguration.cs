using Microsoft.EntityFrameworkCore;
using EmployeeStorage.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmployeeStorage.DataAccess.Extensions;

namespace EmployeeStorage.DataAccess.Configuration
{
    public class EmployeeConfiguration : DbEntityConfiguration<Employee>
    {
        public override void Configuration(EntityTypeBuilder<Employee> modelBuilder)
        {
            modelBuilder.Property(r => r.Salary)
           .HasColumnType("decimal(5,2)");

            //modelBuilder.HasOne(d => d.Position)
            //        .WithMany(p => p.Employees)
            //        .HasForeignKey(d => d.PositionId)
            //        .OnDelete(DeleteBehavior.NoAction);
        }
    }
}