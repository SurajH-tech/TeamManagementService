namespace TMS.API.DTO
{
    public class UpdateBusinessUnitRequestDTO
    {        
        public string BU_Name { get; set; }
        public string BU_Description { get; set; }
        public bool Active { get; set; }
        public string BU_Type { get; set; }

        public List<UpdateBusinessCategoryRequestDTO> BusinessCategories { get; set; }

        //public List<UpdateEmployeeDTO> Employees { get; set; }
    }

    public class UpdateBusinessCategoryRequestDTO
    {        
        public string ZurichLineOfBusiness { get; set; }
    }

    //public class UpdateEmployeeDTO
    //{
    //    public string EmployeeLoginId { get; set; }        
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Status { get; set; }
    //    public string EmailAddress { get; set; }
    //}
}
