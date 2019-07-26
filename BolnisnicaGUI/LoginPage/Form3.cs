using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginPage
{
    public partial class Form3 : Form
    {
        private int sifra_termina;
        private string EMSO_pacienta;

        private SqlConnection con;
        private SqlDataReader reader;
        private String connectionString = "data source=localhost\\SQLEXPRESS; database=Bolnisnica; " +
                                            "User Id=gui_user_bolnisnica; Password=holyPass666;";

        public string Opis
        {
            get { return txtOpis.Text; }
        }

        public Form3(int sifra, string emso_pacienta)
        {
            InitializeComponent();
            sifra_termina = sifra;
            EMSO_pacienta = emso_pacienta;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (EMSO_pacienta != "new")
            {
                string ukaz = "SELECT sifra_termina, datum, opis, sifra_recepta FROM View_TerminRecept " +
                                "WHERE EMSO_pacienta = '" + EMSO_pacienta + "' AND sifra_termina = " + sifra_termina;
                var con = new SqlConnection(connectionString);
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand(ukaz, con);
                    reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            lblSifraTermina.Text += reader.GetInt32(0);
                            lblDatum.Text += reader.GetDateTime(1);
                            txtOpis.Text = reader.GetString(2);

                            Form4 getRecept = new Form4(reader.GetInt32(3), 'g');
                            getRecept.Show();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Logiraj2("Detailed appointment data retrevial.\n" + ukaz, ex);
                }
            }
            else
            {
                btnDodajRecept.Visible = btnShraniTermin.Visible = true;
                btnShraniTermin.DialogResult = System.Windows.Forms.DialogResult.OK;
                txtOpis.Enabled = false;
            }
        }

        private void btnDodajRecept_Click(object sender, EventArgs e)
        {
           /* Form4 novRecept = new Form4();
            novRecept.ShowDialog();*/
        }


    }
}
