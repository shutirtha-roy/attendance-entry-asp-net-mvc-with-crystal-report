using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeAttendance.WebForm.StaticData
{
    public static class Validation
    {
        public static bool CheckValidationOfAnInput(string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        public static bool AllValidation(params string[] values)
        {
            bool condition = true;

            foreach (string value in values)
            {
                condition &= CheckValidationOfAnInput(value);
            }

            return condition;
        }
    }
}