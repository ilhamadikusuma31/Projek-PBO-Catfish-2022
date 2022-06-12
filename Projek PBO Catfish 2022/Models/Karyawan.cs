using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projek_PBO_Catfish_2022.Models
{

    public class Karyawan
    {
        string id;
        string nama_lengkap;
        string alamat;
        string no_telpon;
        public Karyawan(string id, string nama_lengkap, string alamat, string no_telpon)
        {
            this.id = id;
            this.nama_lengkap = nama_lengkap;
            this.alamat = alamat;
            this.no_telpon = no_telpon;
        }

    }
}