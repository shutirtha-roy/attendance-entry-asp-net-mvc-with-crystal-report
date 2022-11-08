using Autofac;
using EmployeeAttendance.Infrastructure.Services;

namespace EmployeeAttendance.Web.Areas.Admin.Models
{
    public class EmployeeModel
    {
        private ILifetimeScope _scope;
        private IEmployeeService? _employeeService;

        public EmployeeModel()
        {

        }
        public void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _employeeService = _scope.Resolve<IEmployeeService>();
        }

        internal object GetAllEmployeeProfile()
        {
            return _employeeService.GetAllEmployee();
        }
    }
}
