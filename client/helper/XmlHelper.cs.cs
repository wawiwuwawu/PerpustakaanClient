using client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace client.helper
{
    public class XmlHelper
    {
        // Untuk data Kategori Buku
        public static List<KategoriModel> ToKategoriList(string xml)
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "ArrayOfKategoriDTO";
            xRoot.Namespace = "";  // Empty namespace
            
            var serializer = new XmlSerializer(typeof(List<KategoriModel>), xRoot);
            using (StringReader reader = new StringReader(xml))
            {
                return (List<KategoriModel>)serializer.Deserialize(reader);
            }
        }

        // Untuk data Buku (Penting untuk Perpustakaan)
        public static List<BukuModel> ToBukuList(string xml)
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "ArrayOfBukuDTO";
            xRoot.Namespace = "";  // Empty namespace karena API tidak menggunakan namespace
            
            var serializer = new XmlSerializer(typeof(List<BukuModel>), xRoot);
            using (StringReader reader = new StringReader(xml))
            {
                return (List<BukuModel>)serializer.Deserialize(reader);
            }
        }

        // Untuk data Anggota
        public static List<AnggotaModel> ToAnggotaList(string xml)
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "ArrayOfAnggotaDTO";
            xRoot.Namespace = "";  // Empty namespace
            
            var serializer = new XmlSerializer(typeof(List<AnggotaModel>), xRoot);
            using (StringReader reader = new StringReader(xml))
            {
                return (List<AnggotaModel>)serializer.Deserialize(reader);
            }
        }

        // Untuk single Buku (Get by ID)
        public static BukuModel ToBuku(string xml)
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "BukuDTO";
            xRoot.Namespace = "";  // Empty namespace
            
            var serializer = new XmlSerializer(typeof(BukuModel), xRoot);
            using (StringReader reader = new StringReader(xml))
            {
                return (BukuModel)serializer.Deserialize(reader);
            }
        }

        // Untuk single Kategori (Get by ID)
        public static KategoriModel ToKategori(string xml)
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "KategoriDTO";
            xRoot.Namespace = "";  // Empty namespace
            
            var serializer = new XmlSerializer(typeof(KategoriModel), xRoot);
            using (StringReader reader = new StringReader(xml))
            {
                return (KategoriModel)serializer.Deserialize(reader);
            }
        }

        // Untuk single Anggota (Get by ID)
        public static AnggotaModel ToAnggota(string xml)
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "AnggotaDTO";
            xRoot.Namespace = "";  // Empty namespace
            
            var serializer = new XmlSerializer(typeof(AnggotaModel), xRoot);
            using (StringReader reader = new StringReader(xml))
            {
                return (AnggotaModel)serializer.Deserialize(reader);
            }
        }

        // Untuk data Peminjaman (List)
        public static List<PeminjamanModel> ToPeminjamanList(string xml)
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "ArrayOfPeminjamanDTO";
            xRoot.Namespace = "";  // Empty namespace
            
            var serializer = new XmlSerializer(typeof(List<PeminjamanModel>), xRoot);
            using (StringReader reader = new StringReader(xml))
            {
                return (List<PeminjamanModel>)serializer.Deserialize(reader);
            }
        }

        // Untuk single Peminjaman (Get by ID)
        public static PeminjamanModel ToPeminjaman(string xml)
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "PeminjamanDTO";
            xRoot.Namespace = "";  // Empty namespace
            
            var serializer = new XmlSerializer(typeof(PeminjamanModel), xRoot);
            using (StringReader reader = new StringReader(xml))
            {
                return (PeminjamanModel)serializer.Deserialize(reader);
            }
        }
    }
}