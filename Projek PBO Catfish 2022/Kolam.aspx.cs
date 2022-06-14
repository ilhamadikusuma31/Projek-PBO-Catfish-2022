using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projek_PBO_Catfish_2022.Models;

namespace Projek_PBO_Catfish_2022
{
    public partial class _Kolam : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            // Postback: dari dalam form / url dia sendiri
            if (!IsPostBack)
            {
                mv.SetActiveView(vKolam);
                isiData();
            }
        }

        public void isiData()
        {
            Kolam k = new Kolam();
            DataTable dt = k.readKolam();

            Lele l = new Lele();
            DataTable dt_l = l.readLele();
            DropDownListLele.DataTextField = dt_l.Columns["nama_lele"].ToString(); // text field name of table dispalyed in dropdown       
            DropDownListLele.DataValueField = dt_l.Columns["id_lele"].ToString();
            DropDownListLele.DataSource = dt_l;      //assigning datasource to the dropdownlist  
            DropDownListLele.DataBind();  //binding dropdownlist
                                          //

            GridView.DataSource = dt;
            GridView.DataBind();
        }

        protected void perintahGridView(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex = int.Parse(e.CommandArgument.ToString());

            //ini didapat dari aspx
            string id = GridView.DataKeys[rowIndex]["id_kolam"].ToString();

            if (e.CommandName == "hapus")
            {
                //intitialize objek baru dari kelas Kolam
                //parameter nama dikosongin karena untuk hapus gaperlu
                Kolam k = new Kolam(id);
                k.deleteKolam();
                isiData();
            }
            else if (e.CommandName == "ubah")
            {
                //nge-build form edit sesuai item yang dipilih
                inputNamaKolam.Text    = GridView.DataKeys[rowIndex]["nama_kolam"].ToString();
                inputJumlahLele.Text   = GridView.DataKeys[rowIndex]["jumlah_lele"].ToString();
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
            string nama = inputNamaKolam.Text;
            string jumlah = inputJumlahLele.Text;
            string id_lele = DropDownListLele.Text;
            Kolam k = new Kolam("", nama, jumlah, id_lele);
            k.createKolam();
            isiData();
            panel.Visible = true;
            panelForm.Visible = false;
        }

        protected void tombolUpdateClick(object sender, EventArgs e)
        {
            string id = ViewState["id"].ToString();
            string nama = inputNamaKolam.Text;
            string jumlah = inputJumlahLele.Text;
            string id_lele = DropDownListLele.Text;

            Kolam k = new Kolam(id, nama, jumlah, id_lele);
            k.updateKolam();
            isiData();
            panel.Visible = true;
            panelForm.Visible = false;
            //lblmsg.Text = id + nama + jumlah + id_lele;
        }

        protected void tombolTambahDataClick(object sender, EventArgs e)
        {
            panel.Visible = false;
            panelForm.Visible = true;
            tombolSimpan.Visible = true;
            tombolUpdate.Visible = false;

            //kosongin form kali aja masih ada datanya yang udah ke input di formnya
            inputNamaKolam.Text = "";
            inputJumlahLele.Text = "";
        }

        protected void tombolBatalClick(object sender, EventArgs e)
        {
            panel.Visible = true;
            panelForm.Visible = false;
        }

    }
}

