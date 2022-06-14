using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Projek_PBO_Catfish_2022.Models
{

    public class Aktivitas : SqlDBHelper
    {
        public string id;
        public string tanggal;
        public Aktivitas(string id=null, string tanggal=null)
        {
            this.id       = id;
            this.tanggal  = tanggal;
        }

        public string getTanggal() { return tanggal; }
        public string getId() { return id; }

        public virtual void createAktivitas() { }
        public virtual DataTable readAktivitas() {
            string query = "SELECT * FROM aktivitas";
            DataTable dt = ExecuteQuery(query);
            return dt;
        }
        public virtual void updateAktivitas() { }
        public virtual void deleteAktivitas() { }

    }
}