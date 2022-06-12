using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projek_PBO_Catfish_2022.Models
{
    public class Perawatan : Aktivitas
    {
        public Perawatan(string id, string tanggal, string id_karyawan, string id_kolam) : base(id, tanggal)
        {

        }

    }


}