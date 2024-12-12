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
    public partial class historialChofer : Form
    {
        private string connectionString = "Data Source=C:\\Users\\User\\source\\repos\\Pegadhex\\PegadhexApp\\pegadhex; Version=3;";
        public historialChofer()
        {
            InitializeComponent();
        }

        private void historialChofer_Load(object sender, EventArgs e)
        {
            Tabla();
        }

        private void Tabla()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                string query = "SELECT * FROM transporte";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn)) 
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader()) 
                        {
                            dataGridView1.Columns.Clear();
                            dataGridView1.Rows.Clear();

                            dataGridView1.Columns.Add("idTransporte", "ID");
                            dataGridView1.Columns.Add("nombreTransporte", "Nombre");
                            dataGridView1.Columns.Add("apellidoTransporte", "Apellido");
                            dataGridView1.Columns.Add("cedulaTransporte", "Cedula");
                            dataGridView1.Columns.Add("fechaNacimiento", "Fecha Nacimiento");
                            dataGridView1.Columns.Add("fechaIngreso", "Fecha Ingreso");

                            while (reader.Read())
                                {
                                    dataGridView1.Rows.Add(
                                        reader["idTransporte"],
                                        reader["nombreTransporte"],
                                        reader["apellidoTransporte"],
                                        reader["cedulaTransporte"],
                                        reader["fechaNacimiento"],
                                        reader["fechaIngreso"]
                                    );
                                }
                        }
                    }
                }
        }
    }
}
