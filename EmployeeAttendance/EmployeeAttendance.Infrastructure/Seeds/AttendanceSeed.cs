using EmployeeAttendance.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendance.Infrastructure.Seeds
{
    internal class AttendanceSeed
    {
        internal AttendanceEntity[] Attendances
        {
            get
            {
                return new AttendanceEntity[]
                {
                    new AttendanceEntity()
                    {
                        Id = new Guid("15dc6496-95a4-48ec-a0fa-08dac3136953"),
                        EmployeeId = new Guid("6eb1d2cc-ec99-4370-a3b7-65e3e56c3ef4"),
                        CreatedDate = DateTime.Parse("2012-01-01 00:00:00.0000000"),
                        InTime = DateTime.Parse("0001-01-01 00:00:00.0000000"),
                        OutTime = DateTime.Parse("0001-01-01 05:04:00.0000000"),
                        Remarks = "Samin1"
                    },
                    new AttendanceEntity()
                    {
                        Id = new Guid("3c9e7381-3bd7-4dfa-a0fb-08dac3136953"),
                        EmployeeId = new Guid("17ef6e14-7450-4f45-a3ff-3fe63969efef"),
                        CreatedDate = DateTime.Parse("0001-01-01 00:00:00.0000000"),
                        InTime = DateTime.Parse("0001-01-01 11:00:00.0000000"),
                        OutTime = DateTime.Parse("0001-01-01 07:03:00.0000000"),
                        Remarks = "Junu1"
                    },
                    new AttendanceEntity()
                    {
                        Id = new Guid("7594f0c8-e28c-489a-a0fc-08dac3136953"),
                        EmployeeId = new Guid("6eb1d2cc-ec99-4370-a3b7-65e3e56c3ef4"),
                        CreatedDate = DateTime.Parse("2013-01-01 00:00:00.0000000"),
                        InTime = DateTime.Parse("2022-11-10 00:00:00.0000000"),
                        OutTime = DateTime.Parse("2022-11-10 00:00:00.0000000"),
                        Remarks = "Samin2"
                    },
                    new AttendanceEntity()
                    {
                        Id = new Guid("ab08d369-3d9b-432e-7b69-08dac318037d"),
                        EmployeeId = new Guid("794f9d2a-b884-44c6-a36a-f35d8a3b8368"),
                        CreatedDate = DateTime.Parse("2021-01-01 00:00:00.0000000"),
                        InTime = DateTime.Parse("0001-01-01 00:00:00.0000000"),
                        OutTime = DateTime.Parse("0001-01-01 00:00:00.0000000"),
                        Remarks = "Hallo"
                    }
                };
            }
        }
    }
}
