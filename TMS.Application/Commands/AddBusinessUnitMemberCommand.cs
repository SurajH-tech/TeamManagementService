using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Application.Responses;
using TMS.Core.Requests;
using TMS.Utilities;

namespace TMS.Application.Commands
{
    public class AddBusinessUnitMemberCommand : IRequest<CommandResultDto<AddBusinessUnitMemberResponse>>
    {
        public AddBusinessUnitMemberCoreRequest addBusinessUnitMemberRequest;

        public AddBusinessUnitMemberCommand(AddBusinessUnitMemberCoreRequest addBusinessUnitMemberCoreRequest)
        {
            this.addBusinessUnitMemberRequest = addBusinessUnitMemberCoreRequest;
        }
    }
}
