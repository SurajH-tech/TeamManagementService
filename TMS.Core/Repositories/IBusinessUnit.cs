using TMS.Core.Requests;
using TMS.Core.Responses;
using TMS.Utilities;

namespace TMS.Core.Repositories
{
    // Interface for BusinessUnit Operations.
    public interface IBusinessUnit
    {
        Task<CommandResult<AddBusinessUnitCoreResponse>> AddBusinessUnitAsync(AddBusinessUnitCoreRequest addBusinessUnitRequest);

        Task<CommandResult<UpdateBusinessUnitCoreResponse>> UpdateBusinessUnitAsync(UpdateBusinessUnitCoreRequest updateBusinessUnitRequest);

    }
}
