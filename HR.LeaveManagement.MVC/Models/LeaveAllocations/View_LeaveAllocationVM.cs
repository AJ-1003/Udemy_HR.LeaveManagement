namespace HR.LeaveManagement.MVC.Models.LeaveAllocations
{
    public class View_LeaveAllocationVM
    {
        public string EmployeeId { get; set; }
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
    }
}
