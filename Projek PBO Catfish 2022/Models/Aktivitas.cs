using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projek_PBO_Catfish_2022.Models
{

    public class Aktivitas
    {
        string id;
        string tanggal;
        public Aktivitas(string id, string tanggal)
        {
            this.id       = id;
            this.tanggal = tanggal;
        }
    }
}