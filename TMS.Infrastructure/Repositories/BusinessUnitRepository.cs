using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TMS.Core.Entities;
using TMS.Core.Repositories;
using TMS.Core.Requests;
using TMS.Core.Responses;
using TMS.Infrastructure.Data;
using TMS.Utilities;

namespace TMS.Infrastructure.Repositories
{
    public class BusinessUnitRepository : IBusinessUnit
    {
        private readonly TMSDbContext _dbContext;     

        public BusinessUnitRepository(TMSDbContext context)
        {
            _dbContext = context;         
        }

        /// <summary>
        /// Adds the new Business Unit.
        /// </summary>
        /// <param name="addBusinessUnitRequest">The request containing data to add new Business Unit Deatils</param>
        /// <returns></returns>
        public async Task<CommandResult<AddBusinessUnitCoreResponse>> AddBusinessUnitAsync(AddBusinessUnitCoreRequest addBusinessUnitRequest)
        {
            try
            {
                AddBusinessUnitCoreResponse addBusinessUnitCoreResponse = new AddBusinessUnitCoreResponse();

                // Prepare the Parameter for stored procedure - usp_AddBusinessUnit

                var buName = new SqlParameter("@BU_Name", addBusinessUnitRequest.BU_Name);
                var buDesc = new SqlParameter("@BU_Description", addBusinessUnitRequest.BU_Description);
                var active = new SqlParameter("@Active", addBusinessUnitRequest.Active);
                var buType = new SqlParameter("@BU_Type", addBusinessUnitRequest.BU_Type);
                

                // Convert the Business Category list to a DataTable.
                DataTable dtBusinessCategory = DataTableHelper.ToDataTable(addBusinessUnitRequest.BusinessCategories);

                // Convert the Employee list to DataTable
                DataTable dtEmployee = DataTableHelper.ToDataTable(addBusinessUnitRequest.Employees);


                // Prepare User Defined Table Data Type Parameter - @UTBusinessCategory & @UTEmployee.
                var businessCategory = new SqlParameter
                {
                    ParameterName = "@UTBusinessCategory",
                    SqlDbType = SqlDbType.Structured,
                    Value = dtBusinessCategory,
                    TypeName = "UTBusinessCategory",
                }; 

                var employee = new SqlParameter
                {
                    ParameterName = "@UTEmployee",
                    SqlDbType = SqlDbType.Structured,
                    Value = dtEmployee,
                    TypeName = "UTEmployee",
                };
                
                var result = _dbContext.Database.ExecuteSqlRaw("usp_AddBusinessUnit @BU_Name,@BU_Description,@Active,@BU_Type,@UTBusinessCategory,@UTEmployee", buName,buDesc,active,buType,businessCategory,employee);

                // Prepare the success response.  - Need to work.
                addBusinessUnitCoreResponse.isSuccess = true;

               return CommandResult<AddBusinessUnitCoreResponse>.CreateSuccess(addBusinessUnitCoreResponse, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return CommandResult<AddBusinessUnitCoreResponse>.CreateError(ex.Message, StatusCodes.Status500InternalServerError);
            }            
        }

        /// <summary>
        /// Updates the existing business unit details.
        /// </summary>
        /// <param name="updateBusinessUnitRequest">The request containing data for update Business Unit Deatils.</param>
        /// <returns></returns>
        public async Task<CommandResult<UpdateBusinessUnitCoreResponse>> UpdateBusinessUnitAsync(UpdateBusinessUnitCoreRequest updateBusinessUnitRequest)
        {
            try
            {
                UpdateBusinessUnitCoreResponse updateBusinessUnitCoreResponse = new UpdateBusinessUnitCoreResponse();

                // Prepare the Parameter for stored procedure - usp_UpdateBusinessUnit

                var buId = new SqlParameter("@BU_Id", updateBusinessUnitRequest.BU_Id);
                var buName = new SqlParameter("@BU_Name", updateBusinessUnitRequest.BU_Name);
                var buDesc = new SqlParameter("@BU_Description", updateBusinessUnitRequest.BU_Description);
                var active = new SqlParameter("@Active", updateBusinessUnitRequest.Active);
                var buType = new SqlParameter("@BU_Type", updateBusinessUnitRequest.BU_Type);
                

                // Convert the Business Category list to a DataTable
                DataTable dtBusinessCategory = DataTableHelper.ToDataTable(updateBusinessUnitRequest.BusinessCategories);

                var businessCategory = new SqlParameter
                {
                    ParameterName = "@UTBusinessCategory",
                    SqlDbType = SqlDbType.Structured,
                    Value = dtBusinessCategory,
                    TypeName = "UTBusinessCategory",
                };        

                var result = _dbContext.Database.ExecuteSqlRaw("usp_UpdateBusinessUnit @BU_Id,@BU_Name,@BU_Description,@Active,@BU_Type,@UTBusinessCategory", buId,buName, buDesc, active, buType, businessCategory);

                // Prepare the success response - Need to work 
                updateBusinessUnitCoreResponse.isSuccess = true;

                return CommandResult<UpdateBusinessUnitCoreResponse>.CreateSuccess(updateBusinessUnitCoreResponse, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return CommandResult<UpdateBusinessUnitCoreResponse>.CreateError(ex.Message, StatusCodes.Status500InternalServerError);
            }            
        }
    }
}
