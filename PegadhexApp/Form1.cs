using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PegadhexApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 10000;
            timer1.Tick += Timer1_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Disminuye la opacidad
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.05; // Reduce la opacidad en 0.05 por cada tick
                timer1.Stop(); // Detiene el timer cuando la opacidad es 0
                this.Hide(); // Oculta el formulario (opcional)
            }
            // Muestra el formulario de inicio de sesión
            formLogin loginForm = new formLogin();
            loginForm.Show(); // Muestra el nuevo formulario

        }
    }
}
