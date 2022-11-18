using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendance.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly string _connectionString;

        public EmployeeService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        private SqlCommand PrepareCommand(string sqlCommand)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(sqlCommand, sqlConnection);

            return command;
        }

        public dynamic GetAllEmployee()
        {
            string command = "Select * from Hrms_Company_Employee_Profile";
            using SqlCommand sqlCommand = PrepareCommand(command);

            if (sqlCommand.Connection.State != System.Data.ConnectionState.Open)
                sqlCommand.Connection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds);

            List<SelectListItem> employeeProfileList = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                employeeProfileList.Add(new SelectListItem { Text = dr["EmployeeName"].ToString(), Value = dr["EmployeeProfileId"].ToString() }); ;
            }

            //var data = from value in employeeProfileList select new { value.Text, value.Value };

            return employeeProfileList;
        }

        public string GetEmployeeName(Guid id)
        {
            string command = $"SELECT TOP 1 EmployeeName FROM Hrms_Company_Employee_Profile WHERE EmployeeProfileId = '{id}'";
            using SqlCommand sqlCommand = PrepareCommand(command);

            if (sqlCommand.Connection.State != System.Data.ConnectionState.Open)
                sqlCommand.Connection.Open();

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            string employeeName = "Intern";

            if (reader.Read())
            {
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    employeeName = (string)reader.GetValue(i);
                }
            }

            if (sqlCommand.Connection.State == System.Data.ConnectionState.Open)
                sqlCommand.Connection.Close();

            return employeeName;
        }
    }
}
