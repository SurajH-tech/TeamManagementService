using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Entities
{
    // BusinessUnit Entity
    public class BusinessUnit
    {
        [Key]
        public int BU_Id { get; set; }

        [MaxLength(50)]       
        public string BU_Name { get; set; }

        [MaxLength(500)]      
        public string BU_Description { get; set; }

        [DefaultValue(false)]
        public bool Active { get; set; }

        [MaxLength(4)]
        public string BU_Type { get; set; }

        public List<BusinessUnitCategory> BusinessUnitCategories { get; set; }

        public List<BusinessUnitMember> BusinessUnitMembers { get; set; }

        public List<Employee> Employees { get; set; }

    }
}
