using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCooperativa
{
    public partial class SProduccion : Form
    {
        public SProduccion()
        {
            InitializeComponent();
        }

        private void button2Inventario_Click(object sender, EventArgs e)
        {
            SInventario SInventario = new SInventario();
            SInventario.Show();
            this.Hide();
        }

        private void button3Inicio_Click(object sender, EventArgs e)
        {
            InicioSesion InicioSesion = new InicioSesion();
            InicioSesion.Show();
            this.Hide();
        }
    }
}
