using HR.LeaveManagement.MVC.Models.LeaveTypes;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HR.LeaveManagement.MVC.Models.LeaveAllocations
{
    public class LeaveAllocationVM : Create_LeaveAllocationVM
    {
        public Guid Id { get; set; }
        [Display(Name = "Number Of Days")]

        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public int Period { get; set; }

        public LeaveTypeVM LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
    }
}
