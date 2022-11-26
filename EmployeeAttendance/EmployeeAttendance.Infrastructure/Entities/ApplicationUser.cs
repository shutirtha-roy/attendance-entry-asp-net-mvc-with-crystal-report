using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendance.Infrastructure.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? Name { get; set; }
    }
}
