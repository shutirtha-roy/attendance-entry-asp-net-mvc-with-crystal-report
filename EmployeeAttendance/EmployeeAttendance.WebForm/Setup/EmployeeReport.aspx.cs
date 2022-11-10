using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using EmployeeAttendance.WebForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeAttendance.WebForm.Setup
{
    public partial class EmployeeReport : System.Web.UI.Page
    {
        private readonly IEmployeeService _employeeService;
        public static string EmployeeId { get; set; }
        public EmployeeReport()
        {
            _employeeService = new EmployeeService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadEmployeeId();
            }
        }

        private void LoadEmployeeId()
        {
            DataTable dt = _employeeService.GetAllCompanyEmployeeProfile();

            if (dt.Rows.Count > 0)
            {
                ddlEmployeeDivision.Items.Insert(0, new ListItem("--- Please Select ---", "-1"));

                foreach (DataRow dr in dt.Rows)
                {
                    ListItem lst = new ListItem();
                    lst.Text = dr["EmployeeName"].ToString();
                    lst.Value = dr["EmployeeProfileId"].ToString();
                    ddlEmployeeDivision.Items.Add(lst);
                }
            }
            else
            {
                ddlEmployeeDivision.Items.Insert(0, new ListItem("--- Please Select ---", "-1"));
                EmployeeId = "";
            }
        }

        protected void ddlEmployeeDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeeId = ddlEmployeeDivision.SelectedValue;
        }

        protected void btnGetAttendanceReport_Click(object sender, EventArgs e)
        {
            DataSet dataSet = _employeeService.GetDataFromEmployeeAndDateTime(EmployeeId, txtStartDate.Text, txtEndDate.Text);

            ReportDocument Report = new ReportDocument();
            Report.Load(Server.MapPath("~/Reports/AttendanceReport.rpt"));
            Report.SetDataSource(dataSet.Tables["table"]);
            CrystalReportViewer1.ReportSource = Report;
            Report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Employee Attendance Information");
            
        }
    }
}