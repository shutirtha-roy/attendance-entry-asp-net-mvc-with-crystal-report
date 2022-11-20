using Autofac;
using EmployeeAttendance.Web.Areas.Admin.Models;
using EmployeeAttendance.Web.Models;

namespace EmployeeAttendance.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AttendanceCreateModel>().AsSelf();

            builder.RegisterType<EmployeeModel>().AsSelf();

            builder.RegisterType<AttendanceViewModel>().AsSelf();

            builder.RegisterType<AttendanceListModel>().AsSelf();

            builder.RegisterType<RegisterModel>().AsSelf();

            builder.RegisterType<LoginModel>().AsSelf();

            base.Load(builder);
        }
    }
}