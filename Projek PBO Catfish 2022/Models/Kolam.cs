using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projek_PBO_Catfish_2022.Models
{
    public class Kolam : SqlDBHelper
    {
        public string id;
        public string nama;
        public string jumlah;
        public string id_lele;

        //konstruktor => method tapi pake nama class itu
        public Kolam(string id, string nama, string jumlah,string id_lele )
        {
            this.id = id;
            this.nama = nama;
            this.jumlah = jumlah;
            this.id_lele = id_lele;
        }

    }
}