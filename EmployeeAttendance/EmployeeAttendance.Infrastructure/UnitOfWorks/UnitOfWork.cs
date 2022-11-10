using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAttendance.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendance.Infrastructure.UnitOfWorks
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public virtual void Dispose()
        {
            _dbContext?.Dispose();
        }
        
        public virtual void Save()
        {
            _dbContext?.SaveChanges();
        }
        
    }
}
