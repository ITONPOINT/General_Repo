using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnPointSport.Core.Models;
using OnPointSport.Core.Interfaces;

namespace adminlte.Controllers
{
    public class ExchangeRatesController : Controller
    {
        private IExchangeRateRepository exchangeRateRepository;
        public ExchangeRatesController(IExchangeRateRepository exchangeRateRepository)
        {
            this.exchangeRateRepository = exchangeRateRepository;
        }

        // GET: ExchangeRate
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ExchangeRatesInformation()
        {
            var exchangeRates = exchangeRateRepository.GetExchangeRates();
            return View(exchangeRates);
        }

        [HttpGet]
        public ActionResult ExchangeRatesInformation(Boolean ActiveSearch = true, string search = "")
        {
            var exchangeRates = exchangeRateRepository.GetExchangeRates().Where(x => (x.Code.Contains(search) ||
            x.Name.Contains(search)) && x.Active == ActiveSearch).ToList();

            return View(exchangeRates);
        }

        [HttpPost]
        public ActionResult CreateExchangeRate(string Code = "", bool Active = true, string Name = "", float FromAmount = 0, float ToAmount = 0, string Description = "")
        {
            var exchangeRate = exchangeRateRepository.GetByCode(Code) == null ? new OnPointSport.Core.Domain.ExchangeRate() : exchangeRateRepository.GetByCode(Code);
            exchangeRate.Code = exchangeRate.Id == 0 ? GetCode() : Code;
            exchangeRate.Name = Name;
            exchangeRate.FromAmount = FromAmount;
            exchangeRate.ToAmount = ToAmount;
            exchangeRate.Active = Active;
            exchangeRate.Description = Description;
            exchangeRateRepository.Save(exchangeRate);
            return Json(JsonRequestBehavior.AllowGet);
        }
        private string GetCode()
        {
            var lastExchangeRates = exchangeRateRepository.GetExchangeRates().Count == 0 ? null : exchangeRateRepository.GetExchangeRates().Last();
            string code = lastExchangeRates == null ? (1).ToString("0000000000") : (Convert.ToInt64(lastExchangeRates.Code) + 1).ToString("0000000000");
            return code;
        }
    }
}