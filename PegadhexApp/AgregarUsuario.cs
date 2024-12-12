﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Excel = Microsoft.Office.Interop.Excel;

namespace PegadhexApp
{
    public partial class AgregarUsuario : Form
    {
        private string connectionString = "Data Source=C:\\Users\\User\\source\\repos\\Pegadhex\\PegadhexApp\\pegadhex; Version=3;";
        public AgregarUsuario()
        {
            InitializeComponent();
            CargarTabla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string clv = txtContrasena.Text;
            string correo = txtCorreo.Text;
            string roles = cmbRol.SelectedItem.ToString();
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(clv) || string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(roles))
            {
                MessageBox.Show($"Los campos no pueden quedar vacios.", "¡Alerta!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO usuarios (nombreUusuario, apellidoUsuario, correoUsuario, contrasenaUsuario, nivelUsuario) VALUES (@nombreUusuario, @apellidoUsuario, @correoUsuario, @contrasenaUsuario, @nivelUsuario)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombreUusuario", nombre);
                    cmd.Parameters.AddWithValue("@apellidoUsuario", apellido);
                    cmd.Parameters.AddWithValue("@correoUsuario", correo);
                    cmd.Parameters.AddWithValue("@contrasenaUsuario", clv);
                    cmd.Parameters.AddWithValue("@nivelUsuario", roles);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"Usuario registrado exitosamente");
                        CargarTabla();
                        txtNombre.Text = string.Empty;
                        txtApellido.Text = string.Empty;
                        txtCorreo.Text = string.Empty;
                        txtContrasena.Text = string.Empty;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"No se pudo registrar: {ex.Message}");
                    }
                }
            }
        }
        private void CargarTabla()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM usuarios";
                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        dgvUsuarios.DataSource = dt;

                        dgvUsuarios.Columns[0].HeaderText = "IDs";
                        dgvUsuarios.Columns[1].HeaderText = "Nombres";
                        dgvUsuarios.Columns[2].HeaderText = "Apellidos";
                        dgvUsuarios.Columns[3].HeaderText = "Correos";
                        dgvUsuarios.Columns[4].HeaderText = "Roles";

                        dgvUsuarios.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                        dgvUsuarios.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
                        dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DarkGray;
                        dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor= System.Drawing.Color.White;
                        dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold);

                        //while (reader.Read())
                        //{
                            
                        //}
                    }
                }
            }
        }

        private void AgregarUsuario_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtContrasena.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;

            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

            worksheet.Cells[1, 1] = "Numero de Usuarios";
            worksheet.Cells[1, 2] = "Nombre de Usuarios";
            worksheet.Cells[1, 3] = "Apellido de Usuarios";
            worksheet.Cells[1, 4] = "Correo de Usuarios";
            worksheet.Cells[1, 5] = "Contraseñas de Usuarios";
            worksheet.Cells[1, 6] = "Nivel de Usuarios";

            for (int i = 0; i < dgvUsuarios.Rows.Count; i++)
            {
                for (int j = 0; j < dgvUsuarios.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dgvUsuarios.Rows[i].Cells[j].Value;
                }
            }

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel Files|*.xls;*.xlsx";
            saveFile.Title = "Guardar Archivo Excel";
            saveFile.FileName = "Usuarios";

            if(saveFile.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFile.FileName);
                MessageBox.Show($"Se completo la exportación a Excel Exitosamente.", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            workbook.Close();
            excelApp.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }
    }
}