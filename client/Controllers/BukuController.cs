using System.Net.Http; // Untuk HttpClient
using System.Threading.Tasks; // Untuk Task/Async
using System.Net.Http.Formatting; // WAJIB untuk PostAsXmlAsync
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
    public class BukuController : Controller
    {
        // Fungsi untuk mengambil data kategori dari API untuk Dropdown List
        private async Task LoadKategori()
        {
            HttpClient client = ApiService.GetClient();
            var response = await client.GetAsync("api/kategori");
            string xml = await response.Content.ReadAsStringAsync();
            var listKategori = XmlHelper.ToKategoriList(xml);
            // Simpan di ViewBag agar bisa dibaca di View (Create.cshtml)
            ViewBag.KategoriList = new SelectList(listKategori, "id_kategori", "nama_kategori");
        }

        // GET: Buku (Tampil Semua Buku)
        public async Task<ActionResult> Index(string search)
        {
            HttpClient client = ApiService.GetClient();
            
            // Jika ada parameter search, gunakan endpoint search
            string url = string.IsNullOrEmpty(search) 
                ? "api/buku" 
                : $"api/buku?search={search}";
            
            var response = await client.GetAsync(url);
            string xml = await response.Content.ReadAsStringAsync();
            var data = XmlHelper.ToBukuList(xml);
            
            // Simpan search keyword untuk ditampilkan di view
            ViewBag.SearchKeyword = search;
            
            return View(data);
        }

        // GET: Buku/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpClient client = ApiService.GetClient();
            var response = await client.GetAsync($"api/buku/{id}");
            
            if (!response.IsSuccessStatusCode)
            {
                return HttpNotFound();
            }
            
            string xml = await response.Content.ReadAsStringAsync();
            var buku = XmlHelper.ToBuku(xml);
            
            await LoadKategori();
            return View(buku);
        }

        // POST: Buku/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, BukuModel m)
        {
            HttpClient client = ApiService.GetClient();
            var response = await client.PutAsXmlAsync($"api/buku/{id}", m);
            
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            
            await LoadKategori();
            return View(m);
        }

        // GET: Buku/Create
        public async Task<ActionResult> Create()
        {
            await LoadKategori(); // Panggil fungsi dropdown
            return View();
        }

        // POST: Buku/Create
        [HttpPost]
        public async Task<ActionResult> Create(BukuModel m)
        {
            HttpClient client = ApiService.GetClient();
            var response = await client.PostAsXmlAsync("api/buku", m);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            await LoadKategori();
            return View(m);
        }

        // POST: Buku/Delete/5
        [HttpPost]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HttpClient client = ApiService.GetClient();
            await client.DeleteAsync("api/buku?id=" + id);
            return RedirectToAction("Index");
        }
    }
}