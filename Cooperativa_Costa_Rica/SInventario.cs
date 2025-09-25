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
    public partial class SInventario : Form
    {
        public SInventario()
        {
            InitializeComponent();
        }



        private void button2Produccion_Click(object sender, EventArgs e)
        {
            SProduccion SProduccion = new SProduccion();
            SProduccion.Show();
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
