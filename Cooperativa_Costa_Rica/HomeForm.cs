using System;
using System.Windows.Forms;

namespace SistemaCooperativa
{
    public class HomeForm : Form
    {
        private Button btnFinanzas;
        private Button btnInventario;
        private Button btnProduccion;
        private Button btnReporte;
        private Button btnRSocios;
        private Button btnCerrarSesion;
        private string userRole;
        private int userId;

        public HomeForm(string role, int id)
        {
            userRole = role;
            userId = id;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Menu Principal - Cooperativa Costa Rica";
            this.Size = new System.Drawing.Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Título
            Label lblTitulo = new Label();
            lblTitulo.Text = "SISTEMA COOPERATIVA";
            lblTitulo.Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(150, 20);
            lblTitulo.Size = new System.Drawing.Size(300, 30);
            lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Controls.Add(lblTitulo);

            // Información del usuario (ahora incluye ID)
            Label lblUsuario = new Label();
            lblUsuario.Text = $"Usuario: {userRole} (ID: {userId})";
            lblUsuario.Location = new System.Drawing.Point(20, 70);
            lblUsuario.Size = new System.Drawing.Size(250, 20);
            this.Controls.Add(lblUsuario);

            // Initialize buttons
            btnFinanzas = new Button();
            btnInventario = new Button();
            btnProduccion = new Button();
            btnReporte = new Button();
            btnRSocios = new Button();
            btnCerrarSesion = new Button();

            // Set button properties
            btnFinanzas.Text = "📊 Finanzas";
            btnFinanzas.Location = new System.Drawing.Point(50, 110);
            btnFinanzas.Size = new System.Drawing.Size(150, 40);
            btnFinanzas.Font = new System.Drawing.Font("Arial", 10);
            btnFinanzas.Click += BtnFinanzas_Click;

            btnInventario.Text = "📦 Inventario";
            btnInventario.Location = new System.Drawing.Point(250, 110);
            btnInventario.Size = new System.Drawing.Size(150, 40);
            btnInventario.Font = new System.Drawing.Font("Arial", 10);
            btnInventario.Click += BtnInventario_Click;

            btnProduccion.Text = "🏭 Producción";
            btnProduccion.Location = new System.Drawing.Point(50, 170);
            btnProduccion.Size = new System.Drawing.Size(150, 40);
            btnProduccion.Font = new System.Drawing.Font("Arial", 10);
            btnProduccion.Click += BtnProduccion_Click;

            btnReporte.Text = "📋 Reportes";
            btnReporte.Location = new System.Drawing.Point(250, 170);
            btnReporte.Size = new System.Drawing.Size(150, 40);
            btnReporte.Font = new System.Drawing.Font("Arial", 10);
            btnReporte.Click += BtnReporte_Click;

            btnRSocios.Text = "Registro Socios";
            btnRSocios.Location = new System.Drawing.Point(150, 230);
            btnRSocios.Size = new System.Drawing.Size(150, 40);
            btnRSocios.Font = new System.Drawing.Font("Arial", 10);
            btnRSocios.Visible = userRole.ToUpper() == "GERENCIA" || userRole.ToUpper() == "ADMINISTRACION";
            btnRSocios.Click += BtnRSocios_Click;

            btnCerrarSesion.Text = "🚪 Cerrar Sesión";
            btnCerrarSesion.Location = new System.Drawing.Point(450, 320);
            btnCerrarSesion.Size = new System.Drawing.Size(120, 30);
            btnCerrarSesion.BackColor = System.Drawing.Color.LightCoral;
            btnCerrarSesion.Click += BtnCerrarSesion_Click;

            // Add controls to form
            this.Controls.Add(btnFinanzas);
            this.Controls.Add(btnInventario);
            this.Controls.Add(btnProduccion);
            this.Controls.Add(btnReporte);
            this.Controls.Add(btnRSocios);
            this.Controls.Add(btnCerrarSesion);
        }

        private void BtnFinanzas_Click(object sender, EventArgs e)
        {
            FinanzasForm finanzasForm = new FinanzasForm(userRole, userId);
            finanzasForm.ShowDialog();
        }

        private void BtnInventario_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo de Inventario - En desarrollo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnProduccion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo de Producción - En desarrollo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            ReporteForm reporteForm = new ReporteForm();
            reporteForm.ShowDialog();
        }

        private void BtnRSocios_Click(object sender, EventArgs e)
        {
            RSocios rSociosForm = new RSocios();
            rSociosForm.ShowDialog();
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Cerrar Sesión", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }
    }
}