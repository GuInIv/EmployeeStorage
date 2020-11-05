using EmployeeStorage.DataAccess.Entities;
using EmployeeStorage.DataAccess.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeStorage.DataAccess.Configuration
{
    public class PositionConfiguration : DbEntityConfiguration<Position>
    {
        public override void Configuration(EntityTypeBuilder<Position> modelBuilder)
        {
            modelBuilder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
        }
    }
}