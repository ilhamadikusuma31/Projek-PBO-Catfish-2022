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
                mv.SetActiveView(vKaryawan);
                isiData();
            }
        }
        public void isiData()
        {
            Karyawan k = new Karyawan();
            DataTable dt = k.readKaryawan();
            GridView.DataSource = dt;
            GridView.DataBind();
        }

        protected void perintahGridView(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex = int.Parse(e.CommandArgument.ToString());

            //ini didapat dari aspx
            string id = GridView.DataKeys[rowIndex]["id_karyawan"].ToString();

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
                inputNamaKaryawan.Text = GridView.DataKeys[rowIndex]["nama_karyawan"].ToString();
                inputAlamatKaryawan.Text = GridView.DataKeys[rowIndex]["alamat_karyawan"].ToString();
                inputNoTelpKaryawan.Text = GridView.DataKeys[rowIndex]["no_telp_karyawan"].ToString();
                //DropDownListLele.Items.FindByValue(id).Selected = true; masih gatau carannya di set sesuai datanya 

                //ViewState => Variabel browser client tdk hilang jika tdk pindah form / url
                ViewState["id"] = id;
                tombolSimpan.Visible = false;
                tombolUpdate.Visible = true;
                panel.Visible = false;
                panelForm.Visible = true;
            }
        }

        protected void tombolSimpanClick(object sender, EventArgs e)
        {
            string nama     = inputNamaKaryawan.Text;
            string alamat   = inputAlamatKaryawan.Text;
            string no_telp  = inputNoTelpKaryawan.Text;
            Karyawan k = new Karyawan("", nama, alamat, no_telp);
            k.createKaryawan();
            isiData();
            panel.Visible = true;
            panelForm.Visible = false;
        }

        protected void tombolUpdateClick(object sender, EventArgs e)
        {
            string id = ViewState["id"].ToString();
            string nama = inputNamaKaryawan.Text;
            string alamat = inputAlamatKaryawan.Text;
            string no_telp = inputNoTelpKaryawan.Text;

            Karyawan k = new Karyawan(id, nama, alamat, no_telp);
            k.updateKaryawan();
            isiData();
            panel.Visible = true;
            panelForm.Visible = false;

            //lblmsg.Text = id + nama + alamat + no_telp;
        
        }

        protected void tombolTambahDataClick(object sender, EventArgs e)
        {
            panel.Visible = false;
            panelForm.Visible = true;
            tombolSimpan.Visible = true;
            tombolUpdate.Visible = false;
        }

        protected void tombolBatalClick(object sender, EventArgs e)
        {
            panel.Visible = true;
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