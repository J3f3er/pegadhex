using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace PegadhexApp
{
    public partial class AgregarProveedores : Form
    {
        private string connectionString = "Data Source=C:\\Users\\User\\source\\repos\\Pegadhex\\PegadhexApp\\pegadhex; Version=3;";
        public AgregarProveedores()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string empresa = txtEmpresa.Text;
            string rif = TxtRIF.Text;
            string producto = txtProducto.Text;
            string fecha = txtFecha.Text;
            if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show($"El campo Nombre no puede quedar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombre.Focus();
                    return;
                }
            if (string.IsNullOrWhiteSpace(empresa))
                {
                MessageBox.Show($"El campo Empresa no puede quedar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmpresa.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(rif))
                {
                MessageBox.Show($"El campo Rif no puede quedar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtRIF.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(producto))
                {
                MessageBox.Show($"El campo Producto no puede quedar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProducto.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(fecha))
                {
                MessageBox.Show($"El campo Fecha no puede quedar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFecha.Focus();
                return;
            }
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO proveedores (nombreProveedores, empresaProveedores, RIFProveedores, productoProveedores, fechaProveedores) VALUES (@nombreProveedores, @empresaProveedores, @RIFProveedores, @productoProveedores, @fechaProveedores)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nombreProveedores", nombre);
                            cmd.Parameters.AddWithValue("@empresaProveedores", empresa);
                            cmd.Parameters.AddWithValue("@RIFProveedores", rif);
                            cmd.Parameters.AddWithValue("@productoProveedores", producto);
                            cmd.Parameters.AddWithValue("@fechaProveedores", fecha);

                            int resultado = cmd.ExecuteNonQuery();
                            if (resultado > 0)
                            {
                                MessageBox.Show($"Registro realizado con exito!!!! se registraron los siguientes productos:" +
                                        $"Nombre: {nombre}" +
                                        $"Empresa: {empresa}" +
                                        $"RIF: {rif}" +
                                        $"Producto: {producto}" +
                                        $"Fecha: {fecha}"
                                    );
                            CargarTabla();
                            txtNombre.Text = string.Empty;
                            txtEmpresa.Text = string.Empty;
                            txtProducto.Text = string.Empty;
                            txtFecha.Text = string.Empty;
                            txtNombre.Focus();
                        }
                            else
                            {
                            MessageBox.Show($"No se pudo realizar el registro, intente mas tarde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtEmpresa.Text = string.Empty;
            txtFecha.Text = string.Empty;
            txtProducto.Text = string.Empty;
            TxtRIF.Text = string.Empty;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            exportarExcel();
        }

        private void exportarExcel()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM proveedores";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd))
                    {
                        System.Data.DataTable dataT = new System.Data.DataTable();
                        sda.Fill(dataT);

                        SaveFileDialog saveFileDialog = new SaveFileDialog
                        {
                            Filter = "Excel Files|*.xlsx",
                            Title = "Guardar archivo Excel",
                            FileName = "Proveedores.xlsx"
                        };

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            Excel.Application excelApp = new Excel.Application();
                            excelApp.Workbooks.Add();
                            Excel._Worksheet worksheet = (Excel._Worksheet)excelApp.ActiveSheet;

                            string[] encabezaos = { "ID", "Nombres", "Empresa", "RIF", "Producto", "Fecha" };
                            for (int i = 0; i < encabezaos.Length; i++)
                            {
                                worksheet.Cells[1, i + 1] = encabezaos[i];
                                Excel.Range headerCell = worksheet.Cells[1, i + 1];
                                headerCell.Font.Bold = true;
                                headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkOliveGreen);
                            }
                            for (int i = 0; i < dataT.Rows.Count; i++)
                            {
                                for (int j = 0; j < dataT.Columns.Count; j++)
                                {
                                    worksheet.Cells[i + 2, j + 1] = dataT.Rows[i][j];
                                }
                            }

                            worksheet.SaveAs(saveFileDialog.FileName);
                            excelApp.Quit();

                            MessageBox.Show("Archivo Excel Guarado exitosamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                        }
                    }
                }
            }
        }

        private void AgregarProveedores_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }

        private void CargarTabla()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM proveedores";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns["idProveedores"].HeaderText = "ID's";
                    dataGridView1.Columns["nombreProveedores"].HeaderText = "Nombres";
                    dataGridView1.Columns["empresaProveedores"].HeaderText = "Empresas";
                    dataGridView1.Columns["RIFProveedores"].HeaderText = "RIF";
                    dataGridView1.Columns["productoProveedores"].HeaderText = "Productos";
                    dataGridView1.Columns["fechaProveedores"].HeaderText = "Fechas";

                    dataGridView1.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                    dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DarkGray;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar datos: {ex.Message} ");
                }
            }
        }
    }
}
