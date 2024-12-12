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
    public partial class Factura : Form
    {
        public Factura()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string currentValue = txtFacturaN.Text;
            if (int.TryParse(currentValue, out int number))
            {
                number++;
                txtFacturaN.Text = number.ToString("D5");
            }
            else
            {
                MessageBox.Show($"El valor en el campo de texto no es un numero valido.");
            }
        }
    }
}
