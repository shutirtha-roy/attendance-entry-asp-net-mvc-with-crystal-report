using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendance.Infrastructure.Entities
{
    public class AttendanceEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public string Remarks { get; set; }
    }
}
