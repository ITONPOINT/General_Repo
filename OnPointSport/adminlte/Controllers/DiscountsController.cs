using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnPointSport.Core.Models;
using OnPointSport.Core.Interfaces;

namespace adminlte.Controllers
{
    public class DiscountsController : Controller
    {
        private IDiscountRepository discountRepository;
        public DiscountsController(IDiscountRepository discountRepository)
        {
            this.discountRepository = discountRepository;
        }

        // GET: Discount
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DiscountsInformation()
        {
            var discounts = discountRepository.GetDiscounts();
            return View(discounts);
        }

        [HttpGet]
        public ActionResult DiscountsInformation(Boolean Active = true, string search = "")
        {
            var discounts = discountRepository.GetDiscounts().Where(x => (x.Code.Contains(search) || x.Name.Contains(search)) &&
            x.Active == Active).ToList();
            return View(discounts);
        }
        public ActionResult CreateDiscount(string Code = "")
        {
            var model = new Discount();
            var discount = discountRepository.GetByCode(Code);
            if(discount != null)
            {
                model.Id = discount.Id;
                model.Code = discount.Code;
                model.Name = discount.Name;
                model.Debut = discount.Debut;
                model.Fin = discount.Fin;
                model.Rate = discount.Rate;
                model.Active = discount.Active;
                model.Description = discount.Description;
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public ActionResult CreateDiscount(Discount model)
        {
            if(ModelState.IsValid)
            {
                var discount = discountRepository.GetByCode(model.Code) == null ? new OnPointSport.Core.Domain.Discount() : discountRepository.GetByCode(model.Code);
                discount.Code = discount.Id == 0 ? GetCode() : model.Code;
                discount.Name = model.Name;
                discount.Debut = model.Debut;
                discount.Fin = model.Fin;
                discount.Rate = model.Rate;
                discount.Active = model.Active;
                discount.Description = model.Description;

                discountRepository.Save(discount);
                return Redirect("DiscountsInformation");
            }
            return View(model);
        }
        private string GetCode()
        {
            var lastDiscounts = discountRepository.GetDiscounts().Count == 0 ? null : discountRepository.GetDiscounts().Last();
            string code = lastDiscounts == null ? (1).ToString("0000000000") : (Convert.ToInt64(lastDiscounts.Code) + 1).ToString("0000000000");
            return code;
        }
    }
}