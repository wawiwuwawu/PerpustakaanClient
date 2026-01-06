using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace client.Models
{
    [XmlType("AnggotaDTO")]
    public class AnggotaModel
    {
        public int id_anggota { get; set; } // Sesuai kolom di SQL 
        public string nama_anggota { get; set; }
        public string alamat { get; set; }
        public string telp { get; set; }
        public DateTime? tanggal_daftar { get; set; }
    }
}