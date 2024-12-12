using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PegadhexApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void notaDeDebitoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formLogin formLogin = new formLogin();
            formLogin.Show();
            this.Hide();
        }

        private void ventToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AgregarClientes agregarClientes = new AgregarClientes();
            agregarClientes.Show();
        }

        private void agregarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            AgregarChofer agregarChofer = new AgregarChofer();
            agregarChofer.Show();
        }

        private void historialToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            historialChofer historialChofer = new historialChofer();
            historialChofer.Show();
        }

        private void agregarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AgregarProveedores agregarProveedores = new AgregarProveedores();
            agregarProveedores.Show();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarUsuario registrar = new AgregarUsuario();
            registrar.Show();
        }

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void facturaToolStripMenuItem1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F)
            {
                Factura fact = new Factura();
                fact.Show();
            }
        }

        private void facturaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Factura fact = new Factura();
            fact.Show();
        }
    }
}
