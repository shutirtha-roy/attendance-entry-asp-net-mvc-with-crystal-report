using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeAttendance.WebForm.StaticData
{
    public static class EmployeeStaticData
    {
        public static string SelectItemMessage { get; private set; } = "--- Please Select ---";
        public static int InitialIndex { get; private set; } = 0;
        public static string UnUsedValue { get; private set; } = "-1";
        public static string EmployeeName { get; private set; } = "EmployeeName";
        public static string EmployeeProfileId { get; private set; } = "EmployeeProfileId";
        public static string ReportLocation { get; private set; } = "~/Reports/AttendanceReport.rpt";
        public static string Table { get; private set; } = "table";
        public static string ReportTitle { get; private set; } = "Employee Attendance Information";

        public static bool NotEmpty(int count)
        {
            return count > 0;
        }
    }
}