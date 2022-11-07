using System.ComponentModel.DataAnnotations;

namespace EmployeeAttendance.Web.Areas.Admin.Models
{
    public class AttendanceCreateModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime InTime { get; set; }
        [Required]
        public DateTime OutTime { get; set; }
        public string Remarks { get; set; }

        public AttendanceCreateModel()
        {

        }


    }
}
