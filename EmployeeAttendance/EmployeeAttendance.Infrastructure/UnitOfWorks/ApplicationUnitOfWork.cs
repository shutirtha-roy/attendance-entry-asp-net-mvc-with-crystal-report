using EmployeeAttendance.Infrastructure.DbContexts;
using EmployeeAttendance.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendance.Infrastructure.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IAttendanceRepository Attendances { get; private set; }
        public ApplicationUnitOfWork(ITrainingDbContext dbContext,
            IAttendanceRepository attendanceRepository) : base((DbContext)dbContext)
        {
            Attendances = attendanceRepository;
        }
    }
}
