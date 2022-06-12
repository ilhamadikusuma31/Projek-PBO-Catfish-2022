using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Npgsql;
using System.Data;
namespace Projek_PBO_Catfish_2022.Models
{

    public class Karyawan : SqlDBHelper
    {
        string id;
        string nama_lengkap;
        string alamat;
        string no_telpon;
        public Karyawan(string id = null, string nama_lengkap=null, string alamat = null, string no_telpon = null)
        {
            this.id = id;
            this.nama_lengkap = nama_lengkap;
            this.alamat = alamat;
            this.no_telpon = no_telpon;
        }
        public void createKaryawan()
        {
            string query = "INSERT INTO karyawan (nama_karyawan, alamat_karyawan, no_telp_karyawan) values ('{0}','{1}','{2}');";
            query = string.Format(query, this.nama_lengkap, this.alamat, this.no_telpon);
            ExecuteNonQuery(query);
        }

        public DataTable readKaryawan()
        {
            string query = "SELECT * FROM karyawan";
            DataTable dt = ExecuteQuery(query);
            return dt;
        }

        public void updateKaryawan()
        {
            string query = @"UPDATE karyawan SET 
                            nama_karyawan      =:nama_lengkap::text, 
                            alamat_karyawan    =:alamat::text, 
                            no_telp_karyawan   =:no_telpon::text
                            WHERE id_karyawan  =:id::integer;";
            ExecuteNonQuery(query,
                new NpgsqlParameter(":nama_lengkap", this.nama_lengkap),
                new NpgsqlParameter(":alamat", this.alamat),
                new NpgsqlParameter(":no_telpon", this.no_telpon),
                new NpgsqlParameter(":id", this.id)
                );
        }


        public void deleteKaryawan()
        {
            string query = "DELETE FROM karyawan WHERE id_karyawan = :id::integer; ";
            ExecuteNonQuery(query, new NpgsqlParameter(":id", this.id));
        }

    }
}