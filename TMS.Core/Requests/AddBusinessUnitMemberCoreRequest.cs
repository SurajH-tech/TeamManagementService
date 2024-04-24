using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Requests
{
    //Core Request for Add BusinessUnitMember Details
    public class AddBusinessUnitMemberCoreRequest
    {
        public string EmployeeLoginId { get; set; }
        public int BU_Id { get; set; }
        public bool IsManager { get; set; } = false;
    }
}
