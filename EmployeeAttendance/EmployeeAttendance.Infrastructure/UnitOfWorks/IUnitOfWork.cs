using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendance.Infrastructure.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
