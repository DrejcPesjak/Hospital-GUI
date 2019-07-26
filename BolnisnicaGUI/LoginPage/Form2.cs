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
    public partial class Form2 : Form
    {
        private string EMSOuporabnika;
        private char vrstaUporabnika;
        private string uporabniskoIme;

        /*private string imeRacunalnika = "localhost";
        private string imeRazlicice = "SQLEXPRESS";
        private string imeBaze = "Bolnisnica";*/
        private String connectionString = "data source=localhost\\SQLEXPRESS; database=Bolnisnica; "+
                                            "User Id=gui_user_bolnisnica; Password=holyPass666;";
      
        private SqlConnection con;
        private SqlDataReader reader;

        private TextBox txtUporIme, txtGeslo, txtEmso;
        private TextBox txtNovoGeslo2, txtNovoGeslo1, txtStaroGeslo;
        private RadioButton rdbtnDoktor;
        private RadioButton rdbtnSestra;
        private DataGridView uporabnikiDGV;

        public Form2(string upor_ime, string emso, char vrsta)
        {
            InitializeComponent();
            EMSOuporabnika = emso;
            vrstaUporabnika = vrsta;
            uporabniskoIme = upor_ime;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            switch (vrstaUporabnika)
            {
                case 'p':
                    panelPacient.Show();
                    panelDoktor.Hide(); panelAdmin.Hide(); panelSestra.Hide();
                    break;
                case 'd':
                    panelDoktor.Show();
                    panelPacient.Hide(); panelAdmin.Hide(); panelSestra.Hide();
                    btnDoktorKartoteka_Click(this, EventArgs.Empty);
                    break;
                case 's':
                    panelSestra.Show();
                    panelDoktor.Hide(); panelAdmin.Hide(); panelPacient.Hide();
                    break;
                case 'a':
                    panelAdmin.Show();
                    panelDoktor.Hide(); panelPacient.Hide(); panelSestra.Hide();                                       
                    break;
                default:
                    panelPacient.Hide(); panelDoktor.Hide(); panelAdmin.Hide(); panelSestra.Hide();
                    break;
            }
        }


        /*********************************ADMIN*********************************/
        #region
        private void btnDodajUporabnika_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            panel_populate_admin_adduser();
        }

        private void panel_populate_admin_adduser()
        {
            Label lblUporIme = new Label();
            lblUporIme.Location = new System.Drawing.Point(30, 59);
            lblUporIme.Name = "lblUporIme";
            lblUporIme.Size = new System.Drawing.Size(134, 20);
            lblUporIme.TabIndex = 0;
            lblUporIme.Text = "Uporabnisko Ime:";

            Label lblGeslo = new Label();
            lblGeslo.Location = new System.Drawing.Point(98, 97);
            lblGeslo.Name = "lblGeslo";
            lblGeslo.Size = new System.Drawing.Size(55, 20);
            lblGeslo.TabIndex = 1;
            lblGeslo.Text = "Geslo:";

            Label lblPoklic = new Label();
            lblPoklic.Location = new System.Drawing.Point(97, 140);
            lblPoklic.Name = "lblPoklic";
            lblPoklic.Size = new System.Drawing.Size(56, 20);
            lblPoklic.TabIndex = 2;
            lblPoklic.Text = "Poklic:";

            Label lblEmso = new Label();
            lblEmso.Location = new System.Drawing.Point(97, 170);
            lblEmso.Name = "lblEmso";
            lblEmso.Size = new System.Drawing.Size(55, 20);
            lblEmso.TabIndex = 3;
            lblEmso.Text = "EMSO:";

            txtUporIme = new TextBox();
            txtUporIme.Location = new System.Drawing.Point(178, 56);
            txtUporIme.Name = "txtUporIme";
            txtUporIme.Size = new System.Drawing.Size(156, 23);
            txtUporIme.TabIndex = 4;

            txtGeslo = new TextBox();
            txtGeslo.Location = new System.Drawing.Point(178, 94);
            txtGeslo.Name = "txtGeslo";
            txtGeslo.PasswordChar = '*';
            txtGeslo.Size = new System.Drawing.Size(156, 23);
            txtGeslo.TabIndex = 5;

            txtEmso = new TextBox();
            txtEmso.Location = new System.Drawing.Point(178, 167);
            txtEmso.Name = "txtEmso";
            txtEmso.Size = new System.Drawing.Size(156, 23);
            txtEmso.TabIndex = 8;

            rdbtnDoktor = new RadioButton();
            rdbtnDoktor.AutoSize = true;
            rdbtnDoktor.Location = new System.Drawing.Point(178, 140);
            rdbtnDoktor.Name = "rdbtnDoktor";
            rdbtnDoktor.Size = new System.Drawing.Size(107, 21);
            rdbtnDoktor.TabIndex = 6;
            rdbtnDoktor.TabStop = true;
            rdbtnDoktor.Text = "Doktor";
            rdbtnDoktor.UseVisualStyleBackColor = true;
            rdbtnDoktor.Checked = true;

            rdbtnSestra = new RadioButton();
            rdbtnSestra.AutoSize = true;
            rdbtnSestra.Location = new System.Drawing.Point(290, 140);
            rdbtnSestra.Name = "rdbtnSestra";
            rdbtnSestra.Size = new System.Drawing.Size(107, 21);
            rdbtnSestra.TabIndex = 7;
            rdbtnSestra.TabStop = true;
            rdbtnSestra.Text = "Sestra";
            rdbtnSestra.UseVisualStyleBackColor = true;

            Button btnDodajUser = new Button();
            btnDodajUser.Location = new System.Drawing.Point(183, 209);
            btnDodajUser.Name = "btnDodajUser";
            btnDodajUser.Size = new System.Drawing.Size(75, 23);
            btnDodajUser.TabIndex = 9;
            btnDodajUser.Text = "Dodaj";
            btnDodajUser.UseCompatibleTextRendering = true;
            btnDodajUser.UseVisualStyleBackColor = true;
            btnDodajUser.Click += btnDodajUser_Click;
                        
            txtUporIme.Parent = txtGeslo.Parent = txtEmso.Parent = rdbtnDoktor.Parent = rdbtnSestra.Parent = btnDodajUser.Parent =
            lblUporIme.Parent = lblGeslo.Parent = lblEmso.Parent = lblPoklic.Parent = splitContainer1.Panel2;
        }

        private void btnDodajUser_Click(object sender, EventArgs e)
        {
            string ukaz="";
            if(rdbtnDoktor.Checked)
            {
                ukaz = "EXECUTE sp_dodaj_uporabnika '" + txtUporIme.Text + "', '" + Form1.GenerateSHA256String(txtGeslo.Text) + "', NULL, '" +
                        txtEmso.Text + "', NULL";
            }
            else if(rdbtnSestra.Checked)
            {
                ukaz = "EXECUTE sp_dodaj_uporabnika '" + txtUporIme.Text + "', '" + Form1.GenerateSHA256String(txtGeslo.Text) + "', NULL,  NULL, '" +
                        txtEmso.Text + "'";
            }

            var con = new SqlConnection(connectionString);
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand(ukaz, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                Log.Logiraj2("Procedure execution failed. (sp_dodaj_uporabnika)", ex); 
            }
            finally 
            { 
                con.Close();
                txtUporIme.Text = txtGeslo.Text = txtEmso.Text = "";
                txtUporIme.Focus();
            }
        }

        private void btnPregledUporabnikov_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            panel_populate_admin_showuser();
        }

        private void panel_populate_admin_showuser()
        {
            uporabnikiDGV = new DataGridView();
            uporabnikiDGV.Parent = splitContainer1.Panel2;
            uporabnikiDGV.Dock = DockStyle.Fill;
            uporabnikiDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            uporabnikiDGV.AllowUserToAddRows = uporabnikiDGV.AllowUserToDeleteRows = false;
            uporabnikiDGV.AllowUserToOrderColumns = true;

            DataTable dt = new DataTable();
            string ukaz = "SELECT uporabnisko_ime, EMSO_pacienta, EMSO_doktorja, EMSO_sestre FROM View_Login ";

            var con = new SqlConnection(connectionString);
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand(ukaz, con);
                reader = cmd.ExecuteReader();

                dt.Load(reader);
                uporabnikiDGV.DataSource = dt;
            }
            catch(Exception ex) 
            {
                Log.Logiraj1(ex);
            }
            finally { con.Close(); }
        }
                
        private void btnSprUporGeslo_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            panel_populate_admin_passchange();
        }

        private void panel_populate_admin_passchange()
        {
            // lblUporIme
            Label lblUporIme1 = new Label();
            lblUporIme1.AutoSize = true;
            lblUporIme1.Location = new System.Drawing.Point(35, 38);
            lblUporIme1.Name = "lblUporIme";
            lblUporIme1.Size = new System.Drawing.Size(118, 17);
            lblUporIme1.TabIndex = 0;
            lblUporIme1.Text = "Uporabniško ime:";

            // txtUporIme
            txtUporIme = new TextBox();
            txtUporIme.Location = new System.Drawing.Point(176, 38);
            txtUporIme.Name = "txtUporIme";
            txtUporIme.Size = new System.Drawing.Size(156, 23);
            txtUporIme.TabIndex = 1;
                        
            // btnSpremeniGeslo
            Button btnSpremeniGeslo = new Button();
            btnSpremeniGeslo.Location = new System.Drawing.Point(224, 87);
            btnSpremeniGeslo.Name = "btnSpremeniGeslo";
            btnSpremeniGeslo.Size = new System.Drawing.Size(111, 46);
            btnSpremeniGeslo.TabIndex = 2;
            btnSpremeniGeslo.Text = "Spremeni geslo";
            btnSpremeniGeslo.UseVisualStyleBackColor = true;
            btnSpremeniGeslo.Click += btnPonastaviGeslo_Click;

            txtUporIme.Parent = btnSpremeniGeslo.Parent = lblUporIme1.Parent = splitContainer1.Panel2; 
        }

        private void btnPonastaviGeslo_Click(object sender, EventArgs e)
        {
            string ukaz = "EXECUTE sp_ponastavi_geslo '" + txtUporIme.Text + "'";

            var con = new SqlConnection(connectionString);
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand(ukaz, con);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) 
            {
                Log.Logiraj2("Procedure execution failed. (sp_ponastavi_geslo)", ex); 
            }
            finally
            {
                con.Close();
                txtUporIme.Text = "";
                txtUporIme.Focus();
            }
        }
        #endregion

        /*********************************VSI*********************************/
        #region
        private void btnSpremSvojeGeslo_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            panel_populate_all_change_password();
        }

        private void panel_populate_all_change_password()
        {
            // lblUporIme1
            Label lblUporIme1 = new Label();
            lblUporIme1.AutoSize = true;
            lblUporIme1.Location = new System.Drawing.Point(35, 38);
            lblUporIme1.Name = "lblUporIme1";
            lblUporIme1.Size = new System.Drawing.Size(118, 17);
            lblUporIme1.TabIndex = 0;
            lblUporIme1.Text = "Uporabniško ime:";

            // lblUporIme2
            Label lblUporIme2 = new Label();
            lblUporIme2.AutoSize = true;
            lblUporIme2.Location = new System.Drawing.Point(176, 38);
            lblUporIme2.Name = "lblUporIme2";
            lblUporIme2.Size = new System.Drawing.Size(28, 17);
            lblUporIme2.TabIndex = 1;
            lblUporIme2.Text = uporabniskoIme;

            // lblStaroGeslo
            Label lblStaroGeslo = new Label();
            lblStaroGeslo.AutoSize = true;
            lblStaroGeslo.Location = new System.Drawing.Point(69, 67);
            lblStaroGeslo.Name = "lblStaroGeslo";
            lblStaroGeslo.Size = new System.Drawing.Size(84, 17);
            lblStaroGeslo.TabIndex = 2;
            lblStaroGeslo.Text = "Staro geslo:";

            // lblNovoGeslo1
            Label lblNovoGeslo1 = new Label();
            lblNovoGeslo1.AutoSize = true;
            lblNovoGeslo1.Location = new System.Drawing.Point(70, 97);
            lblNovoGeslo1.Name = "lblNovoGeslo1";
            lblNovoGeslo1.Size = new System.Drawing.Size(83, 17);
            lblNovoGeslo1.TabIndex = 4;
            lblNovoGeslo1.Text = "Novo geslo:";

            // lblNovoGeslo2
            Label lblNovoGeslo2 = new Label();
            lblNovoGeslo2.AutoSize = true;
            lblNovoGeslo2.Location = new System.Drawing.Point(70, 128);
            lblNovoGeslo2.Name = "lblNovoGeslo2";
            lblNovoGeslo2.Size = new System.Drawing.Size(83, 17);
            lblNovoGeslo2.TabIndex = 6;
            lblNovoGeslo2.Text = "Novo geslo:";
            
            // txtStaroGeslo
            txtStaroGeslo = new TextBox();
            txtStaroGeslo.Location = new System.Drawing.Point(179, 65);
            txtStaroGeslo.Name = "txtStaroGeslo";
            txtStaroGeslo.Size = new System.Drawing.Size(156, 23);
            txtStaroGeslo.TabIndex = 3;
            txtStaroGeslo.PasswordChar = '*';

            // txtNovoGeslo1
            txtNovoGeslo1 = new TextBox();
            txtNovoGeslo1.Location = new System.Drawing.Point(179, 94);
            txtNovoGeslo1.Name = "txtNovoGeslo1";
            txtNovoGeslo1.Size = new System.Drawing.Size(156, 23);
            txtNovoGeslo1.TabIndex = 5;
            txtNovoGeslo1.PasswordChar = '*';

            // txtNovoGeslo2
            txtNovoGeslo2 = new TextBox();
            txtNovoGeslo2.Location = new System.Drawing.Point(179, 125);
            txtNovoGeslo2.Name = "txtNovoGeslo2";
            txtNovoGeslo2.Size = new System.Drawing.Size(156, 23);
            txtNovoGeslo2.TabIndex = 7;
            txtNovoGeslo2.PasswordChar = '*';

            // btnSpremeniGeslo
            Button btnSpremeniGeslo = new Button();
            btnSpremeniGeslo.Location = new System.Drawing.Point(224, 174);
            btnSpremeniGeslo.Name = "btnSpremeniGeslo";
            btnSpremeniGeslo.Size = new System.Drawing.Size(111, 46);
            btnSpremeniGeslo.TabIndex = 8;
            btnSpremeniGeslo.Text = "Spremeni geslo";
            btnSpremeniGeslo.UseVisualStyleBackColor = true;
            btnSpremeniGeslo.Click += btnSpremeniGeslo_Click;

            txtNovoGeslo2.Parent = txtNovoGeslo1.Parent = txtStaroGeslo.Parent = btnSpremeniGeslo.Parent =
                lblNovoGeslo2.Parent = lblStaroGeslo.Parent = lblNovoGeslo1.Parent = lblUporIme2.Parent = lblUporIme1.Parent = splitContainer1.Panel2; 
        }

        private void btnSpremeniGeslo_Click(object sender, EventArgs e)
        {
            if (txtNovoGeslo1.Text == txtNovoGeslo2.Text)
            {
                string ukaz = "EXECUTE sp_spremeni_geslo '" + uporabniskoIme + "', '" +
                                Form1.GenerateSHA256String(txtStaroGeslo.Text) + "', '" + Form1.GenerateSHA256String(txtNovoGeslo1.Text) + "'";

                var con = new SqlConnection(connectionString);
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand(ukaz, con);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex) 
                {
                    Log.Logiraj2("Procedure execution failure. (sp_spremeni_geslo)\n" + ukaz, ex);
                }
                finally
                {
                    con.Close();
                    txtNovoGeslo1.Text = txtNovoGeslo2.Text = txtStaroGeslo.Text = "";
                    txtStaroGeslo.Focus();
                }
            }
        }

        private void btnOdjava_Click(object sender, EventArgs e)
        {
            uporabniskoIme = EMSOuporabnika = null;
            vrstaUporabnika = '\0';
            Form1 novLogin = new Form1();
            novLogin.Show();
            this.Close();
        }
        #endregion

        /*********************************PACIENT*********************************/
        #region
        private void btnPacientPodatki_Click(object sender, EventArgs e)
        {
            Label lblEMSO = new Label();
            lblEMSO.Name = "lblEMSO";
            lblEMSO.Text = "EMSO stevilka: ";
            lblEMSO.Location = new System.Drawing.Point(35, 38);
            lblEMSO.AutoSize = true;

            Label lblImePriimek = new Label();
            lblImePriimek.Name = "lblImePriimek";
            lblImePriimek.Text = "Ime in Priimek: ";
            lblImePriimek.Location = new System.Drawing.Point(35, 68);
            lblImePriimek.AutoSize = true;

            Label lblNaslov = new Label();
            lblNaslov.Name = "lblNaslov";
            //lblNaslov.Text = "Naslov: ";
            lblNaslov.Location = new System.Drawing.Point(35, 98);
            lblNaslov.AutoSize = true;

            string ukaz = "SELECT * FROM View_Pacient WHERE EMSO_pacienta = '" + EMSOuporabnika + "'";
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
                        lblEMSO.Text += reader.GetString(0);
                        lblImePriimek.Text += reader.GetString(1) + " " + reader.GetString(2);
                        lblNaslov.Text = "Naslov: " + reader.GetString(4) + Environment.NewLine + 
                                            "Pošta: " + reader.GetString(5) + " " + reader.GetString(7);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Logiraj2("Pacient data retrieval from db.\n" + ukaz, ex);
            }
        }

        private void btnPacientTermini_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            populate_pacient_termini();
        }

        private void populate_pacient_termini()
        {
            uporabnikiDGV = new DataGridView();
            uporabnikiDGV.Parent = splitContainer1.Panel2;
            uporabnikiDGV.Dock = DockStyle.Fill;
            uporabnikiDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            uporabnikiDGV.AllowUserToAddRows = uporabnikiDGV.AllowUserToDeleteRows = false;
            uporabnikiDGV.AllowUserToOrderColumns = true;
            uporabnikiDGV.CellDoubleClick += uporabnikiDGV_CellDoubleClick;

            DataTable dt = new DataTable();
            string ukaz = "SELECT sifra_termina, datum, ime_doktorja + '' + priimek_doktorja" +
                            " FROM View_TerminRecept WHERE EMSO_pacienta = '" + EMSOuporabnika + "' ORDER BY datum DESC";
            
            var con = new SqlConnection(connectionString);
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand(ukaz, con);
                reader = cmd.ExecuteReader();

                dt.Load(reader);
                uporabnikiDGV.DataSource = dt;
            }
            catch (Exception ex)
            {
                Log.Logiraj2("Pacient's appointments data retrieval from db.\n" + ukaz, ex);
            }
            finally { con.Close(); }
        }

        void uporabnikiDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int sifra_termina = (int) ((DataGridView)sender)[0, e.RowIndex].Value;
            Form3 forma = new Form3(sifra_termina, EMSOuporabnika);
            forma.Show();
        }
        #endregion
        
        /*********************************DOKTOR*********************************/
        #region
        private void btnDoktorKartoteka_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            panel_populate_doktor_pacienti();
        }

        private void panel_populate_doktor_pacienti()
        {            
            uporabnikiDGV = new DataGridView();
            uporabnikiDGV.Parent = splitContainer1.Panel2;
            uporabnikiDGV.Dock = DockStyle.Fill;
            uporabnikiDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            uporabnikiDGV.AllowUserToAddRows = uporabnikiDGV.AllowUserToDeleteRows = false;
            uporabnikiDGV.AllowUserToOrderColumns = true;
            uporabnikiDGV.CellDoubleClick += uporabnikiDGV_dokPacient_CellDoubleClick;

            DataTable dt = new DataTable();
            string ukaz = "SELECT EMSO_pacienta, ime_pacienta, priimek_pacienta, MAX(datum) as [Zadnji termin] "+
                            "FROM View_TerminRecept " +
                            "WHERE EMSO_doktorja = '" + EMSOuporabnika + "' "+
                            "GROUP BY EMSO_doktorja, EMSO_pacienta,ime_pacienta,priimek_pacienta";
            
            var con = new SqlConnection(connectionString);
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand(ukaz, con);
                reader = cmd.ExecuteReader();

                dt.Load(reader);
                uporabnikiDGV.DataSource = dt;
            }
            catch (Exception ex)
            {
                Log.Logiraj2("Doctor's pacients list retrieval from db.\n" + ukaz, ex);
            }
            finally { con.Close(); }
        }

        private void uporabnikiDGV_dokPacient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Button btnDodajTermin = new Button();
            btnDodajTermin.Name = "btnDodajTermin";
            btnDodajTermin.Text = "Dodaj termin";
            btnDodajTermin.Size = new System.Drawing.Size(99, 32);
            btnDodajTermin.Location = new Point(splitContainer1.Panel2.Width-99-10, splitContainer1.Panel2.Height-32-10);
            btnDodajTermin.Parent = splitContainer1.Panel2;
            btnDodajTermin.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            btnDodajTermin.Click += btnDodajTermin_Click;

            string EMSO_pacienta = ((DataGridView)sender)[0, e.RowIndex].Value.ToString();

            uporabnikiDGV.CellDoubleClick -= uporabnikiDGV_dokPacient_CellDoubleClick;
            uporabnikiDGV.CellDoubleClick += uporabnikiDGV_dokPacientTermin_CellDoubleClick;

            DataTable dt = new DataTable();
            string ukaz = "SELECT sifra_termina, EMSO_pacienta, datum, opis, recept " +
                            "FROM (SELECT sifra_termina, EMSO_pacienta, datum, opis, 'Klikni za več' AS recept, "+
                                            "ROW_NUMBER() OVER(PARTITION BY SIFRA_TERMINA ORDER BY EMSO_PACIENTA)  AS vrstica "+
	                               "FROM View_TerminRecept "+
	                               "WHERE EMSO_pacienta = '" + EMSO_pacienta + "' ) AS T2 "+
                            "WHERE vrstica = 1";

            var con = new SqlConnection(connectionString);
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand(ukaz, con);
                reader = cmd.ExecuteReader();

                dt.Load(reader);
                uporabnikiDGV.DataSource = dt;
            }
            catch (Exception ex)
            {
                Log.Logiraj2("Pacient's past appointments : retreived by doctor(" + EMSOuporabnika + ")\n" + ukaz, ex);
            }
            finally { con.Close(); }
        }

        private void btnDodajTermin_Click(object sender, EventArgs e)
        {
            /*
            Form3 novTermin = new Form3(0, "new");
            novTermin.ShowDialog();
            if (novTermin.ShowDialog(this) == DialogResult.OK)
            {
                //novTermin.Opis
            }
            else
            {
                
            }
            novTermin.Dispose();*/
        }

        private void uporabnikiDGV_dokPacientTermin_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int sifra_termina = (int)((DataGridView)sender)[0, e.RowIndex].Value;
            string EMSO_pacienta = ((DataGridView)sender)[1, e.RowIndex].Value.ToString();

            Form3 getOpis = new Form3(sifra_termina, EMSO_pacienta);
           
            getOpis.ShowDialog(); 
        }
        #endregion
    }
}


//https://social.msdn.microsoft.com/Forums/en-US/8db841fc-ffa7-4519-b6f5-d054c7190948/insert-deleting-updating-records-into-database-using-datagridview-in-visual-c?forum=csharplanguage