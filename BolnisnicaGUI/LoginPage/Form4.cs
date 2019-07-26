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
    public partial class Form4 : Form
    {
        private int sifra;
        private char get_edit;
        private Recept recept1;

        private SqlConnection con;
        private SqlDataReader reader;
        private String connectionString = "data source=localhost\\SQLEXPRESS; database=Bolnisnica; " +
                                            "User Id=gui_user_bolnisnica; Password=holyPass666;";


        public Form4(int sifra_recepta, char getORedit)
        {
            InitializeComponent();
            sifra = sifra_recepta;
            get_edit = getORedit;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            if(get_edit=='g')
            {
                this.Enabled = false;
                string ukaz = "SELECT EMSO_doktorja, EMSO_pacienta, ime_pacienta, priimek_pacienta, naslov_pacienta, "+
                                "posta_pacienta, kraj_pacienta, datum, razlog, nacin, drzava, enotaZZZS, vrsta_doktorja FROM View_TerminRecept " +
                                "WHERE sifra_recepta = '" + sifra + "'";
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
                            string vrsta_zdravnika = reader.GetString(12);
                            if (vrsta_zdravnika == "osebni") rdbtnOsebni.Checked = true;
                            else if (vrsta_zdravnika == "pooblasceni") rdbtnPooblasceni.Checked = true;
                            else if (vrsta_zdravnika == "nadomestni") rdbtnNadomestni.Checked = true;

                            lblStZdravnika.Text = reader.GetString(0);

                            recept1.Emso_pacienta = reader.GetString(1);
                            lblStZavarovaneOsebe.Text = recept1.Emso_pacienta;
                            lblDatumRojstva.Text = recept1.Datum_rojstva;
                            lblSpol.Text = recept1.Spol.ToString();
                            lblIme.Text = reader.GetString(2);
                            lblPriimek.Text = reader.GetString(3);
                            lblUlica.Text = reader.GetString(4);
                            lblPosta.Text = reader.GetString(5);
                            lblKraj.Text = reader.GetString(6);


                            int razlog = reader.GetInt32(8);
                            switch (razlog)
                            {
                                case 1:
                                    rdbtnBolezen.Checked = true;
                                    break;
                                case 2:
                                    rdbtnIzvenDela.Checked = true;
                                    break;
                                case 3:
                                    rdbtnPokBolezen.Checked = true;
                                    break;
                                case 4:
                                    rdbtnPriDelu.Checked = true;
                                    break;
                                case 5:
                                    rdbtnTretjaOsb.Checked = true;
                                    break;
                                default:
                                    break;
                            }

                            int nacin = reader.GetInt32(9);
                            switch (nacin)
                            {
                                case 1:
                                    rdbtnBrezDop.Checked = true;
                                    break;
                                case 2:
                                    rdbtnZavOsb.Checked = true;
                                    break;
                                case 3:
                                    rdbtnZavarovalnica.Checked = true;
                                    break;
                            }

                            lblDanasnjiDatum.Text = reader.GetDateTime(7).ToString("d. M. yyyy");

                            masktxtEnotaZZZS.Text = reader.GetString(11);
                            masktxtSifraDrzave.Text = reader.GetString(10);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Logiraj2("Receipt data.\n" + ukaz, ex);
                }
            }
            else if (get_edit=='e')
            {
                this.Enabled = true;
                btnShraniRecept.Visible = true;
                lblDanasnjiDatum.Text = DateTime.Today.ToString("d. M. yyyy");
            }
        }

        private void btnShraniRecept_Click(object sender, EventArgs e)
        {

        }
    }
}
