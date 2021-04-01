using SürücüKursu.BusinessLayer;
using SürücuKursu.Entities;
using SürücüKursu.Entitites.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SürücüKursu.WebApp.Controllers
{
    public class HomeController : Controller
    {
        string login;

        // GET: Home
        public ActionResult Index()
        {
            NoteManager nm = new NoteManager();
            return View(nm.GetAllNotes());
            //.OrderByDescending(x => x.ModifiedOn).ToList()) ;
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                KursManager km = new KursManager();
                Repository<SürücüKursuUser> repo_user = new Repository<SürücüKursuUser>();
                SürücüKursuUser user = repo_user.Find(x => x.Username == model.Username || x.Password == model.Password);
                try
                {
                    km.LoginUser(model);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    ModelState.AddModelError("", ex.Message);
                }
                Session["login"] = model.Username;
                if (user.IsAdmin == true)
                {
                    Session["isadmin"] = "yönetici";
                }
                else
                {
                    Session["isadmin"] = "kullanici";
                }
                //ViewData["login"] = "ahmet";
                //Session.Add("login", model);
                //ViewBag.login = "bir şey";
                //var mesaj = ViewData["loginismi"];
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
            // db kullanıcı getir
            // su user = db user
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                KursManager km = new KursManager();
                SürücüKursuUser user = null;
                try
                {
                    km.RegisterUser(model);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    ModelState.AddModelError("", ex.Message);
                }
                return RedirectToAction("RegisterOk");
            }
            return View(model);
        }
        public ActionResult RegisterOk()
        {
            return View();
        }
    }
}