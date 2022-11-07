using EmployeeAttendance.Infrastructure.DbContext;
using EmployeeAttendance.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContextObject = Microsoft.EntityFrameworkCore.DbContext;

namespace EmployeeAttendance.Infrastructure.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IAttendanceRepository Attendances { get; private set; }
        public ApplicationUnitOfWork(ITrainingDbContext dbContext,
            IAttendanceRepository attendanceRepository) : base((DbContextObject)dbContext)
        {
            Attendances = attendanceRepository;
        }
    }
}
