using EmployeeAttendance.Infrastructure.DbContexts;
using EmployeeAttendance.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendance.Infrastructure.Repositories
{
    public class AttendanceRepository : Repository<AttendanceEntity>, IAttendanceRepository
    {
        private TrainingDbContext _db;

        public AttendanceRepository(TrainingDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(AttendanceEntity obj)
        {
            _db.Attendances.Update(obj);
        }
    }
}
