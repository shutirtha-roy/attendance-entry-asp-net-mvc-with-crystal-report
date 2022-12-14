using AutoMapper;
using EmployeeAttendance.Infrastructure.BusinessObjects;
using EmployeeAttendance.Web.Areas.Admin.Models;
using EmployeeAttendance.Web.Models;

namespace EmployeeAttendance.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<Attendance, AttendanceCreateModel>()
            .ReverseMap();
        }
    }
}
