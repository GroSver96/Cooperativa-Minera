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
    public partial class RSocios : Form
    {
        public RSocios()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void BottunGuardar_Click(object sender, EventArgs e)
        {
            Socio Socio = new Socio();
            Socio.Nombre_Completo = txtNombreApellido.Text;
            Socio.Telefono = txtTelefono.Text;
            Socio.Email = txtEmail.Text;
            Socio.Fecha_Nacimiento = DateTime.Parse(txtFechaRegistro.Text);
            Socio.IdUsuario =Convert.ToInt32(txtIdUsuario.Text);

            int result = SocioDAL.AgregarSocio(Socio);

            if (result > 0)
            {
                MessageBox.Show("Exito al guardar");
            }
            else
            {
                MessageBox.Show("Error al guardar");
            }
            refressPantalla();
        }

        private void RSocios_Load(object sender, EventArgs e)
        {
            refressPantalla();
        }

        public void refressPantalla()
        {
            DGRSocios.DataSource = SocioDAL.PresentarSocio();
        }
        private void button2_Click(object sender, EventArgs e) //Boton de eliminar
        {
            if (DGRSocios.SelectedRows.Count == 1)
            {
                int IdSocio = Convert.ToInt32(DGRSocios.CurrentRow.Cells["IdSocio"].Value);
                int resultado = SocioDAL.EliminarSocio(IdSocio);
                if (resultado > 0)
                {
                    MessageBox.Show("Socio ELIMINADO con exito");
                }
                else
                {
                    MessageBox.Show("Error al elimiar");
                }

                refressPantalla();
            }
        }

        private void DGRSocios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
