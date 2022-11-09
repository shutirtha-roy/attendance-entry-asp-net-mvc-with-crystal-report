using Autofac;
using EmployeeAttendance.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeAttendance.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttendanceController : Controller
    {
        private readonly ILifetimeScope _scope;

        public AttendanceController(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            AttendanceViewModel attendanceVM = _scope.Resolve<AttendanceViewModel>();
            attendanceVM.Attendance = _scope.Resolve<AttendanceCreateModel>();
            attendanceVM.EmployeeList = GetEmployeeProfileData();

            return View(attendanceVM);
        }


        [HttpGet]
        public dynamic GetEmployeeProfileData()
        {
            EmployeeModel employeeModel = _scope.Resolve<EmployeeModel>();
            employeeModel.ResolveDependency(_scope);

            var data = employeeModel.GetAllEmployeeProfile();

            return data;
        }

    }
}
