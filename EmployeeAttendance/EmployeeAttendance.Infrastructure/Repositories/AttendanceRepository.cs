using EmployeeAttendance.Infrastructure.DbContexts;
using EmployeeAttendance.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendance.Infrastructure.Repositories
{
    public class AttendanceRepository : Repository<AttendanceEntity, Guid>, IAttendanceRepository
    {
        private readonly ITrainingDbContext _context;

        public AttendanceRepository(ITrainingDbContext context) : base((DbContext)context)
        {
            _context = context;
        }

        public dynamic GetAttendencByEmployeeId(Guid id)
        {
            return _context.Attendances.Where(e => e.EmployeeId == id).ToList();
        }
    }
}
