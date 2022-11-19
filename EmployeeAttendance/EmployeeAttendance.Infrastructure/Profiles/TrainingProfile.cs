using AutoMapper;
using EmployeeAttendance.Infrastructure.BusinessObjects;
using EmployeeAttendance.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendance.Infrastructure.Profiles
{
    public class TrainingProfile : Profile
    {
        public TrainingProfile()
        {
            CreateMap<AttendanceEntity, Attendance>()
                .ReverseMap();
        }
    }
}
