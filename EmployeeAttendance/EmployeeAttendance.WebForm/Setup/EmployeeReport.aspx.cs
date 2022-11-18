using Autofac.Integration.Web.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using EmployeeAttendance.WebForm.Services;
using EmployeeAttendance.WebForm.StaticData;
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
        public IEmployeeService _employeeService { get; set; }
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
            ddlEmployeeDivision.Items.Insert(EmployeeStaticData.InitialIndex, new ListItem(EmployeeStaticData.SelectItemMessage, EmployeeStaticData.UnUsedValue));

            foreach (DataRow dr in dt.Rows)
            {
                ListItem lst = new ListItem();
                lst.Text = dr[EmployeeStaticData.EmployeeName].ToString();
                lst.Value = dr[EmployeeStaticData.EmployeeProfileId].ToString();
                ddlEmployeeDivision.Items.Add(lst);
            }
        }

        private void AddOnlyDefaultItemInDropdown()
        {
            ddlEmployeeDivision.Items.Insert(EmployeeStaticData.InitialIndex, new ListItem(EmployeeStaticData.SelectItemMessage, EmployeeStaticData.UnUsedValue));
            EmployeeId = string.Empty;
        }

        private void LoadEmployeeId()
        {
            DataTable dt = _employeeService.GetAllCompanyEmployeeProfile();

            if (EmployeeStaticData.NotEmpty(dt.Rows.Count))
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
            Report.Load(Server.MapPath(EmployeeStaticData.ReportLocation));
            Report.SetDataSource(dataTable);
            return Report;
        }

        private void ShowReportDetails(DataSet dataSet)
        {
            ReportDocument Report = SetReportConfiguration(dataSet.Tables[EmployeeStaticData.Table]);
            CrystalReportViewer1.ReportSource = Report;
            Report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, EmployeeStaticData.ReportTitle);
        }

        protected void btnGetAttendanceReport_Click(object sender, EventArgs e)
        {
            if (Validation.AllValidation(EmployeeId, txtStartDate.Text, txtEndDate.Text))
            {
                DataSet dataSet = _employeeService.GetDataFromEmployeeAndDateTime(EmployeeId, txtStartDate.Text, txtEndDate.Text);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(Page, MessageBox.EmptyReport);
                }
                else
                {
                    ShowReportDetails(dataSet);
                }
            }
            else
            {
                MessageBox.Show(Page, MessageBox.InvalidInput);
            }

        }
    }
}