using MediatR;
using TMS.Application.Responses;
using TMS.Core.Requests;
using TMS.Utilities;

namespace TMS.Application.Commands
{
    public class UpdateBusinessUnitCommand: IRequest<CommandResultDto<UpdateBusinessUnitResponse>>
    {
        public UpdateBusinessUnitCoreRequest updateBusinessUnitRequest;

        public UpdateBusinessUnitCommand(UpdateBusinessUnitCoreRequest updateBusinessUnitRequest)
        {
            this.updateBusinessUnitRequest = updateBusinessUnitRequest;
        }
    }
}
