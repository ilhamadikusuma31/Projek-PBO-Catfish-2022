using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projek_PBO_Catfish_2022.Models;

namespace Projek_PBO_Catfish_2022
{

    public partial class _Lele : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // Postback: dari dalam form / url dia sendiri
            if (!IsPostBack)
            {
                mvMain.SetActiveView(vLele);
                isiData();
            }
        }

        public void isiData()
        {
            Lele l = new Lele();
            DataTable dt = l.readLele();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex = int.Parse(e.CommandArgument.ToString());

            //ini didapat dari aspx
            string id = GridView1.DataKeys[rowIndex]["id_lele"].ToString();

            if (e.CommandName == "hapus")
            {
                //intitialize objek baru dari kelas Lele
                //parameter nama dikosongin karena untuk hapus gaperlu
                Lele l = new Lele(id, "");
                l.deleteLele();
                isiData();
            }
            else if (e.CommandName == "ubah")
            {
                tbNama.Text = GridView1.DataKeys[rowIndex]["nama_lele"].ToString();

                //ViewState => Variabel browser client tdk hilang jika tdk pindah form / url

                ViewState["id_lele"] = id;
                btSimpan.Visible = false;
                btUpdate.Visible = true;
                panelUser.Visible = false;
                panelForm.Visible = true;
            }
        }

        protected void tombolSimpan_Click(object sender, EventArgs e)
        {
            string nama = tbNama.Text;
            Lele l = new Lele("", nama);
            l.createLele();
            isiData();
            panelUser.Visible = true;
            panelForm.Visible = false;
        }

        protected void tombolUpdate_Click(object sender, EventArgs e)
        {
            string nama = tbNama.Text;
            string id = ViewState["id_lele"].ToString();

            Lele l = new Lele(id, nama);
            l.updateLele();
            isiData();
            panelUser.Visible = true;
            panelForm.Visible = false;
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

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            try /* Select After Validations*/
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["koneksiku"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from Lele";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    GridView1.DataSource = dt;
                    GridView1.DataBind();


                }
            }
            catch (Exception ex) { }
        }
    }
}