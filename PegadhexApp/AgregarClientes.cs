using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace PegadhexApp
{
    public partial class AgregarClientes : Form
    {
        private string connectionString = "Data Source=C:\\Users\\User\\source\\repos\\Pegadhex\\PegadhexApp\\pegadhex; Version=3;";
        public AgregarClientes()
        {
            InitializeComponent();
            //this.dataGridView1 = new DataGridView();
            //this.SuspendLayout();

            // 
            // dataGridView1
            // 
            //this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            //this.dataGridView1.Name = "dataGridView1";
            //this.dataGridView1.Size = new System.Drawing.Size(760, 437);
            //this.dataGridView1.TabIndex = 0;

            // 
            // Form1
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(784, 461);
            //this.Controls.Add(this.dataGridView1);
            //this.Name = "Form1";
            //this.Text = "Clientes";
            //this.ResumeLayout(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombreCliente = cliNombre.Text;
            string rifCliente = cliRIF.Text;
            string fechaCliente = cliFecha.Text;
            string productoCliente = cliProducto.Text;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Clientes (nombreCliente, rifCliente, fechaCliente, productoCliente) VALUES (@nombreCliente, @rifCliente, @fechaCliente, @productoCliente)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombreCliente", nombreCliente);
                    cmd.Parameters.AddWithValue("@rifCliente", rifCliente);
                    cmd.Parameters.AddWithValue("@fechaCliente", fechaCliente);
                    cmd.Parameters.AddWithValue("@productoCliente", productoCliente);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"Datos guardados correctamente.: {nombreCliente}, {rifCliente}, {fechaCliente},  {productoCliente}");
                        Tabla();
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show ("Error al guardar los datos, intente más tarde " + ex.Message );
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cliNombre.Text = string.Empty;
            cliRIF.Text = string.Empty;
            cliFecha.Text = string.Empty;
            cliProducto.Text = string.Empty;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AgregarClientes_Load(object sender, EventArgs e)
        {
            Tabla();
        }

        private void Tabla()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Clientes";
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    dataGridView1.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                    dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DarkGray;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold);
                }
            }
        }
        private void btnExportarToExcel_Click(object sender, EventArgs e)
        {
            ExportarAExcel();
        }

        private void ExportarAExcel()
        {
            // Conexión a la base de datos SQLite
            //string connectionString = "Data Source=tu_base_de_datos.sqlite;Version=3;";
            //using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            //{
            //    connection.Open();
            //    string query = "SELECT idClientes, nombreCliente, rifCliente, fechaCliente, productoCliente FROM Clientes";
            //    using (SQLiteCommand command = new SQLiteCommand(query, connection))
            //    {
            //        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            //        {
            //            DataTable dataTable = new DataTable();
            //            adapter.Fill(dataTable);

            //            // Usar SaveFileDialog para elegir la ubicación y el nombre del archivo
            //            SaveFileDialog saveFileDialog = new SaveFileDialog
            //            {
            //                Filter = "Excel Files|*.xlsx",
            //                Title = "Guardar archivo Excel",
            //                FileName = "Clientes.xlsx"
            //            };

            //            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //            {
            //                // Crear una nueva instancia de Excel
            //                Excel.Application excelApp = new Excel.Application();
            //                excelApp.Workbooks.Add();
            //                Excel._Worksheet worksheet = (Excel._Worksheet)excelApp.ActiveSheet;

            //                // Escribir los encabezados de columna con nuevos nombres
            //                string[] encabezados = { "ID", "Nombres", "RIF", "Fecha", "Producto" };
            //                for (int i = 0; i < encabezados.Length; i++)
            //                {
            //                    Excel.Range headerCell = worksheet.Cells[1, i + 1];
            //                    headerCell.Value = encabezados[i];

            //                    // Aplicar estilo: negrita, color de fondo y bordes
            //                    headerCell.Font.Bold = true;
            //                    headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            //                    headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; // Centrar texto

            //                    // Aplicar bordes
            //                    Excel.Borders borders = headerCell.Borders;
            //                    borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            //                    borders.Weight = Excel.XlBorderWeight.xlThin;
            //                    borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            //                }

            //                // Escribir los datos de la tabla
            //                for (int i = 0; i < dataTable.Rows.Count; i++)
            //                {
            //                    for (int j = 0; j < dataTable.Columns.Count; j++)
            //                    {
            //                        worksheet.Cells[i + 2, j + 1] = dataTable.Rows[i][j];
            //                    }
            //                }

            //                // Guardar el archivo
            //                worksheet.SaveAs(saveFileDialog.FileName);
            //                excelApp.Quit();

            //                // Mostrar un mensaje de éxito
            //                MessageBox.Show("Archivo Excel guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //                // Liberar recursos
            //                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            //                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            //            }
            //        }
            //    }
            //}
            // Conexión a la base de datos SQLite
            //string connectionString = "Data Source=tu_base_de_datos.sqlite;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT idClientes, nombreCliente, rifCliente, fechaCliente, productoCliente FROM Clientes";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Usar SaveFileDialog para elegir la ubicación y el nombre del archivo
                        SaveFileDialog saveFileDialog = new SaveFileDialog
                        {
                            Filter = "Excel Files|*.xlsx",
                            Title = "Guardar archivo Excel",
                            FileName = "Clientes.xlsx"
                        };

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Crear una nueva instancia de Excel
                            Excel.Application excelApp = new Excel.Application();
                            excelApp.Workbooks.Add();
                            Excel._Worksheet worksheet = (Excel._Worksheet)excelApp.ActiveSheet;

                            // Escribir los encabezados de columna con nuevos nombres
                            string[] encabezados = { "ID", "Nombres", "RIF", "Fecha", "Producto" };
                            for (int i = 0; i < encabezados.Length; i++)
                            {
                                worksheet.Cells[1, i + 1] = encabezados[i];
                                // Aplicar estilo: negrita y color de fondo
                                Excel.Range headerCell = worksheet.Cells[1, i + 1];
                                headerCell.Font.Bold = true;
                                headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                            }

                            // Escribir los datos de la tabla
                            for (int i = 0; i < dataTable.Rows.Count; i++)
                            {
                                for (int j = 0; j < dataTable.Columns.Count; j++)
                                {
                                    worksheet.Cells[i + 2, j + 1] = dataTable.Rows[i][j];
                                }
                            }

                            // Guardar el archivo
                            worksheet.SaveAs(saveFileDialog.FileName);
                            excelApp.Quit();

                            // Mostrar un mensaje de éxito
                            MessageBox.Show("Archivo Excel guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Liberar recursos
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                        }
                    }
                }
            }

            // Conexión a la base de datos SQLite
            //string connectionString = "Data Source=tu_base_de_datos.sqlite;Version=3;";
            //using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            //{
            //    connection.Open();
            //    string query = "SELECT idClientes, nombreCliente, rifCliente, fechaCliente, productoCliente FROM Clientes";
            //    using (SQLiteCommand command = new SQLiteCommand(query, connection))
            //    {
            //        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            //        {
            //            DataTable dataTable = new DataTable();
            //            adapter.Fill(dataTable);

            //            // Crear una nueva instancia de Excel
            //            Excel.Application excelApp = new Excel.Application();
            //            excelApp.Workbooks.Add();
            //            Excel._Worksheet worksheet = (Excel._Worksheet)excelApp.ActiveSheet;

            //            // Escribir los encabezados de columna
            //            for (int i = 0; i < dataTable.Columns.Count; i++)
            //            {
            //                worksheet.Cells[1, i + 1] = dataTable.Columns[i].ColumnName;
            //            }

            //            // Escribir los datos de la tabla
            //            for (int i = 0; i < dataTable.Rows.Count; i++)
            //            {
            //                for (int j = 0; j < dataTable.Columns.Count; j++)
            //                {
            //                    worksheet.Cells[i + 2, j + 1] = dataTable.Rows[i][j];
            //                }
            //            }

            //            // Mostrar Excel
            //            excelApp.Visible = true;

            //            // Liberar recursos
            //            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            //            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            //        }
            //    }
            //}
        }
    }
}
