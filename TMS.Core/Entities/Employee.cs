using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Entities
{
    // Employee Entity
    public class Employee
    {
        [Key]
        [MaxLength(500)]
        public string Emp_LoginId { get; set; }

        [ForeignKey("BusineeUnit")]
        public int BU_Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(3)]
        public string Status { get; set; }

        [MaxLength(50)]
        public string EmailAddress { get; set; }
    }
}
