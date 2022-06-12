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
        public Kolam(string id, string nama, string jumlah,string id_lele )
        {
            this.id = id;
            this.nama = nama;
            this.jumlah = jumlah;
            this.id_lele = id_lele;
        }

        public void createKolam()
        {
            string query = "INSERT INTO kolam (nama, jumlah, id_lele) values ('{0}','{1}','{2}');";
            query = string.Format(query, this.nama, this.jumlah, this.id_lele);
            ExecuteNonQuery(query);
        }

        public DataTable readKolam()
        {
            string query = "SELECT * FROM kolam";
            DataTable dt = ExecuteQuery(query);
            return dt;
        }

        public void updateKolam()
        {
            string query = "UPDATE kolam SET nama =:nama, jumlah =:jumlah:, id_lele =:id_lele WHERE id =:id::integer;";
            ExecuteNonQuery(query,
                new NpgsqlParameter(":id", this.id),
                new NpgsqlParameter(":nama", this.nama),
                new NpgsqlParameter(":jumlah", this.jumlah),
                new NpgsqlParameter(":id_lele", this.id_lele)
                );
        }


        public void deleteKolam()
        {
            string query = "DELETE FROM kolam WHERE id = :id::integer; ";
            ExecuteNonQuery(query, new NpgsqlParameter(":id", this.id));
        }
    }
}