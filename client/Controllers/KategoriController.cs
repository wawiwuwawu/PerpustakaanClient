using System.Net.Http; // Untuk HttpClient
using System.Threading.Tasks; // Untuk Task/Async
using System.Net.Http.Formatting; // WAJIB untuk PostAsXmlAsync
using client.helper;
using client.Models;
using client.Scripts.service;
using client.Filters;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace client.Controllers
{
    [CustomAuthorize]
    public class KategoriController : Controller
    {
        // TAMPIL SEMUA KATEGORI
        public async Task<ActionResult> Index()
        {
            HttpClient client = ApiService.GetClient();
            var response = await client.GetAsync("api/kategori");
            string xml = await response.Content.ReadAsStringAsync();
            var data = XmlHelper.ToKategoriList(xml);
            return View(data);
        }

        // TAMBAH KATEGORI (VIEW)
        public ActionResult Create()
        {
            return View();
        }

        // TAMBAH KATEGORI (POST)
        [HttpPost]
        public async Task<ActionResult> Create(KategoriModel m)
        {
            HttpClient client = ApiService.GetClient();
            await client.PostAsXmlAsync("api/kategori", m);
            return RedirectToAction("Index");
        }

        // HAPUS KATEGORI
        public async Task<ActionResult> Delete(int id)
        {
            HttpClient client = ApiService.GetClient();
            await client.DeleteAsync("api/kategori?id=" + id);
            return RedirectToAction("Index");
        }
    }
}