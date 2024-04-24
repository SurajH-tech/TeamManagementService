using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Entities
{

    // UTEmployee Entity for User Defiled Data Type.
    public class UTEmployee
    {
        public string EmployeeLoginId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public string EmailAddress { get; set; }
        public bool IsManager { get; set; }
    }
}
