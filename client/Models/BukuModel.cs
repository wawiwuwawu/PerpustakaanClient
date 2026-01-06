using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace client.Models
{
    [XmlType("BukuDTO", Namespace = "http://schemas.datacontract.org/2004/07/PerpustakaanAPI.Models")]
    public class BukuModel
    {
        public int id_buku { get; set; } // Sesuai kolom id_buku di SQL 
        public string kode_buku { get; set; }
        public string judul_buku { get; set; }
        public string penulis { get; set; }
        public int? id_kategori { get; set; }
        public int? stok { get; set; }
        public int? stok_minimal { get; set; }
        
        // Property untuk nested object kategori dari API
        public KategoriModel kategori { get; set; }
    }
}