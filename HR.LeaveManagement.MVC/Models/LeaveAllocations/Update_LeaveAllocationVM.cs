using Hanssens.Net;
using HR.LeaveManagement.MVC.Models.LeaveTypes;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HR.LeaveManagement.MVC.Models.LeaveAllocations
{
    public class Update_LeaveAllocationVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Number Of Days")]
        [Range(1, 50, ErrorMessage = "Enter Valid Number")]
        public int NumberOfDays { get; set; }
        public LeaveTypeVM LeaveType { get; set; }
    }
}
