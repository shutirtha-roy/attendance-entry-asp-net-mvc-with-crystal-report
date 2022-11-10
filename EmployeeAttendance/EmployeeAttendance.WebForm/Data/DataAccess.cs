using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace EmployeeAttendance.WebForm.Data
{
    public class DataAccess : IDataAccess
    {
        public string ConnectionString { get; set; }
        public DataAccess()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringAttendance"].ConnectionString;
        }
    }
}