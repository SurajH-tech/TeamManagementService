using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TMS.Core.Entities;
using TMS.Core.Repositories;
using TMS.Core.Requests;
using TMS.Core.Responses;
using TMS.Infrastructure.Data;
using TMS.Utilities;

namespace TMS.Infrastructure.Repositories
{
    public class BusinessUnitMemberRepository: IBusinessUnitMember
    {
        private readonly TMSDbContext _dbContext;

        public BusinessUnitMemberRepository(TMSDbContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// Adds the new businee unit member.
        /// </summary>
        /// <param name="addBusinessUnitMemberCoreRequest">The request containing data to add new Business Unit Member Deatils</param>
        /// <returns></returns>      
        public async Task<CommandResult<AddBusinessUnitMemberCoreResponse>> AddBusineeUnitMemberAsync(AddBusinessUnitMemberCoreRequest addBusinessUnitMemberCoreRequest)
        {
            try
            {
                using (_dbContext)
                {
                    AddBusinessUnitMemberCoreResponse addBusinessUnitMemberCoreResponse = new AddBusinessUnitMemberCoreResponse();

                    // Check if an Employee already exists in Employee table.
                    var existingEmployee = _dbContext.Employees.FirstOrDefault(e => e.Emp_LoginId == addBusinessUnitMemberCoreRequest.EmployeeLoginId);

                    if (existingEmployee != null)
                    {
                        // Check if an Business Unit Member with the same name already exists
                        var existingBUMember = _dbContext.BusinessUnitMembers.FirstOrDefault(e => e.EmployeeLoginId == addBusinessUnitMemberCoreRequest.EmployeeLoginId);

                        if (existingBUMember == null)
                        {
                            // Create a new Business Unit Member instance
                            var newEmployee = new BusinessUnitMember
                            {
                                EmployeeLoginId = addBusinessUnitMemberCoreRequest.EmployeeLoginId,
                                BU_Id = addBusinessUnitMemberCoreRequest.BU_Id,
                                IsManager = addBusinessUnitMemberCoreRequest.IsManager
                            };

                            // Add the new employee to the Employees DbSet
                            _dbContext.BusinessUnitMembers.Add(newEmployee);

                            // Save changes to the database
                            _dbContext.SaveChanges();

                            addBusinessUnitMemberCoreResponse.isSuccess = true;

                            return CommandResult<AddBusinessUnitMemberCoreResponse>.CreateSuccess(addBusinessUnitMemberCoreResponse, StatusCodes.Status200OK);
                        }
                        else
                        {
                            return CommandResult<AddBusinessUnitMemberCoreResponse>.CreateError("Employee already assigned with other Business Unit.Please check with Administrator.", StatusCodes.Status409Conflict);
                        }
                    }
                    else 
                    {
                        return CommandResult<AddBusinessUnitMemberCoreResponse>.CreateError("Employee not exists in Business Unit.Please check with Administrator.", StatusCodes.Status400BadRequest);
                    }
                }
            }
            catch (Exception ex)
            {
                return CommandResult<AddBusinessUnitMemberCoreResponse>.CreateError(ex.Message, StatusCodes.Status500InternalServerError);
            }            
        }

        public async Task<CommandResult<DeleteBusinessUnitMemberCoreResponse>> DeleteBusinessUnitMemberAsync(DeleteBusinessUnitMemberCoreRequest deleteBusinessUnitMemberCoreRequest)
        {
            try
            {
                using (_dbContext)
                {
                    // Check if an Employee already exists in Employee table.
                    var existingEmployee = _dbContext.Employees.FirstOrDefault(e => e.Emp_LoginId == deleteBusinessUnitMemberCoreRequest.EmployeeLoginId);
                    DeleteBusinessUnitMemberCoreResponse deleteBusinessUnitMemberCoreResponse = new DeleteBusinessUnitMemberCoreResponse();


                    if (existingEmployee != null)
                    {
                        // Check if Employeee is exist in BusinessUnitMember Table.
                        var existingBUMember = _dbContext.BusinessUnitMembers.FirstOrDefault(e => e.EmployeeLoginId == deleteBusinessUnitMemberCoreRequest.EmployeeLoginId);

                        if (existingBUMember != null)
                        {
                          // Check if Employeee is Manager role. if Employee is Manager true skip Detach Action.
                            var isManager = _dbContext.BusinessUnitMembers.FirstOrDefault(e => e.IsManager == true && e.EmployeeLoginId == deleteBusinessUnitMemberCoreRequest.EmployeeLoginId);

                            if (isManager == null)
                            {
                                // Now get the BusinessUnit Member recod and remove it.
                                var businessUnitMember = _dbContext.BusinessUnitMembers.FirstOrDefault(e => e.EmployeeLoginId == deleteBusinessUnitMemberCoreRequest.EmployeeLoginId);
                               
                                // Add the new employee to the Employees DbSet
                                _dbContext.BusinessUnitMembers.Remove(businessUnitMember);

                                // Save changes to the database
                                _dbContext.SaveChanges();

                                deleteBusinessUnitMemberCoreResponse.Result = true;
                                return CommandResult<DeleteBusinessUnitMemberCoreResponse>.CreateSuccess(deleteBusinessUnitMemberCoreResponse, StatusCodes.Status200OK);
                            }
                            else
                            {
                                return CommandResult<DeleteBusinessUnitMemberCoreResponse>.CreateError("A Manager cannot be detached from a team.Please check with Administrator.", StatusCodes.Status409Conflict);
                            }   
                        }
                        else
                        {
                            return CommandResult<DeleteBusinessUnitMemberCoreResponse>.CreateError("Employee already assigned with other Business Unit.Please check with Administrator.", StatusCodes.Status409Conflict);
                        }
                    }
                    else
                    {
                        return CommandResult<DeleteBusinessUnitMemberCoreResponse>.CreateError("Employee not exists in Business Unit.Please check with Administrator.", StatusCodes.Status400BadRequest);
                    }
                }
            }
            catch (Exception ex)
            {
                return CommandResult<DeleteBusinessUnitMemberCoreResponse>.CreateError(ex.Message, StatusCodes.Status500InternalServerError);
            }            
        }
    }
}
