using System;
using System.Xml.Serialization;

namespace client.Models
{
    [XmlType("PeminjamanDTO")]
    public class PeminjamanModel
    {
        public int id_pinjam { get; set; }
        public int? id_anggota { get; set; }
        public int? id_user { get; set; }
        public int? id_buku { get; set; }
        public DateTime? tanggal_pinjam { get; set; }
        public DateTime? tanggal_kembali { get; set; }
        public string status { get; set; }
        
        // Nested objects dari API
        [XmlElement("anggota")]
        public AnggotaModel anggota { get; set; }
        
        [XmlElement("petugas")]
        public UserModel petugas { get; set; }
        
        [XmlElement("buku")]
        public BukuModel buku { get; set; }
    }
}
