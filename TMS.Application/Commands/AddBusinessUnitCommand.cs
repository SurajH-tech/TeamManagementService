using MediatR;
using TMS.Application.Responses;
using TMS.Core.Requests;
using TMS.Utilities;

namespace TMS.Application.Commands
{
    public class AddBusinessUnitCommand: IRequest<CommandResultDto<AddBusinessUnitResponse>>
    {
        public AddBusinessUnitCoreRequest addBusinessUnitRequest;

        public AddBusinessUnitCommand(AddBusinessUnitCoreRequest addBusinessUnitRequest)
        {
            this.addBusinessUnitRequest = addBusinessUnitRequest;
        }
    }
}
