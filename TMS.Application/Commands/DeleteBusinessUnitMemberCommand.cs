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
    public class DeleteBusinessUnitMemberCommand : IRequest<CommandResultDto<DeleteBusinessUnitMemberResponse>>
    {
        public DeleteBusinessUnitMemberCoreRequest deleteBusinessUnitMemberRequest;

        public DeleteBusinessUnitMemberCommand(DeleteBusinessUnitMemberCoreRequest deleteBusinessUnitMemberRequest)
        {
            this.deleteBusinessUnitMemberRequest = deleteBusinessUnitMemberRequest;
        }
    }
}
