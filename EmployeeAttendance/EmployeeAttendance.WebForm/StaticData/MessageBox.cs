using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace EmployeeAttendance.WebForm.StaticData
{
    public static class MessageBox
    {
        public static string EmptyReport { get; set; } = "Empty Report";
        public static string InvalidInput { get; set; } = "Invalid Input, Please enter it correctly";

        public static void Show(this Page Page, string Message)
        {
            Page.ClientScript.RegisterStartupScript(
               Page.GetType(),
               "MessageBox",
               "<script language='javascript'>alert('" + Message + "');</script>"
            );
        }
    }
}