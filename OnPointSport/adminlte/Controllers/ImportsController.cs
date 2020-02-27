using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnPointSport.Core.Models;
using OnPointSport.Core.Interfaces;

namespace adminlte.Controllers
{
    public class ImportsController : Controller
    {
        private IImportRepository importRepository;
        private ISupplierRepository supplierRepository;
        private IDiscountRepository discountRepository;
        private IProductServiceRepository productServiceRepository;
        public ImportsController(IImportRepository importRepository, ISupplierRepository supplierRepository, IDiscountRepository discountRepository, IProductServiceRepository productServiceRepository)
        {
            this.importRepository = importRepository;
            this.supplierRepository = supplierRepository;
            this.discountRepository = discountRepository;
            this.productServiceRepository = productServiceRepository;
        }

        // GET: Imports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ImportInformations()
        {
            var imports = importRepository.GetImports();
            return View(importRepository);
        }
        [HttpGet]
        public ActionResult ImportInformations(Boolean Active = true, string search = "")
        {
            var imports = importRepository.GetFullImports(importRepository.GetImports(), supplierRepository, discountRepository).Where(x => (x.Code.Contains(search))
            && x.Active == Active);
            return View(imports);
        }
        public ActionResult CreateImport(string Code = "")
        {
            var model = new Import();
            var import = importRepository.GetByCode(Code);
            var suppliers = supplierRepository.GetSuppliers().Where(x => x.Active == true).ToList();
            var discounts = discountRepository.GetDiscounts().Where(x => x.Active == true).ToList();
            var productServices = productServiceRepository.GetProductServices().Where(x => x.Active == true).ToList();

            ViewBag.suppliers = suppliers;
            ViewBag.discounts = discounts;
            ViewBag.productServices = productServices;
            if(import != null)
            {
                model.Id = import.Id;
                model.Code = import.Code;
                model.SupplierCode = import.SupplierCode;
                model.DiscountCode = import.DiscountCode;
                model.TotalPrice = import.TotalPrice;
                model.Active = import.Active;
                model.Description = import.Description;
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateImport(Import model)
        {
            if(ModelState.IsValid)
            {
                var import = importRepository.GetByCode(model.Code) == null ? new OnPointSport.Core.Domain.Import() : importRepository.GetByCode(model.Code);
                import.Code = import.Id == 0 ? GetCode() : model.Code;
                import.SupplierCode = model.SupplierCode;
                import.DiscountCode = model.DiscountCode;
                import.TotalPrice = model.TotalPrice;
                import.Active = model.Active;
                import.Description = model.Description;

                importRepository.Save(import);
                return Redirect("ImportInformations");
            }
            return View(model);
        }
        private string GetCode()
        {
            var lastImports = importRepository.GetImports().Count == 0 ? null : importRepository.GetImports().Last();
            string code = lastImports == null ? (1).ToString("0000000000") : (Convert.ToInt64(lastImports.Code) + 1).ToString("0000000000");
            return code;
        }
    }
}