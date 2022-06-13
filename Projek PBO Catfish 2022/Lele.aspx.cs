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
                mv.SetActiveView(vLele);
                isiData();
            }
        }

        public void isiData()
        {
            Lele l = new Lele();
            DataTable dt = l.readLele();
            GridView.DataSource = dt;
            GridView.DataBind();
        }

        protected void gridViewCommand(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex = int.Parse(e.CommandArgument.ToString());

            //ini didapat dari aspx
            string id = GridView.DataKeys[rowIndex]["id_lele"].ToString();

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
                inputNama.Text = GridView.DataKeys[rowIndex]["nama_lele"].ToString();

                //ViewState => Variabel browser client tdk hilang jika tdk pindah form / url

                ViewState["id_lele"] = id;
                tombolSimpan.Visible = false;
                tombolUpdate.Visible = true;
                panel.Visible = false;
                panelForm.Visible = true;
            }
        }

        protected void tombolSimpanClick(object sender, EventArgs e)
        {
            string nama = inputNama.Text;
            Lele l = new Lele("", nama);
            l.createLele();
            isiData();
            panel.Visible = true;
            panelForm.Visible = false;
        }

        protected void tombolUpdateClick(object sender, EventArgs e)
        {
            string nama = inputNama.Text;
            string id = ViewState["id_lele"].ToString();

            Lele l = new Lele(id, nama);
            l.updateLele();
            isiData();
            panel.Visible = true;
            panelForm.Visible = false;
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

