using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendance.WebForm.Services
{
    public interface IEmployeeService
    {
        DataTable GetAllCompanyEmployeeProfile();
        DataSet GetDataFromEmployeeAndDateTime(string id, string before, string after);
    }
}
