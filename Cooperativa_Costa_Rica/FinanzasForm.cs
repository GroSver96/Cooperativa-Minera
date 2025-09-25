using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace SistemaCooperativa
{
    public partial class FinanzasForm : Form
    {
        private string connectionString = "Server=.;Database=CoopCostaRica;Integrated Security=true;TrustServerCertificate=true;";
        private DataGridView dgvFinanzas;
        private PrintDocument printDocument;
        private string reportContent = "";
        private string userRole;
        private int userId;
        private Button btnHome;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnImprimir;

        public FinanzasForm(string role, int id)
        {
            userRole = role;
            userId = id;
            InitializeComponent();
            LoadFinanzasData();
            ApplyRoleBasedVisibility();
        }

        private void InitializeComponent()
        {
            // Configuración básica del formulario
            this.Text = "Módulo de Finanzas";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Botón Home
            btnHome = new Button();
            btnHome.Text = "🏠 Volver al Menú";
            btnHome.Size = new Size(120, 30);
            btnHome.Location = new Point(10, 10);
            btnHome.Click += BtnHome_Click;
            this.Controls.Add(btnHome);

            // Panel de botones
            Panel buttonPanel = new Panel();
            buttonPanel.Size = new Size(760, 50);
            buttonPanel.Location = new Point(10, 50);
            this.Controls.Add(buttonPanel);

            // Botones de operaciones
            btnAgregar = new Button();
            btnAgregar.Text = "➕ Agregar";
            btnAgregar.Size = new Size(80, 30);
            btnAgregar.Location = new Point(10, 10);
            btnAgregar.Click += BtnAgregar_Click;
            buttonPanel.Controls.Add(btnAgregar);

            btnEditar = new Button();
            btnEditar.Text = "✏️ Editar";
            btnEditar.Size = new Size(80, 30);
            btnEditar.Location = new Point(100, 10);
            btnEditar.Click += BtnEditar_Click;
            buttonPanel.Controls.Add(btnEditar);

            btnEliminar = new Button();
            btnEliminar.Text = "🗑️ Eliminar";
            btnEliminar.Size = new Size(80, 30);
            btnEliminar.Location = new Point(190, 10);
            btnEliminar.Click += BtnEliminar_Click;
            buttonPanel.Controls.Add(btnEliminar);

            btnImprimir = new Button();
            btnImprimir.Text = "🖨️ Imprimir";
            btnImprimir.Size = new Size(80, 30);
            btnImprimir.Location = new Point(280, 10);
            btnImprimir.Click += BtnImprimir_Click;
            buttonPanel.Controls.Add(btnImprimir);

            // DataGridView
            dgvFinanzas = new DataGridView();
            dgvFinanzas.Size = new Size(760, 350);
            dgvFinanzas.Location = new Point(10, 110);
            dgvFinanzas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFinanzas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFinanzas.MultiSelect = false;
            dgvFinanzas.AllowUserToAddRows = false;
            dgvFinanzas.ReadOnly = true;
            this.Controls.Add(dgvFinanzas);

            // Inicializar documento de impresión
            InitializePrintDocument();
        }

        private void ApplyRoleBasedVisibility()
        {
            bool hasAccess = userRole.ToUpper() == "FINANZAS" || userRole.ToUpper() == "GERENCIA";

            btnAgregar.Visible = hasAccess;
            btnEditar.Visible = hasAccess;
            btnEliminar.Visible = hasAccess;

            if (!hasAccess)
            {
                Label lblInfo = new Label();
                lblInfo.Text = "🔒 Solo visualización - Sin permisos de edición";
                lblInfo.ForeColor = Color.Red;
                lblInfo.Location = new Point(380, 15);
                lblInfo.Size = new Size(300, 20);
                lblInfo.Font = new Font(lblInfo.Font, FontStyle.Italic);
                
                // Buscar el panel de botones
                foreach (Control control in this.Controls)
                {
                    if (control is Panel panel)
                    {
                        panel.Controls.Add(lblInfo);
                        break;
                    }
                }
            }

            this.Text = $"Módulo de Finanzas - Usuario: {userRole}";
        }

        private void InitializePrintDocument()
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        private void LoadFinanzasData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Consulta con información del usuario
                    string query = @"SELECT 
                                f.IdFinanza, 
                                f.Aportes, 
                                f.Estado_Financiero,
                                u.Usuario as NombreUsuario
                            FROM Finanza f 
                            LEFT JOIN Usuario u ON f.IdUsuario = u.IdUsuario 
                            ORDER BY f.IdFinanza DESC";
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvFinanzas.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos financieros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            // ✅ VERIFICAR que el userId existe antes de abrir el formulario
            if (!VerificarUsuarioExiste(userId))
            {
                MessageBox.Show($"Error: El usuario con ID {userId} no existe en la base de datos.", 
                    "Error de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormAgregarFinanza form = new FormAgregarFinanza(userId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadFinanzasData();
                MessageBox.Show("Registro agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvFinanzas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                DataGridViewRow row = dgvFinanzas.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["IdFinanza"].Value);
                string aportes = row.Cells["Aportes"].Value?.ToString() ?? "";
                string estado = row.Cells["Estado_Financiero"].Value?.ToString() ?? "";

                FormAgregarFinanza form = new FormAgregarFinanza(id, aportes, estado, userId);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadFinanzasData();
                    MessageBox.Show("Registro actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvFinanzas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar este registro?", "Confirmar", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dgvFinanzas.SelectedRows[0].Cells["IdFinanza"].Value);
                    
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Finanza WHERE IdFinanza = @id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    
                    LoadFinanzasData();
                    MessageBox.Show("Registro eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("REPORTE DE FINANZAS");
                sb.AppendLine("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                sb.AppendLine("Usuario: " + userRole);
                sb.AppendLine("".PadRight(60, '='));
                sb.AppendLine();

                foreach (DataGridViewRow row in dgvFinanzas.Rows)
                {
                    if (row.Cells["IdFinanza"].Value != null && !row.IsNewRow)
                    {
                        sb.AppendLine($"ID: {row.Cells["IdFinanza"].Value}");
                        sb.AppendLine($"Aportes: {row.Cells["Aportes"].Value}");
                        sb.AppendLine($"Estado: {row.Cells["Estado_Financiero"].Value}");
                        sb.AppendLine($"Usuario: {row.Cells["NombreUsuario"].Value}");
                        sb.AppendLine("".PadRight(40, '-'));
                    }
                }

                reportContent = sb.ToString();
                ShowPrintDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al preparar impresión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowPrintDialog()
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;
                
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                Font font = new Font("Arial", 10);
                float yPosition = 50;
                float leftMargin = 50;

                if (string.IsNullOrEmpty(reportContent))
                {
                    e.Graphics.DrawString("No hay contenido para imprimir", font, Brushes.Black, leftMargin, yPosition);
                    return;
                }

                string[] lines = reportContent.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                
                foreach (string line in lines)
                {
                    if (yPosition + font.GetHeight() > e.PageBounds.Height - 50)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                    
                    e.Graphics.DrawString(line, font, Brushes.Black, leftMargin, yPosition);
                    yPosition += font.GetHeight() + 2;
                }
                
                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante la impresión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ MÉTODO NUEVO: Verificar que el usuario existe en la base de datos
        private bool VerificarUsuarioExiste(int usuarioId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Usuario WHERE IdUsuario = @userId", conn);
                    cmd.Parameters.AddWithValue("@userId", usuarioId);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class FormAgregarFinanza : Form
    {
        private string connectionString = "Server=.;Database=CoopCostaRica;Integrated Security=true;TrustServerCertificate=true;";
        private int idFinanza = 0;
        private int userId;
        private bool isEditing = false;
        private TextBox txtAportes;
        private TextBox txtEstado;

        public FormAgregarFinanza(int currentUserId)
        {
            userId = currentUserId;
            InitializeComponent();
        }

        public FormAgregarFinanza(int id, string aportes, string estado, int currentUserId) : this(currentUserId)
        {
            isEditing = true;
            idFinanza = id;
            this.Text = "Editar Finanza";
            txtAportes.Text = aportes;
            txtEstado.Text = estado;
        }

        private void InitializeComponent()
        {
            this.Text = "Agregar Finanza";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Controles
            Label lblAportes = new Label();
            lblAportes.Text = "Aportes (Número):";
            lblAportes.Location = new Point(20, 20);
            lblAportes.Size = new Size(120, 20);
            this.Controls.Add(lblAportes);

            txtAportes = new TextBox();
            txtAportes.Location = new Point(20, 45);
            txtAportes.Size = new Size(340, 25);
            txtAportes.Multiline = false;
            this.Controls.Add(txtAportes);

            Label lblEstado = new Label();
            lblEstado.Text = "Estado Financiero (Descripción):";
            lblEstado.Location = new Point(20, 80);
            lblEstado.Size = new Size(200, 20);
            this.Controls.Add(lblEstado);

            txtEstado = new TextBox();
            txtEstado.Location = new Point(20, 105);
            txtEstado.Size = new Size(340, 80);
            txtEstado.Multiline = true;
            this.Controls.Add(txtEstado);

            // Botones
            Button btnGuardar = new Button();
            btnGuardar.Text = "💾 Guardar";
            btnGuardar.Location = new Point(200, 200);
            btnGuardar.Size = new Size(75, 30);
            btnGuardar.Click += BtnGuardar_Click;
            this.Controls.Add(btnGuardar);

            Button btnCancelar = new Button();
            btnCancelar.Text = "❌ Cancelar";
            btnCancelar.Location = new Point(285, 200);
            btnCancelar.Size = new Size(75, 30);
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            this.Controls.Add(btnCancelar);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAportes.Text) || string.IsNullOrWhiteSpace(txtEstado.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtAportes.Text, out decimal aportesValue))
            {
                MessageBox.Show("El campo Aportes debe ser un valor numérico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    if (isEditing)
                    {
                        // EDITAR registro existente
                        SqlCommand cmd = new SqlCommand(
                            "UPDATE Finanza SET Aportes = @aportes, Estado_Financiero = @estado WHERE IdFinanza = @id", 
                            conn);
                        cmd.Parameters.AddWithValue("@id", idFinanza);
                        cmd.Parameters.AddWithValue("@aportes", aportesValue);
                        cmd.Parameters.AddWithValue("@estado", txtEstado.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // ✅ VERIFICAR nuevamente que el usuario existe antes de insertar
                        SqlCommand verificarCmd = new SqlCommand("SELECT COUNT(*) FROM Usuario WHERE IdUsuario = @userId", conn);
                        verificarCmd.Parameters.AddWithValue("@userId", userId);
                        int usuarioExiste = Convert.ToInt32(verificarCmd.ExecuteScalar());

                        if (usuarioExiste == 0)
                        {
                            MessageBox.Show("Error: El usuario no existe en la base de datos.", 
                                "Error de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // AGREGAR NUEVO registro usando el userId del usuario logueado
                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Finanza (Aportes, Estado_Financiero, IdUsuario) VALUES (@aportes, @estado, @userId)", 
                            conn);
                        cmd.Parameters.AddWithValue("@aportes", aportesValue);
                        cmd.Parameters.AddWithValue("@estado", txtEstado.Text.Trim());
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.ExecuteNonQuery();
                    }
                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex) when (ex.Number == 547) // Error de clave foránea
            {
                MessageBox.Show("Error de integridad referencial: El usuario especificado no existe en la base de datos.", 
                    "Error de Clave Foránea", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}