using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Requests
{
    //Core Request for Delete BusinessUnit Details
    public class DeleteBusinessUnitMemberCoreRequest
    {
        public int BUM_Id { get; set; }
        public string EmployeeLoginId { get; set; }
    }
}
