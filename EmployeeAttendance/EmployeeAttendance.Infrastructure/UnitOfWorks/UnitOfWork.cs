using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DbContextObject = Microsoft.EntityFrameworkCore.DbContext;

namespace EmployeeAttendance.Infrastructure.UnitOfWorks
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContextObject _dbContext;

        public UnitOfWork(DbContextObject dbContext)
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
