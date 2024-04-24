using System.ComponentModel.DataAnnotations;
using TMS.Core.Entities;
using TMS.Core.Requests;

namespace TMS.API.DTO
{
    public class AddBusinessUnitRequestDTO
    {
        public string BU_Name { get; set; }
        public string BU_Description { get; set; }
        public bool Active { get; set; } = false;
        public string BU_Type { get; set; }

        public List<AddBusinessCategoryRequestDTO> BusinessCategories { get; set; }

        public List<AddEmployeeDTO> Employees { get; set; }
       
    }

    public class AddBusinessCategoryRequestDTO
    {  
        public string ZurichLineOfBusiness { get; set; }
    }     

    public class AddEmployeeDTO
    {
        public string EmployeeLoginId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }      
        public string Status { get; set; }
        public string EmailAddress { get; set; }
        public bool IsManager { get; set; } = false;
    }
}
