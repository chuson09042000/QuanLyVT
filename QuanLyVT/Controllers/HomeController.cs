using QuanLyVT.Common;
using QuanLyVT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyVT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login loginmodel)
        {
            //ViewBag.Message = "Your contact page.";
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(loginmodel.Username, loginmodel.Password);
                if (result)
                {
                    var user = dao.GetByID(loginmodel.Username);
                    var userSession = new UserLogin();
                    userSession.UserName = user.Ma_Nguoi_Dung;
                    userSession.UserID = user.ID_NGUOI_DUNG;
                    Session.Add(Constants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại!");
                }
            }


            return View();
            //return View();
        }
    }
}