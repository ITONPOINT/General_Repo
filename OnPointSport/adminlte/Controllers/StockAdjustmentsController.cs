using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnPointSport.Core.Models;
using OnPointSport.Core.Interfaces;

namespace adminlte.Controllers
{
    public class StockAdjustmentsController : Controller
    {
        private IStockAdjustmentRepository stockAdjustmentRepository;
        private IProductServiceRepository productServicesRepository;
        public StockAdjustmentsController(IStockAdjustmentRepository stockAdjustmentRepository, IProductServiceRepository productServiceRepository)
        {
            this.stockAdjustmentRepository = stockAdjustmentRepository;
            this.productServicesRepository = productServiceRepository;
        }

        // GET: StockAdjustment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StockAdjustmentsInformation()
        {
            ViewBag.productServices = productServicesRepository.GetProductServices();
            var stockAdjustments = stockAdjustmentRepository.GetFullStockAdjustments(stockAdjustmentRepository.GetStockAdjustments(), productServicesRepository);
            return View(stockAdjustments);
        }
        [HttpGet]
        public ActionResult StockAdjustmentsInformation(Boolean ActiveSearch = true, string search = "")
        {
            ViewBag.productServices = productServicesRepository.GetProductServices(); // Asign ProductService Data View

            var stockAdjustments = stockAdjustmentRepository.GetFullStockAdjustments(stockAdjustmentRepository.GetStockAdjustments(), productServicesRepository)
                .Where(x => (x.Code.Contains(search) || 
                             x.ProductServiceName.Contains(search)) && 
                             x.Active == ActiveSearch
                  ).ToList();
            return View(stockAdjustments);
        }

        [HttpPost]
        public ActionResult CreateStockAdjustment(string Code = "", string ProductServiceName = "", double Quantity = 0, bool Active = true, string ProductServiceCode = "", string Description = "")
        {
            var stockAdjustment = stockAdjustmentRepository.GetByCode(Code) == null ? new OnPointSport.Core.Domain.StockAdjustment() : stockAdjustmentRepository.GetByCode(Code);
            stockAdjustment.Code = stockAdjustment.Id == 0 ? GetCode() : Code;
            stockAdjustment.ProductServiceCode = ProductServiceCode;
            stockAdjustment.Quantity = Quantity;
            stockAdjustment.Active = Active;
            stockAdjustment.Description = Description;
            stockAdjustmentRepository.Save(stockAdjustment);
            return Json(JsonRequestBehavior.AllowGet);
            
        }
        private string GetCode()
        {
            var lastEntity = stockAdjustmentRepository.GetStockAdjustments().Count == 0 ? null : stockAdjustmentRepository.GetStockAdjustments().Last();
            string code = lastEntity == null ? (1).ToString("0000000000") : (Convert.ToInt64(lastEntity.Code) + 1).ToString("0000000000");
            return code;
        }
    }
}