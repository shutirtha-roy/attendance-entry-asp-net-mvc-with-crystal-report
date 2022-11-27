using Autofac;
using AutoMapper;
using EmployeeAttendance.Infrastructure.BusinessObjects;
using EmployeeAttendance.Infrastructure.DbContexts;
using EmployeeAttendance.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceBO = EmployeeAttendance.Infrastructure.BusinessObjects.Attendance;
using AttendanceEO = EmployeeAttendance.Infrastructure.Entities.AttendanceEntity;

namespace EmployeeAttendance.Infrastructure.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        private readonly ILifetimeScope _scope;
        private readonly IMapper _mapper;

        public AttendanceService(IMapper mapper, IApplicationUnitOfWork applicationUnitOfWork, ILifetimeScope scope)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _scope = scope;
            _mapper = mapper;
        }

        public void CreateAttendance(AttendanceBO attendance)
        {
            AttendanceEO courseEntity = _mapper.Map<AttendanceEO>(attendance);

            _applicationUnitOfWork.Attendances.Add(courseEntity);
            _applicationUnitOfWork.Save();
        }

        public dynamic GetAllAtttendance()
        {
            return _applicationUnitOfWork.Attendances.GetAll();
        }

        public object GetAllModifitedAttendance()
        {
            IEmployeeService employeeService = _scope.Resolve<IEmployeeService>();

            AttendanceBO attendanceBO = new AttendanceBO();
            List<dynamic> data = new List<dynamic>();

            var allAttendanceData = GetAllAtttendance();

            foreach(var attendance in allAttendanceData)
            {
                data.Add(new { 
                    Name = employeeService.GetEmployeeName(attendance.EmployeeId), 
                    CreatedDate = attendanceBO.GetOnlyDate(attendance.CreatedDate), 
                    InTime = attendanceBO.GetOnlyTime(attendance.InTime), 
                    OutTime = attendanceBO.GetOnlyTime(attendance.OutTime), 
                    Remarks = attendance.Remarks
                });
            }

            return data;
        }

        public dynamic GetEmployeeAttendance(string userId)
        {
            Guid Id = new Guid(userId);

            return _applicationUnitOfWork.Attendances.GetAttendencByEmployeeId(Id);
        }

        public object GetModifiedEmployeeAttendance(string userId, string name)
        {
            IEmployeeService employeeService = _scope.Resolve<IEmployeeService>();
            AttendanceBO attendanceBO = new AttendanceBO();
            List<dynamic> data = new List<dynamic>();

            var allAttendanceData = GetEmployeeAttendance(userId);

            foreach (var attendance in allAttendanceData)
            {
                data.Add(new
                {
                    Name = name,
                    CreatedDate = attendanceBO.GetOnlyDate(attendance.CreatedDate),
                    InTime = attendanceBO.GetOnlyTime(attendance.InTime),
                    OutTime = attendanceBO.GetOnlyTime(attendance.OutTime),
                    Remarks = attendance.Remarks
                });
            }

            return data;
        }
    }
}
