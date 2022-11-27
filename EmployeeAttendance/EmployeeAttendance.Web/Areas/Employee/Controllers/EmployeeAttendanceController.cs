using Autofac;
using EmployeeAttendance.Infrastructure.Entities;
using EmployeeAttendance.Web.Areas.Admin.Models;
using EmployeeAttendance.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace EmployeeAttendance.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    [Authorize(Roles = "Manager,Employee")]
    public class EmployeeAttendanceController : Controller
    {
        private readonly ILogger<EmployeeAttendanceController> _logger;
        private readonly ILifetimeScope _scope;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmployeeAttendanceController(ILogger<EmployeeAttendanceController> logger, ILifetimeScope scope, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _scope = scope;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Create");
        }

        public IActionResult Create()
        {
            AttendanceCreateModel attendance = _scope.Resolve<AttendanceCreateModel>();

            var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            attendance.EmployeeId = userId;

            return View(attendance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee")]
        public IActionResult Create(AttendanceCreateModel obj)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Model State is valid during creating of attendance");
                obj.ResolveDependency(_scope);

                try
                {
                    obj.CreateAttendance();
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetEmployeeAttendance()
        {
            AttendanceListModel attendanceModel = _scope.Resolve<AttendanceListModel>();

            attendanceModel.ResolveDependency(_scope);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var objAttendanceList = attendanceModel.GetEmployeeAttendance(userId);

            return Json(new { data = objAttendanceList });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetModifiedEmployeeAttendance()
        {
            AttendanceListModel attendanceModel = _scope.Resolve<AttendanceListModel>();
            attendanceModel.ResolveDependency(_scope);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.Identity.Name;

            var objEmployeeAttendanceModifiedList = attendanceModel.GetModifiedEmployeeAttendance(userId, userName);
            return Json(new { data = objEmployeeAttendanceModifiedList });
        }
    }
}
