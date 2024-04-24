namespace TMS.API.DTO
{
    public class AddBusinessUnitMemberRequestDTO
    {
        public string EmployeeLoginId { get; set; }
        public int BU_Id { get; set; }
        public bool IsManager { get; set; } = false;
    }
}
