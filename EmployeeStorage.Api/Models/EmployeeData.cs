using EmployeeStorage.Api.Extensions;
using EmployeeStorage.DataAccess.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeStorage.Api.Models
{
    public class EmployeeData
    {

        [Required]
        public string FirstName
        {
            get => Employee.FirstName; set => Employee.FirstName = value;
        }

        [Required]
        public string LastName
        {
            get => Employee.LastName; set => Employee.LastName = value;
        }

        [Required]
        public decimal Salary
        {
            get => Employee.Salary; set => Employee.Salary = value;
        }

        [Required]
        public string HiringDate
        {
            get => Employee.HiringDate.ToString(dateFormat);

            set
            {
                value.ToDate(new[] { dateFormat }, out DateTime dateHiring);
                Employee.HiringDate = dateHiring;
            }
        }

        public string TerminationDate
        {
            get => Employee.TerminationDate.HasValue ? Employee.TerminationDate.Value.ToString(dateFormat) : null;
            
            set
            {
                bool result = value.ToDate(new[] { dateFormat }, out DateTime dateTerminate);
                Employee.TerminationDate = result ? (DateTime?)dateTerminate : null;
            }
        }

        [Required]
        public int PositionId
        {
            get => Employee.PositionId; set => Employee.PositionId = value;
        }

        private readonly string dateFormat = "dd/MM/yyyy";

        public Employee Employee { get; set; } = new Employee();
    }
}

