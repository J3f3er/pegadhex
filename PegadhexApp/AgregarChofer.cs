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

namespace PegadhexApp
{
    public partial class AgregarChofer : Form
    {
        private string connectionString = "Data Source=C:\\Users\\User\\source\\repos\\Pegadhex\\PegadhexApp\\pegadhex; Version=3;";

        public AgregarChofer()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string cedula = txtCedula.Text;
                string fecha = txtFecha.Text;
                string ingreso = txtFechaIngreso.Text;

                string query = "INSERT INTO transporte (nombreTransporte, apellidoTransporte, cedulaTransporte, fechaNacimiento, fechaIngreso) values(@nombre, @apellido, @cedula, @fecha, @ingreso)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@ingreso", ingreso);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"Datos ingresados correctamente. Nombre: {nombre}, Apellido: {apellido}, Cedula: {cedula}, Fecha de Nacimiento: {fecha}, Ingreso: {ingreso}", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNombre.Text = string.Empty;
                        txtApellido.Text = string.Empty;
                        txtCedula.Text = string.Empty;
                        txtFecha.Text = string.Empty;
                        txtFechaIngreso.Text = string.Empty;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrio un error: {ex.Message}");
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtFecha.Text = string.Empty;
            txtFechaIngreso.Text = string.Empty;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
