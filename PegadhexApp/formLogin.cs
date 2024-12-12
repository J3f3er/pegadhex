using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;


namespace PegadhexApp
{
    public partial class formLogin : Form
    {
        //string connection = ConfigurationManager.ConnectionStrings["miconexion"].ConnectionString;
        private string connection = "Data Source=C:\\Users\\User\\source\\repos\\Pegadhex\\PegadhexApp\\pegadhex; Version=3;";
        public formLogin()
        {
            InitializeComponent();
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            //Tabla();

        }

        /*private void Tabla()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {
                conn.Open();
                string selectQuery = "SELECT * FROM usuarios";
                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(selectQuery, conn))
                {
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }*/

        private void sesion_Click(object sender, EventArgs e)
        {
            string usuario = Usuario.Text;
            string contrasena = Contrasena.Text;

            if (ValidarUsuario(usuario, contrasena))
            {
                MessageBox.Show($"Inicio de sesión exitoso {usuario}, {contrasena} ");
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorectos");
            }
        }

        private bool ValidarUsuario(string usuario, string contrasena)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM usuarios WHERE correoUsuario = @correo AND contrasenaUsuario = @contrasena";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@correo", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}
