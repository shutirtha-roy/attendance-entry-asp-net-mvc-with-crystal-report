using Autofac;
using EmployeeAttendance.Infrastructure.DbContexts;
using EmployeeAttendance.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeAttendance.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AttendanceController : Controller
    {
        private readonly ILogger<AttendanceController> _logger;
        private readonly ILifetimeScope _scope;
        public AttendanceController(ILogger<AttendanceController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }


        public IActionResult Index()
        {
            //_logger.LogInformation("I am in attendance index page");
            return RedirectToAction("Create");
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
                _logger.LogInformation("Model State is valid during creating of attendance");
                obj.Attendance.ResolveDependency(_scope);

                try
                {
                    obj.Attendance.CreateAttendance();
                    TempData["success"] = "Attendance added successfully";
                    return RedirectToAction("Create");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    TempData["error"] = "Attendance didn't create successfully";
                }
            }
            else
            {
                TempData["error"] = "Attendance failed, due to incorrect inputs";
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
        public ActionResult GetAllModifiedTimeAttendance()
        {
            AttendanceListModel attendanceModel = _scope.Resolve<AttendanceListModel>();
            attendanceModel.ResolveDependency(_scope);

            var objAttendanceModifiedList = attendanceModel.GetAllModifiedAttendance();
            return Json(new { data = objAttendanceModifiedList });
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