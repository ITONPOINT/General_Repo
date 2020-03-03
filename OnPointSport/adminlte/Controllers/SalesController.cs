using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnPointSport.Core.Models;
using OnPointSport.Core.Interfaces;

namespace adminlte.Controllers
{
    public class SalesController : Controller
    {
        private ISaleReposity saleReposity;
        private ICustomerRepository customerRepository;
        private IDiscountRepository discountRepository;
        private IProductServiceRepository productServiceRepository;
        private IItemDetailRepository itemDetailRepository;
        public SalesController(ISaleReposity saleReposity, ICustomerRepository customerRepository, IDiscountRepository discountRepository, IProductServiceRepository productServiceRepository, IItemDetailRepository itemDetailRepository)
        {
            this.saleReposity = saleReposity;
            this.customerRepository = customerRepository;
            this.discountRepository = discountRepository;
            this.productServiceRepository = productServiceRepository;
            this.itemDetailRepository = itemDetailRepository;
        }

        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaleInformations()
        {
            var sales = saleReposity.GetSales();
            return View(saleReposity);
        }
        [HttpGet]
        public ActionResult SaleInformations(Boolean Active = true, string search = "")
        {
            var sales = saleReposity.GetFullSales(saleReposity.GetSales(), customerRepository, discountRepository).Where(x => (x.Code.Contains(search))
            && x.Active == Active);
            return View(sales);
        }
        public ActionResult CreateSale(string Code = "")
        {
            var model = new Sale();
            var sale = saleReposity.GetByCode(Code);
            var customers = customerRepository.GetCustomers().Where(x => x.Active == true).ToList();
            var discounts = discountRepository.GetDiscounts().Where(x => x.Active == true).ToList();
            var productServices = productServiceRepository.GetProductServices().Where(x => x.Active == true).ToList();
            var ItemDetails = itemDetailRepository.GetItemDetails().Where(x=>x.SaleCode=="20");

            ViewBag.customers = customers;
            ViewBag.discounts = discounts;
            ViewBag.productServices = productServices;
            ViewBag.ItemDetails = ItemDetails;
            if (sale != null)
            {
                model.Id = sale.Id;
                model.Code = sale.Code;
                model.CustomerCode = sale.CustomerCode;
                model.DiscountCode = sale.DiscountCode;
                model.TotalPrice = sale.TotalPrice;
                model.Active = sale.Active;
                model.Description = sale.Description;
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public ActionResult CreateSale(Sale model)
        {
            if(ModelState.IsValid)
            {
                var sale = saleReposity.GetByCode(model.Code) == null ? new OnPointSport.Core.Domain.Sale() : saleReposity.GetByCode(model.Code);
                sale.Code = sale.Id == 0 ? GetSaleCode() : model.Code;
                sale.CustomerCode = model.CustomerCode;
                sale.DiscountCode = model.DiscountCode;
                sale.TotalPrice = model.TotalPrice;
                sale.Active = model.Active;
                sale.Description = model.Description;

                saleReposity.Save(sale);
                return Redirect("SaleInformations");
            }
            return View(model);
        }
        private string GetSaleCode()
        {
            var lastSales = saleReposity.GetSales().Count == 0 ? null : saleReposity.GetSales().Last();
            string code = lastSales == null ? (1).ToString("0000000000") : (Convert.ToInt64(lastSales.Code) + 1).ToString("0000000000");
            return code;
        }
        private string GetItemCode(int lastCode)
        {
            var lastitem = itemDetailRepository.GetItemDetails().Count == 0 ? null : itemDetailRepository.GetItemDetails().Last();
            string code = lastitem == null ? (lastCode).ToString("0000000000") : (Convert.ToInt64(lastitem.Code) + lastCode).ToString("0000000000");
            return code;
        }

        [HttpPost]
        public JsonResult assignVal(ItemDetail model)
        {
            return new JsonResult { Data = model };
        }

        [HttpPost]
        public JsonResult Save(List<ItemDetail> items)
        {
            bool getStatus = true;
            var lastitem = itemDetailRepository.GetItemDetails().Count == 0 ? null : itemDetailRepository.GetItemDetails().Last();
            int lastcode = lastitem == null ? 1 : Convert.ToInt16(lastitem.Code);

            foreach(var item in items)
            {
                var itemDetail = new OnPointSport.Core.Domain.ItemDetail();
                itemDetail.Code = item.Code == "0" ? lastcode.ToString("0000000000") : item.Code;
                itemDetail.SaleCode = item.SaleCode == "0" ? GetSaleCode() : item.SaleCode;
                itemDetail.ProductServiceCode = item.ProductServiceCode;
                itemDetail.Quantity = item.Quantity;
                itemDetail.UnitPrice = item.UnitPrice;
                itemDetail.SubTotalPrice = item.SubTotalPrice;
                itemDetail.Active = item.Active;
                itemDetail.Description = item.Description;

                itemDetailRepository.Save(itemDetail);
                lastcode++;
            }

            return new JsonResult { Data = new { status = getStatus } };
        }
    }
}