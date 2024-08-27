using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class StaffMember
    {
        public int StaffMemberID { get; set; } // Identifier

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Position { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }
    }
}