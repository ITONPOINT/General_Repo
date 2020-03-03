using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnPointSport.Core.Models
{
    public class Salary
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessage = "Please select Item!")]
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Please enter salary!")]
        public float BasicSalary { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
