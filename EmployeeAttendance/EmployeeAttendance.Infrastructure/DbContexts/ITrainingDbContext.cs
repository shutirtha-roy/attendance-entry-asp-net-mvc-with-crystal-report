using EmployeeAttendance.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendance.Infrastructure.DbContexts
{
    public interface ITrainingDbContext
    {
        public DbSet<AttendanceEntity> Attendances { get; set; }
    }
}
