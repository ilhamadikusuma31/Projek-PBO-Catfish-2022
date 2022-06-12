using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Data;

namespace Projek_PBO_Catfish_2022.Models
{
    public class Panen : Aktivitas
    {

        string id_karyawan;
        string id_kolam;

        public Panen(string id, string tanggal, string id_karyawan, string id_kolam) : base(id, tanggal)
        {
            this.id_karyawan = id_karyawan;
            this.id_kolam = id_kolam;
        }
        public void createPanen()
        {
            string query = "INSERT INTO Panen (tanggal,id_karyawan, id_kolam ) values ('{0}','{1}');";
            query = string.Format(query, getTanggal()  ,this.id_karyawan, this.id_kolam);
            ExecuteNonQuery(query);
        }

        public DataTable readPanen()
        {
            string query = "SELECT * FROM panen p LEFT JOIN karyawan k ON p.id_karyawan = k.id_karyawan;";
            DataTable dt = ExecuteQuery(query);
            return dt;
        }

        public void updatePanen()
        {
            string query = @"UPDATE panen SET 
                             tanggal = @tgl::text,
                             id_karyawan = @id_krywn::text, 
                             id_kolam = @id_klm::integer
                             WHERE id_panen =@id::integer;";
            ExecuteNonQuery(query,
                new NpgsqlParameter("@tgl", getTanggal()),
                new NpgsqlParameter("@id_krywn", this.id_karyawan),
                new NpgsqlParameter("@id_klm", this.id_kolam)
                );
        }


        public void deletePanen()
        {
            string query = "DELETE FROM panen WHERE id_panen = :id::integer; ";
            ExecuteNonQuery(query, new NpgsqlParameter(":id", getId()));
        }

    }


}