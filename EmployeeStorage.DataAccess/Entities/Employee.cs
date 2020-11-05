﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeStorage.DataAccess.Entities
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public DateTime HiringDate { get; set; }

        public DateTime? TerminationDate { get; set; }
        
        [Required]
        public int PositionId { get; set; }
    }
}
