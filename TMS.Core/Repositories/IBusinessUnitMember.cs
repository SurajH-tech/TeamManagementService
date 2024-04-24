using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Requests;
using TMS.Core.Responses;
using TMS.Utilities;

namespace TMS.Core.Repositories
{
    // Interface for BusinessUnitMember Operations.
    public interface IBusinessUnitMember
    {
        Task<CommandResult<AddBusinessUnitMemberCoreResponse>> AddBusineeUnitMemberAsync(AddBusinessUnitMemberCoreRequest addBusinessUnitMemberCoreRequest);

        Task<CommandResult<DeleteBusinessUnitMemberCoreResponse>> DeleteBusinessUnitMemberAsync(DeleteBusinessUnitMemberCoreRequest deleteBusinessUnitMemberCoreRequest);

    }
}
    