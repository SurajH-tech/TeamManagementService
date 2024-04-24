using AutoMapper;
using MediatR;
using TMS.Application.Commands;
using TMS.Application.Responses;
using TMS.Core.Repositories;
using TMS.Utilities;

namespace TMS.Application.Handlers
{
    public class UpdateBusinessUnitHandler : IRequestHandler<UpdateBusinessUnitCommand, CommandResultDto<UpdateBusinessUnitResponse>>
    {
        private readonly IBusinessUnit businessUnit;
        private readonly IMapper mapper;

        public UpdateBusinessUnitHandler(IBusinessUnit businessUnit, IMapper mapper)
        {
            this.businessUnit = businessUnit;
            this.mapper = mapper;
        }

        public async Task<CommandResultDto<UpdateBusinessUnitResponse>> Handle(UpdateBusinessUnitCommand request, CancellationToken cancellationToken)
        {
            var updateBusinessUnitResult = await businessUnit.UpdateBusinessUnitAsync(request.updateBusinessUnitRequest);

            return mapper.Map<CommandResultDto<UpdateBusinessUnitResponse>>(updateBusinessUnitResult);
        }
    }
}
