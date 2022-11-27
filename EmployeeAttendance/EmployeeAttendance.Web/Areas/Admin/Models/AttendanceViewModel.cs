using EmployeeAttendance.Web.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeAttendance.Web.Areas.Admin.Models
{
    public class AttendanceViewModel
    {
        public AttendanceCreateModel Attendance { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> EmployeeList { get; set; }

        public AttendanceViewModel()
        {

        }
    }
}
