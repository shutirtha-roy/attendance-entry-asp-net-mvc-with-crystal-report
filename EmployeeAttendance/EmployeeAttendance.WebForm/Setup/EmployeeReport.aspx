<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeReport.aspx.cs" Inherits="EmployeeAttendance.WebForm.Setup.EmployeeReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center">
        <h1 class="form-title">Employee Attendance Report</h1>
    </div>

    <form class="mt-5 mt-5"  runat="server">
        <div class="mx-auto text-center mb-5" style="width: 620px;">
            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 ml-4 col-form-label col-form-label-lg text-large" ID="Label1" runat="server" Text="Select Company"></asp:Label>
                <asp:DropDownList CssClass="" ID="ddlEmployeeDivision" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEmployeeDivision_SelectedIndexChanged">
                </asp:DropDownList>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label2" runat="server" Text="Start Date"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtStartDate" textMode="Date" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label3" runat="server" Text="End Date"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtEndDate"  textMode="Date" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <asp:Button CssClass="btn btn-success btn-lg mb-5" ID="btnSave" runat="server" Text="GetAttendanceReport" OnClick="btnGetAttendanceReport_Click" />
            <%--&nbsp;
            <asp:Button CssClass="btn btn-secondary btn-lg mb-5" ID="btnClearForm" runat="server" Text="ClearForm" OnClick="btnClearForm_Click" />--%>
        </div>

    </form>
</asp:Content>
