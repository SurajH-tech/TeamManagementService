using AutoMapper;
using MediatR;
using System;
using TMS.Application.Commands;
using TMS.Application.Responses;
using TMS.Core.Repositories;
using TMS.Utilities;

namespace TMS.Application.Handlers
{
    public class AddBusinessUnitHandler : IRequestHandler<AddBusinessUnitCommand, CommandResultDto<AddBusinessUnitResponse>>
    {
        private readonly IBusinessUnit businessUnit;
        private readonly IMapper mapper;

        public AddBusinessUnitHandler(IBusinessUnit businessUnit, IMapper mapper)
        {
            this.businessUnit = businessUnit;
            this.mapper = mapper;
        }
        public async Task<CommandResultDto<AddBusinessUnitResponse>> Handle(AddBusinessUnitCommand request, CancellationToken cancellationToken)
        {
            var addBusinessUnitResult = await businessUnit.AddBusinessUnitAsync(request.addBusinessUnitRequest);

            return mapper.Map<CommandResultDto<AddBusinessUnitResponse>>(addBusinessUnitResult);

        }
    }
}
