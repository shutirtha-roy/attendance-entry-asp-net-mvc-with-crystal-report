using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendance.WebForm.Data
{
    public interface IDataAccess
    {
        string ConnectionString { get; set; }
    }
}
