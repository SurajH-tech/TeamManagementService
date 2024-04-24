using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Entities
{
    // BusinessUnitMember Entity

    public class BusinessUnitMember
    {
        [Key]
        public int BUM_Id { get; set; }

        [ForeignKey("BusinessUnit")]
        public int BU_Id { get; set; }

        public BusinessUnit BusinessUnit { get; set; }

        
        [ForeignKey("Employee")]
        [MaxLength(500)]
        public string EmployeeLoginId { get; set; }

        public Employee Employee { get; set; }

        [DefaultValue(false)]
        public bool IsManager { get; set; }

    }
}
