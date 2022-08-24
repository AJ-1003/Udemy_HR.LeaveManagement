using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.MVC.Models.LeaveTypes
{
    public class Create_LeaveTypeVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Default Number of Days")]
        public int DefaultDays { get; set; }
    }
}
