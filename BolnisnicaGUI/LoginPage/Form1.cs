using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;

namespace LoginPage
{
    public partial class Form1 : Form
    {
        //private SqlConnection con1, con2;
        private SqlDataReader reader;
        private Form2 forma;

        public Form1()
        {
            InitializeComponent();
        }
              
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string imeRacunalnika = "localhost";
            string imeRazlicice = "SQLEXPRESS";
            string imeBaze = "Bolnisnica";



            string ukaz = "SELECT [uporabnisko_ime],[geslo],[EMSO_pacienta],[EMSO_doktorja],[EMSO_sestre] " +
                          "FROM View_Login " +
                          "WHERE uporabnisko_ime LIKE '" + txtBoxUsername.Text + 
                          "' AND geslo LIKE '" + GenerateSHA256String(txtBoxPassword.Text) + "'";

            String connectionString = "data source=" + imeRacunalnika + "\\" + imeRazlicice + "; AttachDbFileName=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Bolnisnica.mdf; " +
                                      "database=" + imeBaze + "; Integrated Security=SSPI;";//User Id=gui_user_bolnisnica; Password=holyPass666;";

            var con1 = new SqlConnection("data source=localhost\\SQLEXPRESS; database=Bolnisnica; Integrated Security=SSPI;");
            
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("CREATE LOGIN gui_user_bolnisnica WITH PASSWORD = 'holyPass666'", con1);
                cmd.ExecuteNonQuery();                
            }
            catch { /*LOGIN already exists*/ }            
            finally{con1.Close();}

            var con2 = new SqlConnection(connectionString);
            con2.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(ukaz, con2);
                reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //get emso //redirect
                        if (!reader.IsDBNull(2))                    //pacient
                            forma = new Form2(reader.GetString(0), reader.GetString(2), 'p');
                        else if (!reader.IsDBNull(3))               //doktor
                            forma = new Form2(reader.GetString(0), reader.GetString(3), 'd');
                        else if (!reader.IsDBNull(4))               //sestra
                            forma = new Form2(reader.GetString(0), reader.GetString(4), 's');
                        else                                        //admin
                            forma = new Form2(reader.GetString(0), "emso", 'a');                        
                        forma.Show();
                        forma.FormClosed += new FormClosedEventHandler(form2_FormClosed);
                        this.Hide();
                    }
                }
                else
                {
                    lblPassword.ForeColor = lblUserName.ForeColor = Color.Red;
                    txtBoxUsername.Focus();
                }
            }
            catch(Exception ex)
            {
                Log.Logiraj1(ex);
            }
            finally { con2.Close(); }

            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand("ALTER USER uporabnik WITH LOGIN = gui_user_bolnisnica", con1);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { Log.Logiraj2("Connecting User with Login acc.", ex); }
            finally { con1.Close(); }
        }

        private void form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }  

        private void txtBoxUsername_TextChanged(object sender, EventArgs e)
        {
            lblPassword.ForeColor = lblUserName.ForeColor = Color.Black;
        }


        //https://codeshare.co.uk/blog/sha-256-and-sha-512-hash-examples/
        //Generira hash za podan niz
        public static string GenerateSHA256String(string inputString)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha256.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }       

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
    }

    public static class Log
    {
        private static int error_num = 0;

        public static void Logiraj1(Exception ex)
        {
            using(StreamWriter strW = new StreamWriter(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\error.log", true))
            {
                strW.WriteLine(error_num.ToString() + " - [" + DateTime.Today + "]\n" +  ex + "\n");
            }
        }

        public static void Logiraj2(string opis, Exception ex)
        {
            using (StreamWriter strW = new StreamWriter(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\error.log", true))
            {
                strW.WriteLine(error_num.ToString() + " - [" + DateTime.Today + "]\n" + opis + "\n" + ex + "\n");
            }
        }
    }
}
