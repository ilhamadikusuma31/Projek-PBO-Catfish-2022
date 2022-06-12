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
                mvMain.SetActiveView(vKolam);
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
            // to retrive specific  textfield name   
            DropDownListLele.DataSource = dt_l;      //assigning datasource to the dropdownlist  
            DropDownListLele.DataBind();  //binding dropdownlist  
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex = int.Parse(e.CommandArgument.ToString());

            //ini didapat dari aspx
            string id = GridView2.DataKeys[rowIndex]["id_kolam"].ToString();

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
                tbNama.Text = GridView2.DataKeys[rowIndex]["nama_kolam"].ToString();

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
            string jumlah = tbJumlah.Text;
            string id_lele = DropDownListLele.Text;
            Kolam k = new Kolam("", nama, jumlah, id_lele);
            k.createKolam();
            isiData();
            panelUser.Visible = true;
            panelForm.Visible = false;
        }

        protected void tombolUpdate_Click(object sender, EventArgs e)
        {
            string id = ViewState["id"].ToString();
            string nama = tbNama.Text;
            string jumlah = tbJumlah.Text;
            string id_lele = DropDownListLele.Text;

            Kolam k = new Kolam(id, nama, jumlah, id_lele);
            k.updateKolam();
            isiData();
            panelUser.Visible = true;
            panelForm.Visible = false;
            lblmsg.Text = id + nama + jumlah + id_lele;
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