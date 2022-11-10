using EmployeeAttendance.WebForm.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeAttendance.WebForm.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IDataAccess _dataAccess;
        public EmployeeService()
        {
            _dataAccess = new DataAccess();
        }

        private SqlCommand PrepareCommand(string sqlCommand)
        {
            SqlConnection sqlConnection = new SqlConnection(_dataAccess.ConnectionString);
            SqlCommand command = new SqlCommand(sqlCommand, sqlConnection);

            return command;
        }

        public DataTable GetAllCompanyEmployeeProfile()
        {
            string command = $"SELECT * FROM Hrms_Company_Employee_Profile";
            SqlCommand sqlCommand = PrepareCommand(command);

            if (sqlCommand.Connection.State != System.Data.ConnectionState.Open)
                sqlCommand.Connection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            sqlCommand.Dispose();

            return dataTable;
        }

        public DataSet GetDataFromEmployeeAndDateTime(string id, string before, string after)
        {
            string command = $"SELECT * FROM Attendances WHERE EmployeeId = '{id}' AND CreatedDate BETWEEN '{before}' AND '{after}'";
            SqlCommand sqlCommand = PrepareCommand(command);

            if (sqlCommand.Connection.State != System.Data.ConnectionState.Open)
                sqlCommand.Connection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds);

            sqlCommand.Dispose();

            return ds;
        }
    }
}