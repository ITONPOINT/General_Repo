using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnPointSport.Core.Models;
using OnPointSport.Core.Interfaces;

namespace adminlte.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryRepository categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoriesInformation()
        {
            var categories = categoryRepository.GetCategories();
            return View(categories);
        }

        [HttpGet]
        public ActionResult CategoriesInformation(Boolean ActiveSearch = true, string search = "")
        {
            var categories = categoryRepository.GetCategories()
                .Where(x => (x.Code.Contains(search) ||
                             x.Name.Contains(search)) && 
                             x.Active == ActiveSearch
                  ).ToList();
            return View(categories);
        }

        [HttpPost]
        public ActionResult CreateCategory(string Code = "", string Name = "", bool Active = true, string Description = "")
        {
            var category = categoryRepository.GetByCode(Code) == null ? new OnPointSport.Core.Domain.Category() : categoryRepository.GetByCode(Code);
            category.Code = category.Id == 0 ? GetCode() : Code;
            category.Name = Name;
            category.Active = Active;
            category.Description = Description;
            categoryRepository.Save(category);
            return Json(JsonRequestBehavior.AllowGet);
        }
        private string GetCode()
        {
            var lastCategorys = categoryRepository.GetCategories().Count == 0 ? null : categoryRepository.GetCategories().Last();
            string code = lastCategorys == null ? (1).ToString("0000000000") : (Convert.ToInt64(lastCategorys.Code) + 1).ToString("0000000000");
            return code;
        }
    }
}