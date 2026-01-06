using client.helper;
using client.Models;
using client.Scripts.service;
using client.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace client.Controllers
{
    [CustomAuthorize]
    public class AnggotaController : Controller
    {
        // Tampil Daftar Anggota
        public async Task<ActionResult> Index()
        {
            HttpClient client = ApiService.GetClient();
            var response = await client.GetAsync("api/anggota");
            string xml = await response.Content.ReadAsStringAsync();
            var data = XmlHelper.ToAnggotaList(xml);
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(AnggotaModel m)
        {
            HttpClient client = ApiService.GetClient();
            await client.PostAsXmlAsync("api/anggota", m);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HttpClient client = ApiService.GetClient();
            await client.DeleteAsync("api/anggota?id=" + id);
            return RedirectToAction("Index");
        }
    }
}