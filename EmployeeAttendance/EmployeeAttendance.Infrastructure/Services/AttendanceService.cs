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

        public AttendanceService(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }

        public void CreateAttendance(AttendanceBO attendance)
        {
            AttendanceEO courseEntity = new AttendanceEO();
            courseEntity.EmployeeId = attendance.EmployeeId;
            courseEntity.CreatedDate = attendance.CreatedDate;
            courseEntity.InTime = attendance.InTime;
            courseEntity.OutTime = attendance.OutTime;
            courseEntity.Remarks = attendance.Remarks;

            _applicationUnitOfWork.Attendances.Add(courseEntity);
            _applicationUnitOfWork.Save();
        }

        public dynamic GetAllAtttendance()
        {
            return _applicationUnitOfWork.Attendances.GetAll();
        }

        public object GetAllModifitedAttendance()
        {
            AttendanceBO attendanceBO = new AttendanceBO();
            List<dynamic> data = new List<dynamic>();

            var allAttendanceData = GetAllAtttendance();

            foreach(var attendance in allAttendanceData)
            {
                data.Add(new { CreatedDate = attendanceBO.GetOnlyDate(attendance.CreatedDate), InTime = attendanceBO.GetOnlyTime(attendance.InTime), 
                                OutTime = attendanceBO.GetOnlyTime(attendance.OutTime), Remarks = attendance.Remarks + "Test" });
            }

            return data;
        }
    }
}
