using Autofac.Integration.Web.Forms;
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
        public  IEmployeeService _employeeService { get; set; }
        public static string EmployeeId { get; set; }

        public EmployeeReport()
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadEmployeeId();
            }
        }

        private void AddItemsInDropDown(DataTable dt)
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

        private void AddOnlyDefaultItemInDropdown()
        {
            ddlEmployeeDivision.Items.Insert(0, new ListItem("--- Please Select ---", "-1"));
            EmployeeId = "";
        }

        private void LoadEmployeeId()
        {
            DataTable dt = _employeeService.GetAllCompanyEmployeeProfile();

            if (dt.Rows.Count > 0)
            {
                AddItemsInDropDown(dt);
            }
            else
            {
                AddOnlyDefaultItemInDropdown();
            }
        }

        protected void ddlEmployeeDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeeId = ddlEmployeeDivision.SelectedValue;
        }

        private ReportDocument SetReportConfiguration(DataTable dataTable)
        {
            ReportDocument Report = new ReportDocument();
            Report.Load(Server.MapPath("~/Reports/AttendanceReport.rpt"));
            Report.SetDataSource(dataTable);
            return Report;
        }

        private void ShowReportDetails(DataSet dataSet)
        {
            ReportDocument Report = SetReportConfiguration(dataSet.Tables["table"]);
            CrystalReportViewer1.ReportSource = Report;
            Report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Employee Attendance Information");
        }

        protected void btnGetAttendanceReport_Click(object sender, EventArgs e)
        {
            DataSet dataSet = _employeeService.GetDataFromEmployeeAndDateTime(EmployeeId, txtStartDate.Text, txtEndDate.Text);
            ShowReportDetails(dataSet);
        }
    }
}