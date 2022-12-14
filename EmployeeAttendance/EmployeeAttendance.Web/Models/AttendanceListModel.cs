using Autofac;
using EmployeeAttendance.Infrastructure.Services;

namespace EmployeeAttendance.Web.Models
{
    public class AttendanceListModel
    {
        private ILifetimeScope _scope;
        private IAttendanceService? _attendanceService;

        public AttendanceListModel(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _attendanceService = _scope.Resolve<IAttendanceService>();
        }

        internal object? GetAllAttendance()
        {
            return _attendanceService?.GetAllAtttendance();
        }

        internal object? GetAllModifiedAttendance()
        {
            return _attendanceService?.GetAllModifitedAttendance();
        }

        internal object GetEmployeeAttendance(string userId)
        {
            return _attendanceService?.GetEmployeeAttendance(userId);
        }

        internal object GetModifiedEmployeeAttendance(string userId, string name)
        {
            return _attendanceService?.GetModifiedEmployeeAttendance(userId, name);
        }
    }
}
