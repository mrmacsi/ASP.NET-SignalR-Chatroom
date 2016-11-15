using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myChat.Models.DB;
using myChat.BL;

namespace myChat.Controllers
{
    public class HomeController : Controller
    {

        ChatProcess ctprss = new ChatProcess();
        
        public ActionResult Index()
        {
            return View("SignUp");
        }

        public ActionResult anasayfa()
        {
            return View();
        }

        public JsonResult SignUp(User user)
        {

            return Json(ctprss.createUser(user));
        }
        //sistemde kayıt var mı kontrol ediliyor
        public ActionResult Login(string user, string pass)
        {
            if (ctprss.loginCheck(user, pass)>0)
            {
                return View("anasayfa");

            }
            else
            {
                return View("Login");
            }
        }

        public JsonResult sohbetKayit(GroupChat grpchat)
        {
            return Json(ctprss.grupchatKaydet(grpchat));
        }

        public JsonResult userListGetir()
        {
            return Json(ctprss.userListGetir());
        }

        public JsonResult groupListGetir()
        {
            return Json(ctprss.groupListGetir());
        }

        

    }
}