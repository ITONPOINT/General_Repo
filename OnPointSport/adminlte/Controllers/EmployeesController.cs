using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnPointSport.Core.Models;
using OnPointSport.Core.Interfaces;
using System.Web.UI;

namespace adminlte.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeeRepository employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmployeesInformation()
        {
            var employees = employeeRepository.GetEmployees();
            return View(employees);
        }

        [HttpGet]
        public ActionResult EmployeesInformation(Boolean Active = true, string search = "")
        {
            var employees = employeeRepository.GetEmployees().Where(x => (x.Code.Contains(search) || x.IdCard.Contains(search) ||
                x.Name.Contains(search) || x.GenderName.Contains(search) || x.Phone.Contains(search) || x.Email.Contains(search)) && x.Active == Active).ToList();

            return View(employees);
        }
        public ActionResult CreateEmployee(string Code = "")
        {
            var model = new Employee();
            var employee = employeeRepository.GetByCode(Code);
            if (employee != null)
            {
                model.Id = employee.Id;
                model.Code = employee.Code;
                model.IdCard = employee.IdCard;
                model.Name = employee.Name;
                model.Gender = employee.Gender;
                model.DateOfBirth = employee.DateOfBirth;
                model.Phone = employee.Phone;
                model.Email = employee.Email;
                model.Address = employee.Address;
                model.Active = employee.Active;
                model.Description = employee.Description;
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee model)
        {

            if (ModelState.IsValid)
            {
                var employee = employeeRepository.GetByCode(model.Code) == null ? new OnPointSport.Core.Domain.Employee() : employeeRepository.GetByCode(model.Code);
                employee.Code = employee.Id == 0 ? GetCode() : model.Code;
                employee.IdCard = model.IdCard;
                employee.Name = model.Name;
                employee.Gender = model.Gender;
                employee.DateOfBirth = model.DateOfBirth;
                employee.Phone = model.Phone;
                employee.Email = model.Email;
                employee.Address = model.Address;
                employee.Active = model.Active;
                employee.Description = model.Description;

                employeeRepository.Save(employee);
                return Redirect("EmployeesInformation");
            }
            return View(model);
        }
        private string GetCode()
        {
            var lastEmployees = employeeRepository.GetEmployees().Count == 0 ? null : employeeRepository.GetEmployees().Last();
            string code = lastEmployees == null ? (1).ToString("0000000000") : (Convert.ToInt64(lastEmployees.Code) + 1).ToString("0000000000");
            return code;
        }

    }
}