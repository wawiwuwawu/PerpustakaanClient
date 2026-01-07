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
            // Validasi login sederhana (hardcoded - bisa diganti dengan API login nanti)
            if (model.Username == "admin" && model.Password == "admin123")
            {
                // Simpan session lengkap
                Session["Username"] = model.Username;
                Session["nama_user"] = "Administrator"; // Nama lengkap user
                Session["id_user"] = 1; // ID user (hardcoded untuk admin)
                Session["Role"] = "admin"; // Role: admin atau petugas
                
                return RedirectToAction("Dashboard");
            }
            else if (model.Username == "petugas" && model.Password == "petugas123")
            {
                // Login sebagai petugas
                Session["Username"] = model.Username;
                Session["nama_user"] = "Petugas 1"; // Nama lengkap user
                Session["id_user"] = 2; // ID user petugas
                Session["Role"] = "petugas"; // Role petugas
                
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