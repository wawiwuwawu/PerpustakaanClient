using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace client.Models
{
    public class UserModel
    {
        public int id_user { get; set; } // Sesuai kolom di SQL 
        public string username { get; set; }
        public string nama_lengkap { get; set; }
        public string role { get; set; }
    }
}