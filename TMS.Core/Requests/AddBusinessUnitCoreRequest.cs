namespace TMS.Core.Requests
{
    //Core Request for Add BusinessUnit Details
    public class AddBusinessUnitCoreRequest
    { 
        public string BU_Name { get; set; }
        public string BU_Description { get; set; }
        public bool Active { get; set; }
        public string BU_Type { get; set; }

        public List<AddBusinessCategoryCoreRequest> BusinessCategories { get; set; }

        public List<AddEmployeeCoreRequest> Employees { get; set; }
    }
     
    public class AddBusinessCategoryCoreRequest
    {  
        public string ZurichLineOfBusiness { get; set; }
    }

    public class AddEmployeeCoreRequest
    {
        public string EmployeeLoginId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public string EmailAddress { get; set; }
        public bool IsManager { get; set; }
    }
}
