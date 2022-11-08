using Autofac;
using EmployeeAttendance.Infrastructure.BusinessObjects;
using EmployeeAttendance.Infrastructure.Services;
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
        private ILifetimeScope _scope;
        private IAttendanceService _attendanceService;

        public AttendanceCreateModel()
        {

        }

        public AttendanceCreateModel(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _attendanceService = _scope.Resolve<IAttendanceService>();
        }

        internal void CreateAttendance()
        {
            Attendance attendance = new Attendance();

            attendance.EmployeeId = EmployeeId;
            attendance.CreatedDate = CreatedDate;
            attendance.InTime = InTime;
            attendance.OutTime = OutTime;
            attendance.Remarks = Remarks;

            _attendanceService.CreateAttendance(attendance);
        }

    }
}
