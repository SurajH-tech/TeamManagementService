using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Requests
{
    //Core Request for Update BusinessUnit Details.
    public class UpdateBusinessUnitCoreRequest
    {
        public int BU_Id { get; set; }
        public string BU_Name { get; set; }
        public string BU_Description { get; set; }
        public bool Active { get; set; }
        public string BU_Type { get; set; }

        public List<UpdateBusinessCategoryCoreRequest> BusinessCategories { get; set; }

        //public List<UpdateEmployeCoreRequest> Employees { get; set; }
    }

    public class UpdateBusinessCategoryCoreRequest
    {             
        public string ZurichLineOfBusiness { get; set; }
    }
}
