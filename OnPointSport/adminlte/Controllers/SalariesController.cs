using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnPointSport.Core.Models;
using OnPointSport.Core.Interfaces;

namespace adminlte.Controllers
{
    public class SalariesController : Controller
    {
        private ISalaryRepository salaryRepository;
        private IEmployeeRepository employeeRepository;
        public SalariesController(ISalaryRepository salaryRepository, IEmployeeRepository employeeRepository)
        {
            this.salaryRepository = salaryRepository;
            this.employeeRepository = employeeRepository;
        }
        // GET: Salaries
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SalariesInformation()
        {
            ViewBag.employees = employeeRepository.GetEmployees();
            var salaries = salaryRepository.GetFullSalaries(salaryRepository.GetSalaries(), employeeRepository);
            return View(salaries);
        }
        [HttpGet]
        public ActionResult SalariesInformation(Boolean ActiveSearch = true, string search = "")
        {
            ViewBag.employees = employeeRepository.GetEmployees();
            var salaries = salaryRepository.GetFullSalaries(salaryRepository.GetSalaries(), employeeRepository)
                .Where(x => (x.Code.Contains(search) || 
                             x.EmployeeName.Contains(search)) && 
                             x.Active == ActiveSearch
                  ).ToList(); 
            return View(salaries);
        }
        
        [HttpPost]
        public ActionResult CreateSalary(string Code = "", string EmployeeCode = "", float BasicSalary = 0, bool Active = true, string Description = "")
        {
            var salary = salaryRepository.GetByCode(Code) == null ? new OnPointSport.Core.Domain.Salary() : salaryRepository.GetByCode(Code);
            salary.Code = salary.Id == 0 ? GetCode() : Code;
            salary.EmployeeCode = EmployeeCode;
            salary.BasicSalary = BasicSalary;
            salary.Active = Active;
            salary.Description = Description;

            salaryRepository.Save(salary);
            return Json(JsonRequestBehavior.AllowGet);
        }
        private string GetCode()
        {
            var lastSalaries = salaryRepository.GetSalaries().Count == 0 ? null : salaryRepository.GetSalaries().Last();
            string code = lastSalaries == null ? (1).ToString("0000000000") : (Convert.ToInt64(lastSalaries.Code) + 1).ToString("0000000000");
            return code;
        }
    }
}