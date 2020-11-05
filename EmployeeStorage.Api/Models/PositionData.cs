using EmployeeStorage.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace EmployeeStorage.Api.Models
{
    public class PositionData
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Position Position => new Position
        {
            Name = Name
        };
    }
}
