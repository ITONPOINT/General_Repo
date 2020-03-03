using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnPointSport.Core.Models;
using OnPointSport.Core.Interfaces;

namespace adminlte.Cotrollers
{
    public class UsersController : Controller
    {

        private IUserRepository userRepository;
        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserInformation()
        {
            var users = userRepository.GetUsers();
            return View(users);
        }

        [HttpGet]
        public ActionResult UserInformation(Boolean ActiveSearch = true, string search = "")
        {
            var users = userRepository.GetUsers().Where(x => (x.Code.Contains(search) ||
            x.Name.Contains(search)) && x.Active == ActiveSearch).ToList();

            return View(users);
        }
        
        [HttpPost]
        public ActionResult CreateUser(string Code = "", bool Active = true, string Name = "", string Password = "", string Description = "")
        {
            var user = userRepository.GetByCode(Code) == null ? new OnPointSport.Core.Domain.User() : userRepository.GetByCode(Code);
            user.Code = user.Id == 0 ? GetCode() : Code;
            user.Name = Name;
            user.Password = Password;
            user.Active = Active;
            user.Description = Description;
            userRepository.Save(user);
            return Json(JsonRequestBehavior.AllowGet);
        }

        private string GetCode()
        {
            var lastUser = userRepository.GetUsers().Count == 0 ? null : userRepository.GetUsers().Last();
            string code = lastUser == null ? (1).ToString("0000000000") : (Convert.ToInt64(lastUser.Code) + 1).ToString("0000000000");
            return code;
        }

    }
}