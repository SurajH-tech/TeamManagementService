using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TMS.API.DTO;
using TMS.API.Validators;
using TMS.Application.Commands;
using TMS.Core.Requests;
using TMS.Utilities;

namespace TMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessUnitController : ApiController
    {

        private readonly IMediator _mediator;

        public BusinessUnitController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBusinessUnitAsync(AddBusinessUnitRequestDTO addBusinessUnitRequestDTO)
        {
            // Apply validations on AddBusinessUnitDTO request.
            var validationResult = new BusinessUnitRequestValidator().Validate(addBusinessUnitRequestDTO);            

            // If validation failed then returns the Error Message else execute next code.
            if (!validationResult.IsValid)
            {
                return Ok(DtoHelper.CreateValidationErrorDto(validationResult));
            }

            // Here Prepare the AddBusinessUnitCore request object and send to Application -> AddBusinessUnitCommand
            // & Execute AddBusinessUnitHandler -> AddBusinessUnitAsync() action. 
            var result = await _mediator.Send(new AddBusinessUnitCommand(new Core.Requests.AddBusinessUnitCoreRequest()
            {
                BU_Name = addBusinessUnitRequestDTO.BU_Name,
                BU_Description = addBusinessUnitRequestDTO.BU_Description,
                Active = addBusinessUnitRequestDTO.Active,
                BU_Type = addBusinessUnitRequestDTO.BU_Type,

                BusinessCategories = addBusinessUnitRequestDTO.BusinessCategories
                                            .Select(item => new AddBusinessCategoryCoreRequest
                                            {
                                                ZurichLineOfBusiness = item.ZurichLineOfBusiness
                                            })
                                            .ToList(),

                Employees = addBusinessUnitRequestDTO.Employees
                                            .Select(item => new AddEmployeeCoreRequest
                                            {
                                                EmployeeLoginId = item.EmployeeLoginId,
                                                FirstName = item.FirstName,
                                                LastName = item.LastName,
                                                Status = item.Status,
                                                EmailAddress = item.EmailAddress,
                                                IsManager = item.IsManager
                                            })
                                            .ToList(),              

            })) ;

            return Ok(result);
        }


        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateBusinessUnitAsync(int id, UpdateBusinessUnitRequestDTO updateBusinessUnitRequestDTO)
        {
            var validationResult = new UpdateBusinessUnitRequestValidator().Validate(updateBusinessUnitRequestDTO);

            if (!validationResult.IsValid)
            {
                return Ok(DtoHelper.CreateValidationErrorDto(validationResult));
            }

            // Here Prepare the UpdateBusinessUnitCore request object and send to Application -> UpdateBusinessUnitCommand
            // & Execute UpdateBusinessUnitHandler -> UpdateBusinessUnitAsync() action.
            var result = await _mediator.Send(new UpdateBusinessUnitCommand(new Core.Requests.UpdateBusinessUnitCoreRequest()
            {  
                BU_Id = id,
                BU_Name = updateBusinessUnitRequestDTO.BU_Name,
                BU_Description = updateBusinessUnitRequestDTO.BU_Description,
                Active = updateBusinessUnitRequestDTO.Active,
                BU_Type = updateBusinessUnitRequestDTO.BU_Type,

                BusinessCategories = updateBusinessUnitRequestDTO.BusinessCategories
                                            .Select(item => new UpdateBusinessCategoryCoreRequest
                                            {                                                                                           
                                                ZurichLineOfBusiness = item.ZurichLineOfBusiness
                                            })
                                            .ToList(),


                //Right Now for Update existing BusinessUnit Employee recordes are not considered - Need to work.

                //Employees = updateBusinessUnitRequestDTO.Employees
                //                            .Select(item => new UpdateEmployeCoreRequest
                //                            {
                //                                EmployeeLoginId = item.EmployeeLoginId,                                                
                //                                FirstName = item.FirstName,
                //                                LastName = item.LastName,
                //                                Status = item.Status,
                //                                EmailAddress = item.EmailAddress,                                                
                //                            })
                //                            .ToList(),

            }));

            return Ok(result);
        }


    }
}
