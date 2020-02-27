using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnPointSport.Core.Models;
using OnPointSport.Core.Interfaces;

namespace adminlte.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerRepository customerRepository;
        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomersInformation()
        {
            var customers = customerRepository.GetCustomers();
            return View(customers);
        }
        
        [HttpGet]
        public ActionResult CustomersInformation(Boolean Active = true, string search = "")
        {
            var customers = customerRepository.GetCustomers().Where(x => (x.Code.Contains(search) ||
            x.Name.Contains(search) || x.GenderName.Contains(search)) && x.Active == Active).ToList();

            return View(customers);
        }
        public ActionResult CreateCustomer(string Code = "")
        {
            /*var user = userRepository.GetByCode(Code);
            if(user != null)
            {
                return View(user);
            }
            return View();
            */

            var model = new Customer();
            var customer = customerRepository.GetByCode(Code);
            if (customer != null)
            {
                model.Id = customer.Id;
                model.Code = customer.Code;
                model.Name = customer.Name;
                model.Gender = customer.Gender;
                model.Phone = customer.Phone;
                model.Email = customer.Email;
                model.Address = customer.Address;
                model.Active = customer.Active;
                model.Description = customer.Description;
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateCustomer(Customer model)
        {
            /*var user = userRepository.GetByCode(model.Code);
            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    userRepository.Update(model);
                }
                else
                {
                    userRepository.Save(model);
                }
                return Redirect("UserInformation");
            }
            return View(model);
            */
            if (ModelState.IsValid)
            {
                var editCustomer = customerRepository.GetByCode(model.Code);
                var newCustomer = new OnPointSport.Core.Domain.Customer();

                if (editCustomer != null)
                {
                    editCustomer.Code = model.Code;
                    editCustomer.Name = model.Name;
                    editCustomer.Gender = model.Gender;
                    editCustomer.Phone = model.Phone;
                    editCustomer.Email = model.Email;
                    editCustomer.Address = model.Address;
                    editCustomer.Active = model.Active;
                    editCustomer.Description = model.Description;

                    customerRepository.Save(editCustomer);
                    return Redirect("CustomersInformation");
                }

                newCustomer.Code = GetCode();
                newCustomer.Name = model.Name;
                newCustomer.Gender = model.Gender;
                newCustomer.Phone = model.Phone;
                newCustomer.Email = model.Email;
                newCustomer.Address = model.Address;
                newCustomer.Active = model.Active;
                newCustomer.Description = model.Description;

                customerRepository.Save(newCustomer);
                return Redirect("CustomersInformation");
            }
            return View(model);
        }
        private string GetCode()
        {
            var lastCustomers = customerRepository.GetCustomers().Count == 0 ? null : customerRepository.GetCustomers().Last();
            string code = lastCustomers == null ? (1).ToString("0000000000") : (Convert.ToInt64(lastCustomers.Code) + 1).ToString("0000000000");
            return code;
        }
    }
}