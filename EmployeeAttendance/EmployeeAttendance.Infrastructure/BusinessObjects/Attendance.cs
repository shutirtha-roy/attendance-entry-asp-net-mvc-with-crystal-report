using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendance.Infrastructure.BusinessObjects
{
    public class Attendance
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public string Remarks { get; set; }

        public string GetOnlyDate(DateTime time)
        {
            return time.ToShortDateString();
        }

        public string GetOnlyTime(DateTime time)
        {
            return time.ToShortTimeString();
        }

    }
}
