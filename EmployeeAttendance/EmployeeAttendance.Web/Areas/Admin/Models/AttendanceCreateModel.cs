using Autofac;
using AutoMapper;
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
        private IMapper _mapper;

        public AttendanceCreateModel()
        {

        }

        public AttendanceCreateModel(IAttendanceService attendanceService, IMapper mapper)
        {
            _attendanceService = attendanceService;
            _mapper = mapper;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _attendanceService = _scope.Resolve<IAttendanceService>();
            _mapper = _scope.Resolve<IMapper>();
        }

        internal void CreateAttendance()
        {
            Attendance attendance = _mapper.Map<Attendance>(this);
            _attendanceService.CreateAttendance(attendance);
        }

    }
}
