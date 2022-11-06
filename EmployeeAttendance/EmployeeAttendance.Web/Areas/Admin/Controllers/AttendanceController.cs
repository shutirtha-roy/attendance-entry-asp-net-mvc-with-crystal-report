using Autofac;
using EmployeeAttendance.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAttendance.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttendanceController : Controller
    {
        private readonly ILifetimeScope _scope;

        public IActionResult Index()
        {
            return View();
        }



        //[HttpGet]
        //public ActionResult GetEmployeeProfileData()
        //{
        //    EmployeeModel employeeModel = _scope.Resolve<EmployeeModel>();
        //    employeeModel.ResolveDependency(_scope);

        //    var data = employeeModel.GetAllEmployee();
        //    return Json(data);
        //}
    }
}
