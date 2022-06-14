using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Data;

namespace Projek_PBO_Catfish_2022.Models
{
    public class Perawatan : Aktivitas
    {

        string id_karyawan;
        string id_kolam;
        string id_Perawatan;

        public Perawatan(string id = null, string tanggal = null, string id_karyawan = null, string id_kolam = null) : base(id, tanggal)
        {
            this.id_karyawan = id_karyawan;
            this.id_kolam = id_kolam;
            this.id_Perawatan = "2";
        }


        public override void createAktivitas()
        {
            string query = "INSERT INTO Aktivitas (tanggal,id_karyawan, id_kolam, id_jenis_aktivitas ) values ('{0}','{1}','{2}','{3}');";
            query = string.Format(query, getTanggal(), this.id_karyawan, this.id_kolam, this.id_Perawatan);
            ExecuteNonQuery(query);
        }

        public override DataTable readAktivitas()
        {
            //string query = "SELECT * FROM aktivitas p JOIN karyawan k ON p.id_karyawan = k.id_karyawan;";
            string query = @"SELECT * FROM 
                             kolam ko JOIN aktivitas a ON ko.id_kolam = a.id_kolam 
                             JOIN karyawan ka ON ka.id_karyawan = a.id_karyawan WHERE id_jenis_aktivitas = 2; ";
            DataTable dt = ExecuteQuery(query);
            return dt;
        }

        public override void updateAktivitas()
        {
            string query = @"UPDATE aktivitas 
                             SET 
                             tanggal            = @tgl,
                             id_karyawan        = @id_krywn::integer, 
                             id_kolam           = @id_klm::integer,
                             id_jenis_aktivitas = @id_p::integer,
                             WHERE 
                             id_aktivitas = @id_aktvts::integer;";
            ExecuteNonQuery(query,
                new NpgsqlParameter("@id_aktvts", getId()),
                new NpgsqlParameter("@tgl", getTanggal()),
                new NpgsqlParameter("@id_krywn", this.id_karyawan),
                new NpgsqlParameter("@id_klm", this.id_kolam),
                new NpgsqlParameter("@id_p", this.id_Perawatan)
                );
            //System.Diagnostics.Debug.WriteLine(getId()+"|"+getTanggal()+"|"+id_karyawan+"|"+id_kolam+"|"+id_Perawatan);
        }


        public override void deleteAktivitas()
        {
            string query = "DELETE FROM aktivitas WHERE id_aktivitas = :id::integer; ";
            ExecuteNonQuery(query, new NpgsqlParameter(":id", getId()));
        }

    }


}