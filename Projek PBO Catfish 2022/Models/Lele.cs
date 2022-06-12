using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//using baru
using Npgsql;
using System.Data; //=> agar bisa menggunakan DataTable

namespace Projek_PBO_Catfish_2022.Models
{
    public class Lele : SqlDBHelper
    {
        public string id;
        public string nama;

        //konstruktor => method tapi pake nama class itu
        public Lele(string _id = null, string _nama = null)
        {
            this.id = _id;
            this.nama = _nama;
        }


        //SqlDBHelper objSqlDb = new SqlDBHelper(); => ini ga kepake karena class ini sudah extend

        public void createLele()
        {
            string query = "INSERT INTO lele (nama) values ('{0}');";
            query = string.Format(query, this.nama);
            ExecuteNonQuery(query);
        }

        public DataTable readLele()
        {
            string query = "SELECT * FROM lele;";
            DataTable dt = ExecuteQuery(query);
            return dt;
        }

        public void updateLele()
        {
            string query = "UPDATE lele SET nama =@nama::text WHERE id =:id::integer;";
            ExecuteNonQuery(query,
                new NpgsqlParameter("@nama", this.nama),
                new NpgsqlParameter("@id", this.id)
                );
        }


        public void deleteLele()
        {
            string query = "DELETE FROM lele WHERE id = :id::integer; ";
            ExecuteNonQuery(query, new NpgsqlParameter(":id", this.id));
        }

        //public DataTable getNamaLeleById()
        //{
        //    string query = "SELECT nama FROM lele WHERE id = @id;";
        //    DataTable dt = ExecuteQuery(query,new NpgsqlParameter("@id", this.id));
        //    return dt;
            
        //}
    }
}