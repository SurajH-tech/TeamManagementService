using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Entities
{
    // BusinessUnitCategory Entity
    public class BusinessUnitCategory
    {
        [Key]
        public int BUC_Id { get; set; }

        [ForeignKey("BusinessUnit")]
        public int BU_Id { get; set; }

        public BusinessUnit BusinessUnit { get; set; }

        [MaxLength(50)]     
        public string ZurichLineOfBusiness { get; set; }
    }
}
