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
            attendanceVM.EmployeeList = GetSelectedEmployeeProfileData();

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

            return View(obj);
        }

        [HttpGet]
        public ActionResult GetAllAttendance()
        {
            AttendanceListModel attendanceModel = _scope.Resolve<AttendanceListModel>();
            attendanceModel.ResolveDependency(_scope);

            var objAttendanceList = attendanceModel.GetAllAttendance();
            return Json(new { data = objAttendanceList });
        }

        [HttpGet]
        public IEnumerable<SelectListItem> GetSelectedEmployeeProfileData()
        {
            EmployeeModel employeeModel = _scope.Resolve<EmployeeModel>();
            employeeModel.ResolveDependency(_scope);

            var data = employeeModel.GetAllEmployeeProfile();

            return data;
        }

    }
}
