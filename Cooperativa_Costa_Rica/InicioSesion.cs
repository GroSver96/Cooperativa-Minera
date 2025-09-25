using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaCooperativa
{
    public partial class InicioSesion : Form
    {
        private string connectionString = "Server=.;Database=CoopCostaRica;Integrated Security=true;TrustServerCertificate=true;";
        
        // Declaración de controles (deben coincidir con el Designer)
        private TextBox textBoxUsuario;
        private TextBox textBoxContrasena;
        private Button buttonIngresar;
        private Button buttonSalir;

        public InicioSesion()
        {
            InitializeComponent();
        }

        private void BotonIngresar_Click(object sender, EventArgs e)
        {
            ValidarLogin();
        }

        private void BotonSalir_Click(object sender, EventArgs e)
        {
            SalirAplicacion();
        }

        private void TextBoxContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ValidarLogin();
                e.Handled = true;
            }
        }

        private void ValidarLogin()
        {
            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(textBoxUsuario.Text) || string.IsNullOrWhiteSpace(textBoxContrasena.Text))
            {
                MessageBox.Show("Por favor ingrese tanto el usuario como la contraseña.", 
                    "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxUsuario.Focus();
                return;
            }

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    
                    string consulta = @"SELECT IdUsuario, Usuario, Contraseña, Rol 
                               FROM Usuario 
                               WHERE Usuario = @nombreUsuario AND Contraseña = @clave";
                    
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombreUsuario", textBoxUsuario.Text.Trim());
                        comando.Parameters.AddWithValue("@clave", textBoxContrasena.Text.Trim());
                        
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.HasRows && lector.Read())
                            {
                                // Obtener datos del usuario
                                int idUsuario = lector.GetInt32(0);
                                string nombre = lector.GetString(1);
                                string rol = lector.GetString(3);

                                // Mostrar mensaje de bienvenida
                                MessageBox.Show($"¡Bienvenido(a) {nombre}!\nRol: {rol}", 
                                    "Inicio de Sesión Exitoso", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Abrir formulario principal
                                HomeForm formularioPrincipal = new HomeForm(rol, idUsuario);
                                this.Hide();
                                formularioPrincipal.ShowDialog();
                                
                                this.Show();
                                LimpiarCampos();
                            }
                            else
                            {
                                MessageBox.Show("Usuario o contraseña incorrectos.\nPor favor verifique sus credenciales.", 
                                    "Error de Autenticación", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                LimpiarCampos();
                                textBoxUsuario.Focus();
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de conexión a la base de datos:\n{ex.Message}", 
                    "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado:\n{ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SalirAplicacion()
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea salir del sistema?", 
                "Confirmar Salida", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void LimpiarCampos()
        {
            textBoxUsuario.Text = "";
            textBoxContrasena.Text = "";
        }
    }
}