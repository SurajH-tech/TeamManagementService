using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Application.Commands;
using TMS.Application.Responses;
using TMS.Core.Entities;
using TMS.Core.Repositories;
using TMS.Utilities;

namespace TMS.Application.Handlers
{
    public class DeleteBusniessUnitMemberHandler : IRequestHandler<DeleteBusinessUnitMemberCommand, CommandResultDto<DeleteBusinessUnitMemberResponse>>
    {
        private readonly IBusinessUnitMember businessUnitMember;
        private readonly IMapper mapper;

        public DeleteBusniessUnitMemberHandler(IBusinessUnitMember businessUnitMember, IMapper mapper)
        {
            this.businessUnitMember = businessUnitMember;
            this.mapper = mapper;
        }

        public async Task<CommandResultDto<DeleteBusinessUnitMemberResponse>> Handle(DeleteBusinessUnitMemberCommand request, CancellationToken cancellationToken)
        {
            var deleteBusinessUnitResult = await businessUnitMember.DeleteBusinessUnitMemberAsync(request.deleteBusinessUnitMemberRequest);

            return mapper.Map<CommandResultDto<DeleteBusinessUnitMemberResponse>>(deleteBusinessUnitResult);

        }
    }
}
