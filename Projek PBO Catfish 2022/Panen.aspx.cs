using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projek_PBO_Catfish_2022.Models;

namespace Projek_PBO_Catfish_2022
{
    public partial class _Panen : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            // Postback: dari dalam form / url dia sendiri
            if (!IsPostBack)
            {
                mv.SetActiveView(vPanen);
                isiData();
            }
        }

        public void isiData()
        {
        
            Panen a = new Panen();
            DataTable dt = a.readAktivitas();

            Kolam k = new Kolam();
            DataTable dt_ko = k.readKolam();
            DropDownListKolam.DataTextField = dt_ko.Columns["nama_kolam"].ToString(); 
            DropDownListKolam.DataValueField = dt_ko.Columns["id_kolam"].ToString();
            DropDownListKolam.DataSource = dt_ko;      
            DropDownListKolam.DataBind(); 
            
            Karyawan ka = new Karyawan();
            DataTable dt_ka = ka.readKaryawan();
            DropDownListKaryawan.DataTextField = dt_ka.Columns["nama_karyawan"].ToString(); 
            DropDownListKaryawan.DataValueField = dt_ka.Columns["id_karyawan"].ToString();
            DropDownListKaryawan.DataSource = dt_ka;      
            DropDownListKaryawan.DataBind(); 
                                  
            GridView.DataSource = dt;
            GridView.DataBind();
        }

        protected void perintahGridView(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex = int.Parse(e.CommandArgument.ToString());

            //ini didapat dari aspx
            string id_a     = GridView.DataKeys[rowIndex]["id_aktivitas"].ToString();
            string id_krywn = GridView.DataKeys[rowIndex]["id_karyawan"].ToString();
            string id_klm   = GridView.DataKeys[rowIndex]["id_kolam"].ToString();

            if (e.CommandName == "hapus")
            {
                //intitialize objek baru dari kelas Panen
                //parameter nama dikosongin karena untuk hapus gaperlu
                Panen a = new Panen(id_a, "");
                a.deleteAktivitas();
                isiData();
            }
            else if (e.CommandName == "ubah")
            {
                //build form untuk edit
                inputTanggal.SelectedDate.ToString(GridView.DataKeys[rowIndex]["tanggal"].ToString());
                DropDownListKaryawan.AccessKey = id_krywn;
                DropDownListKolam.AccessKey = id_klm;

                //ViewState => Variabel browser client tdk hilang jika tdk pindah form / url
                ViewState["id_aktivitas"] = id_a;
                tombolSimpan.Visible = false;
                tombolUpdate.Visible = true;
                panel.Visible = false;
                panelForm.Visible = true;
            }
        }

        protected void tombolSimpanClick(object sender, EventArgs e)
        {
          
            string tgl = inputTanggal.SelectedDate.ToString("yyyy-MM-dd");
            string id_karyawan = DropDownListKaryawan.Text;
            string id_kolam = DropDownListKolam.Text;
            Panen a = new Panen("", tgl,id_karyawan,id_kolam);
            a.createAktivitas();
            isiData();
            panel.Visible = true;
            panelForm.Visible = false;
        }

        protected void tombolUpdateClick(object sender, EventArgs e)
        {

            string id = ViewState["id_aktivitas"].ToString();
            string tgl = inputTanggal.SelectedDate.ToString("yyyy-MM-dd");
            string id_karyawan = DropDownListKaryawan.Text;
            string id_kolam = DropDownListKolam.Text;
            Panen a = new Panen(id, tgl, id_karyawan, id_kolam);
            a.updateAktivitas();
            isiData();
            panel.Visible = true;
            panelForm.Visible = false;
            //pesan.Text = ""+id+" | "+tgl+" | "+id_karyawan+" | "+id_kolam;
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


    }
}