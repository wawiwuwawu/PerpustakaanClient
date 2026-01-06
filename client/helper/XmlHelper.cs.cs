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
            var serializer = new XmlSerializer(
                typeof(List<KategoriModel>), 
                new XmlRootAttribute("ArrayOfKategoriDTO") 
                { 
                    Namespace = "http://schemas.datacontract.org/2004/07/PerpustakaanAPI.Models" 
                }
            );
            using (StringReader reader = new StringReader(xml))
            {
                return (List<KategoriModel>)serializer.Deserialize(reader);
            }
        }

        // Untuk data Buku (Penting untuk Perpustakaan)
        public static List<BukuModel> ToBukuList(string xml)
        {
            var serializer = new XmlSerializer(
                typeof(List<BukuModel>), 
                new XmlRootAttribute("ArrayOfBukuDTO") 
                { 
                    Namespace = "http://schemas.datacontract.org/2004/07/PerpustakaanAPI.Models" 
                }
            );
            using (StringReader reader = new StringReader(xml))
            {
                return (List<BukuModel>)serializer.Deserialize(reader);
            }
        }

        // Untuk data Anggota
        public static List<AnggotaModel> ToAnggotaList(string xml)
        {
            var serializer = new XmlSerializer(
                typeof(List<AnggotaModel>), 
                new XmlRootAttribute("ArrayOfAnggotaDTO") 
                { 
                    Namespace = "http://schemas.datacontract.org/2004/07/PerpustakaanAPI.Models" 
                }
            );
            using (StringReader reader = new StringReader(xml))
            {
                return (List<AnggotaModel>)serializer.Deserialize(reader);
            }
        }

        // Untuk single Buku (Get by ID)
        public static BukuModel ToBuku(string xml)
        {
            var serializer = new XmlSerializer(
                typeof(BukuModel), 
                new XmlRootAttribute("BukuDTO") 
                { 
                    Namespace = "http://schemas.datacontract.org/2004/07/PerpustakaanAPI.Models" 
                }
            );
            using (StringReader reader = new StringReader(xml))
            {
                return (BukuModel)serializer.Deserialize(reader);
            }
        }

        // Untuk single Kategori (Get by ID)
        public static KategoriModel ToKategori(string xml)
        {
            var serializer = new XmlSerializer(
                typeof(KategoriModel), 
                new XmlRootAttribute("KategoriDTO") 
                { 
                    Namespace = "http://schemas.datacontract.org/2004/07/PerpustakaanAPI.Models" 
                }
            );
            using (StringReader reader = new StringReader(xml))
            {
                return (KategoriModel)serializer.Deserialize(reader);
            }
        }

        // Untuk single Anggota (Get by ID)
        public static AnggotaModel ToAnggota(string xml)
        {
            var serializer = new XmlSerializer(
                typeof(AnggotaModel), 
                new XmlRootAttribute("AnggotaDTO") 
                { 
                    Namespace = "http://schemas.datacontract.org/2004/07/PerpustakaanAPI.Models" 
                }
            );
            using (StringReader reader = new StringReader(xml))
            {
                return (AnggotaModel)serializer.Deserialize(reader);
            }
        }
    }
}