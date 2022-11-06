namespace EmployeeAttendance.Web.Areas.Admin.Models
{
    public class AttendanceCreateModel
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public TimeOnly InTime { get; set; }
        public TimeOnly OutTime { get; set; }
        public string Remarks { get; set; }
    }
}
