using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS.API.DTO;
using TMS.API.Validators;
using TMS.Application.Commands;
using TMS.Core.Requests;
using TMS.Utilities;

namespace TMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessUnitMemberController : ApiController
    {
        private readonly IMediator _mediator;

        public BusinessUnitMemberController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("Attach")]
        public async Task<IActionResult> AddBusinessUnitMember(AddBusinessUnitMemberRequestDTO addBusinessUnitMemberRequestDTO)
        {
            // Apply validations on AddBusinessUnitMemberRequestDTO request.
            var validationResult = new AddBusinessUnitMemberRequestValidator().Validate(addBusinessUnitMemberRequestDTO);

            // If validation failed then returns the Error Message else execute next code.
            if (!validationResult.IsValid)
            {
                return Ok(DtoHelper.CreateValidationErrorDto(validationResult));
            }

            // Here prepared the AddBusinessUnitMemberCoreRequest object and send it Handler to execute the action.
            var result = await _mediator.Send(new AddBusinessUnitMemberCommand(new Core.Requests.AddBusinessUnitMemberCoreRequest()
            {
                EmployeeLoginId = addBusinessUnitMemberRequestDTO.EmployeeLoginId,
                BU_Id = addBusinessUnitMemberRequestDTO.BU_Id,
                IsManager = addBusinessUnitMemberRequestDTO.IsManager,
            }));

            return Ok(result);
        }


        [HttpDelete("Detach")]
        public async Task<IActionResult> DeleteBusinessUnitMember(DeleteBusinessUnitMemberDTO deleteBusinessUnitMemberDTO)
        {
            // Apply validations on DeleteBusinessUnitMemberDTO request.
            var validationResult = new DeleteBusinessUnitMemberRequestValidator().Validate(deleteBusinessUnitMemberDTO);

            // If validation failed then returns the Error Message else execute next code.
            if (!validationResult.IsValid)
            {
                return Ok(DtoHelper.CreateValidationErrorDto(validationResult));
            }

            // Here prepared the AddBusinessUnitMemberCoreRequest object and send it to Handler for execute the action.
            var result = await _mediator.Send(new DeleteBusinessUnitMemberCommand(new Core.Requests.DeleteBusinessUnitMemberCoreRequest()
            {
                EmployeeLoginId = deleteBusinessUnitMemberDTO.EmployeeLoginId,
                BUM_Id = deleteBusinessUnitMemberDTO.BUM_Id,              
            }));

            return Ok(result);
        }
    }
}
