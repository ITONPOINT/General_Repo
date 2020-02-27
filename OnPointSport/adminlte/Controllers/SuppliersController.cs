using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnPointSport.Core.Models;
using OnPointSport.Core.Interfaces;

namespace adminlte.Controllers
{
    public class SuppliersController : Controller
    {
        private ISupplierRepository supplierRepository;
        public SuppliersController(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SuppliersInformation()
        {
            var suplliers = supplierRepository.GetSuppliers();
            return View(supplierRepository);
        }

        [HttpGet]
        public ActionResult SuppliersInformation(Boolean Active = true, string search = "")
        {
            var suppliers = supplierRepository.GetSuppliers().Where(x => (x.Code.Contains(search) ||
            x.Name.Contains(search) || x.Email.Contains(search) || x.Phone.Contains(search)) && x.Active == Active).ToList();
            return View(suppliers);
        }
        public ActionResult CreateSupplier(string Code = "")
        {
            var model = new Supplier();
            var supplier = supplierRepository.GetByCode(Code);
            if(supplier != null)
            {
                model.Id = supplier.Id;
                model.Code = supplier.Code;
                model.Name = supplier.Name;
                model.Phone = supplier.Phone;
                model.Phone2 = supplier.Phone2;
                model.Email = supplier.Email;
                model.Address = supplier.Address;
                model.Active = supplier.Active;
                model.Description = supplier.Description;
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateSupplier(Supplier model)
        {
            if(ModelState.IsValid)
            {
                var supplier = supplierRepository.GetByCode(model.Code) == null ? new OnPointSport.Core.Domain.Supplier() : supplierRepository.GetByCode(model.Code);
                supplier.Code = supplier.Id == 0 ? GetCode() : model.Code;
                supplier.Name = model.Name;
                supplier.Phone = model.Phone;
                supplier.Phone2 = model.Phone2;
                supplier.Email = model.Email;
                supplier.Address = model.Address;
                supplier.Active = model.Active;
                supplier.Description = model.Description;

                supplierRepository.Save(supplier);
                return Redirect("SuppliersInformation");
            }
            return View(model);
        }
        private string GetCode()
        {
            var lastSuppliers = supplierRepository.GetSuppliers().Count == 0 ? null : supplierRepository.GetSuppliers().Last();
            string code = lastSuppliers == null ? (1).ToString("0000000000") : (Convert.ToInt64(lastSuppliers.Code) + 1).ToString("0000000000");
            return code;
        }
    }
}