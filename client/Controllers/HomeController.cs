using client.Models;
using client.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace client.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home (Login Page)
        public ActionResult Index()
        {
            // Jika sudah login, redirect ke Dashboard
            if (Session["Username"] != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(UserLoginModel model)
        {
            // Validasi login sederhana (hardcoded)
            if (model.Username == "admin" && model.Password == "admin123")
            {
                // Simpan session
                Session["Username"] = model.Username;
                Session["Role"] = "Administrator Perpustakaan";
                
                return RedirectToAction("Dashboard");
            }
            else
            {
                // Login gagal
                ViewBag.ErrorMessage = "Username atau password salah!";
                return View("Index", model);
            }
        }

        // GET: Dashboard (setelah login) - PROTECTED
        [CustomAuthorize]
        public ActionResult Dashboard()
        {
            return View();
        }

        // GET: Logout
        public ActionResult Logout()
        {
            // Hapus session
            Session.Clear();
            Session.Abandon();
            
            return RedirectToAction("Index");
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
    }
}