using System.Drawing;
using System.Windows.Forms;

namespace SistemaCooperativa
{
    public partial class InicioSesion : Form
    {
        private void InitializeComponent()
        {
            // Configuración básica del formulario
            this.Text = "Inicio de Sesión - Cooperativa Costa Rica";
            this.Size = new Size(450, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            // Título
            Label labelTitulo = new Label();
            labelTitulo.Text = "INICIO DE SESIÓN";
            labelTitulo.Font = new Font("Arial", 18, FontStyle.Bold);
            labelTitulo.ForeColor = Color.DarkBlue;
            labelTitulo.Location = new Point(100, 30);
            labelTitulo.Size = new Size(250, 35);
            labelTitulo.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(labelTitulo);

            // Etiqueta y campo de usuario
            Label labelUsuario = new Label();
            labelUsuario.Text = "Usuario:";
            labelUsuario.Font = new Font("Arial", 10, FontStyle.Regular);
            labelUsuario.Location = new Point(80, 100);
            labelUsuario.Size = new Size(80, 25);
            this.Controls.Add(labelUsuario);

            this.textBoxUsuario = new TextBox();
            this.textBoxUsuario.Location = new Point(170, 100);
            this.textBoxUsuario.Size = new Size(200, 25);
            this.textBoxUsuario.Font = new Font("Arial", 10, FontStyle.Regular);
            this.Controls.Add(this.textBoxUsuario);

            // Etiqueta y campo de contraseña
            Label labelContrasena = new Label();
            labelContrasena.Text = "Contraseña:";
            labelContrasena.Font = new Font("Arial", 10, FontStyle.Regular);
            labelContrasena.Location = new Point(80, 140);
            labelContrasena.Size = new Size(80, 25);
            this.Controls.Add(labelContrasena);

            this.textBoxContrasena = new TextBox();
            this.textBoxContrasena.Location = new Point(170, 140);
            this.textBoxContrasena.Size = new Size(200, 25);
            this.textBoxContrasena.Font = new Font("Arial", 10, FontStyle.Regular);
            this.textBoxContrasena.PasswordChar = '*';
            this.Controls.Add(this.textBoxContrasena);

            // Botón Ingresar
            this.buttonIngresar = new Button();
            this.buttonIngresar.Text = "🔑 Ingresar";
            this.buttonIngresar.Location = new Point(120, 200);
            this.buttonIngresar.Size = new Size(100, 35);
            this.buttonIngresar.Font = new Font("Arial", 10, FontStyle.Bold);
            this.buttonIngresar.BackColor = Color.LightGreen;
            this.buttonIngresar.Click += new EventHandler(this.BotonIngresar_Click);
            this.Controls.Add(this.buttonIngresar);

            // Botón Salir
            this.buttonSalir = new Button();
            this.buttonSalir.Text = "🚪 Salir";
            this.buttonSalir.Location = new Point(240, 200);
            this.buttonSalir.Size = new Size(100, 35);
            this.buttonSalir.Font = new Font("Arial", 10, FontStyle.Bold);
            this.buttonSalir.BackColor = Color.LightCoral;
            this.buttonSalir.Click += new EventHandler(this.BotonSalir_Click);
            this.Controls.Add(this.buttonSalir);

            // Evento para permitir Enter en los campos
            this.textBoxContrasena.KeyPress += new KeyPressEventHandler(this.TextBoxContrasena_KeyPress);
        }
    }
}