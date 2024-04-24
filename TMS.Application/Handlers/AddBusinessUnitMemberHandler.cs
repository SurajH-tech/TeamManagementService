using AutoMapper;
using MediatR;
using TMS.Application.Commands;
using TMS.Application.Responses;
using TMS.Core.Repositories;
using TMS.Core.Responses;
using TMS.Utilities;

namespace TMS.Application.Handlers
{
    public class AddBusinessUnitMemberHandler: IRequestHandler<AddBusinessUnitMemberCommand, CommandResultDto<AddBusinessUnitMemberResponse>>
    {
        private readonly IBusinessUnitMember businessUnitMember;
        private readonly IMapper mapper;

        public AddBusinessUnitMemberHandler(IBusinessUnitMember businessUnitMember, IMapper mapper)
        {
            this.businessUnitMember = businessUnitMember;
            this.mapper = mapper;
        }
        public async Task<CommandResultDto<AddBusinessUnitMemberResponse>> Handle(AddBusinessUnitMemberCommand request, CancellationToken cancellationToken)
        {
            var addBusinessUnitResult = await businessUnitMember.AddBusineeUnitMemberAsync(request.addBusinessUnitMemberRequest);

            return mapper.Map<CommandResultDto<AddBusinessUnitMemberResponse>>(addBusinessUnitResult);

        }
    }
}
