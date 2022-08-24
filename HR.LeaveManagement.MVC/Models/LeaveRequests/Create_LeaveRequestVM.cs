using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.MVC.Models.LeaveRequests
{
    public class Create_LeaveRequestVM
    {
        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        public SelectList LeaveTypes { get; set; }
        [Required]
        [Display(Name = "Leave Type")]
        public Guid LeaveTypeId { get; set; }
        [Display(Name = "Request Comments")]
        [MaxLength(300)]
        public string RequestComments { get; set; }
    }
}
