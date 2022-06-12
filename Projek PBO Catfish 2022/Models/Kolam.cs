using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//using baru
using System.Data;
using Npgsql;


namespace Projek_PBO_Catfish_2022.Models
{
    public class Kolam : SqlDBHelper
    {
        public string id;
        public string nama;
        public string jumlah;
        public string id_lele;

        //konstruktor => method tapi pake nama class itu
        public Kolam(string id = null, string nama = null, string jumlah=null, string id_lele=null)
        {
            this.id = id;
            this.nama = nama;
            this.jumlah = jumlah;
            this.id_lele = id_lele;
        }

        public void createKolam()
        {
            string query = "INSERT INTO kolam (nama_kolam, jumlah_lele, id_lele) values ('{0}','{1}','{2}');";
            query = string.Format(query, this.nama, this.jumlah, this.id_lele);
            ExecuteNonQuery(query);
        }

        public DataTable readKolam()
        {
            string query = "SELECT * FROM kolam k Left JOIN lele l ON k.id_lele = l.id_lele; ";
            DataTable dt = ExecuteQuery(query);
            return dt;
        }

        public void updateKolam()
        {
            string query = @"UPDATE kolam SET 
                            nama_kolam =@nama::text, 
                            jumlah_lele =@jumlah::integer, 
                            id_lele =@id_lele::integer
                            WHERE id_kolam =@id::integer;";
            ExecuteNonQuery(query,
                new NpgsqlParameter("@nama", this.nama),
                new NpgsqlParameter("@jumlah", this.jumlah),
                new NpgsqlParameter("@id_lele", this.id_lele),
                new NpgsqlParameter("@id", this.id)
                );
        }


        public void deleteKolam()
        {
            string query = "DELETE FROM kolam WHERE id_kolam = :id::integer; ";
            ExecuteNonQuery(query, new NpgsqlParameter(":id", this.id));
        }
    }
}