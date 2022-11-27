using EmployeeAttendance.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendance.Infrastructure.Repositories
{
    public interface IAttendanceRepository : IRepository<AttendanceEntity, Guid>
    {
        dynamic GetAttendencByEmployeeId(Guid id);
    }
}
