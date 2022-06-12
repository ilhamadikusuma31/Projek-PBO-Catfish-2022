using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Projek_PBO_Catfish_2022.Models;

namespace Projek_PBO_Catfish_2022
{
    public partial class _Karyawan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Postback: dari dalam form / url dia sendiri
            if (!IsPostBack)
            {
                mvMain.SetActiveView(vKaryawan);
                isiData();
            }
        }
        public void isiData()
        {
            Karyawan k = new Karyawan();
            DataTable dt = k.readKaryawan();
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex = int.Parse(e.CommandArgument.ToString());

            //ini didapat dari aspx
            string id = GridView2.DataKeys[rowIndex]["id_karyawan"].ToString();

            if (e.CommandName == "hapus")
            {
                //intitialize objek baru dari kelas Kolam
                //parameter nama dikosongin karena untuk hapus gaperlu
                Karyawan k = new Karyawan(id,"","","");
                k.deleteKaryawan();
                isiData();
            }
            else if (e.CommandName == "ubah")
            {
                tbNama.Text = GridView2.DataKeys[rowIndex]["nama_karyawan"].ToString();

                //ViewState => Variabel browser client tdk hilang jika tdk pindah form / url

                ViewState["id"] = id;
                btSimpan.Visible = false;
                btUpdate.Visible = true;
                panelUser.Visible = false;
                panelForm.Visible = true;
            }
        }

        protected void tombolSimpan_Click(object sender, EventArgs e)
        {
            string nama = tbNama.Text;
            string alamat = tbAlamat.Text;
            string no_telp = tbNoTelp.Text;
            Karyawan k = new Karyawan("", nama, alamat, no_telp);
            k.createKaryawan();
            isiData();
            panelUser.Visible = true;
            panelForm.Visible = false;
        }

        protected void tombolUpdate_Click(object sender, EventArgs e)
        {
            string id = ViewState["id"].ToString();
            string nama = tbNama.Text;
            string alamat = tbAlamat.Text;
            string no_telp = tbNoTelp.Text;

            Karyawan k = new Karyawan(id, nama, alamat, no_telp);
            k.updateKaryawan();
            isiData();
            panelUser.Visible = true;
            panelForm.Visible = false;

            lblmsg.Text = id + nama + alamat + no_telp;
        
        }

        protected void lbTambah_Click(object sender, EventArgs e)
        {
            panelUser.Visible = false;
            panelForm.Visible = true;
            btSimpan.Visible = true;
            btUpdate.Visible = false;
        }

        protected void btBatal_Click(object sender, EventArgs e)
        {
            panelUser.Visible = true;
            panelForm.Visible = false;
        }

        //    protected void btnSelect_Click(object sender, EventArgs e)
        //    {
        //        try /* Select After Validations*/
        //        {
        //            using (NpgsqlConnection connection = new NpgsqlConnection())
        //            {
        //                connection.ConnectionString = ConfigurationManager.ConnectionStrings["koneksiku"].ToString();
        //                connection.Open();
        //                NpgsqlCommand cmd = new NpgsqlCommand();
        //                cmd.Connection = connection;
        //                cmd.CommandText = "Select * from Kolam";
        //                cmd.CommandType = CommandType.Text;
        //                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
        //                DataTable dt = new DataTable();
        //                da.Fill(dt);
        //                cmd.Dispose();
        //                connection.Close();

        //                GridView1.DataSource = dt;
        //                GridView1.DataBind();


        //            }
        //        }
        //        catch (Exception ex) { }
        //    }
    }
}