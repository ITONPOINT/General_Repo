using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPointSport.Core.Domain
{
    public class Salary: AuditableEntity
    {
        public string Code { get; set; }
        public string EmployeeCode { get; set; }
        public float BasicSalary { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
