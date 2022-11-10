using Autofac;
using EmployeeAttendance.Infrastructure.DbContexts;
using EmployeeAttendance.Infrastructure.Entities;
using EmployeeAttendance.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeAttendance.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttendanceController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly TrainingDbContext _db;
        public AttendanceController(ILifetimeScope scope, TrainingDbContext db)
        {
            _scope = scope;
            _db = db;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AttendanceViewModel obj)
        {
            if (ModelState.IsValid)
            {
                obj.Attendance.ResolveDependency(_scope);
                obj.Attendance.CreateAttendance();

               return RedirectToAction("Create");
            }

            return View();
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
