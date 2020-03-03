using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnPointSport.Core.Models;
using OnPointSport.Core.Interfaces;
using Microsoft.Ajax.Utilities;
using System.Globalization;

namespace adminlte.Controllers
{
    public class ProductServicesController : Controller
    {
        private IProductServiceRepository productserviceRepository;
        private ICategoryRepository categoryRepository;

        public string Price { get; private set; }

        public ProductServicesController(IProductServiceRepository productserviceRepository,ICategoryRepository categoryRepository)
        {
            this.productserviceRepository = productserviceRepository;
            this.categoryRepository = categoryRepository;

        }

        // GET: ProductService
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductServiceInformation()
        {
            var productservices = productserviceRepository.GetProductServices();
            return View(productservices);
        }

        [HttpGet]
        public ActionResult ProductServicesInformation(Boolean Active = true, string search = "")
        {
            //var productservices = productservicesRepository.GetProductServices().Where(x => (x.Code.Contains(search) ||
            //x.Name.Contains(search)) && x.Active == Active).ToList();

            var productservices = productserviceRepository.GetFullProductServices(productserviceRepository.GetProductServices(), categoryRepository).Where
                (x => (x.Code.Contains(search) || x.Name.Contains(search) || x.CategoryName.Contains(search)) && x.Active == Active).ToList();

            return View(productservices);
        }
        public ActionResult CreateProductService(string Code = "")
        {
            var model = new ProductService();
            var productservice = productserviceRepository.GetByCode(Code);
            var categories = categoryRepository.GetCategories().Where(x => x.Active == true).ToList(); // Get data from category

            ViewBag.categories = categories; // asign category data to view

            if(productservice != null)
            {
                model.Id = productservice.Id;
                model.Code = productservice.Code;
                model.Name = productservice.Name;
                model.CategoryCode = productservice.CategoryCode;
                model.Quantity = productservice.Quantity;
                model.Price = productservice.Price;
                model.Active = productservice.Active;
                model.Description = productservice.Description;
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateProductService(ProductService model)
        {

            if (ModelState.IsValid)
            {
                var productService = productserviceRepository.GetByCode(model.Code) == null ? new OnPointSport.Core.Domain.ProductService() : productserviceRepository.GetByCode(model.Code);
                productService.Code = productService.Id == 0 ? GetCode() : model.Code;
                productService.Name = model.Name;
                productService.CategoryCode = model.CategoryCode;
                productService.Quantity = model.Quantity;
                productService.Price = model.Price;
                productService.Active = model.Active;
                productService.Description = model.Description;

                productserviceRepository.Save(productService);
                return Redirect("ProductServicesInformation");
            }
            return View(model);

        }
        private string GetCode()
        {
            var lastProductServices = productserviceRepository.GetProductServices().Count == 0 ? null : productserviceRepository.GetProductServices().Last();
            string code = lastProductServices == null ? (1).ToString("0000000000") : (Convert.ToInt64(lastProductServices.Code) + 1).ToString("0000000000");
            return code;
        }
        private void Price_Enter(object sender, EventArgs e)
        {
            //object Price = null;
            if (!string .IsNullOrEmpty(Price) || !string.IsNullOrWhiteSpace(Price))
            {
                var s = decimal.Parse(Price, NumberStyles.Currency);
                Price = s.ToString();
            }
        }
    }
}