using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace SistemaCooperativa
{
    public class ReporteForm : Form
    {
        private ComboBox cboTipoReporte;
        private Button btnGenerar;
        private DateTimePicker fechaInicio;
        private DateTimePicker fechaFin;
        private string connectionString = "Server=.;Database=CoopCostaRica;Integrated Security=true;TrustServerCertificate=true;";
        private string userRole = ""; // Puedes pasar esto desde el constructor si lo necesitas

        public ReporteForm()
        {
            InitializeComponents();
        }

        public ReporteForm(string role) : this()
        {
            userRole = role;
        }

        private void InitializeComponents()
        {
            this.Text = "Generador de Reportes - Cooperativa Costa Rica";
            this.Size = new System.Drawing.Size(450, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Etiqueta y ComboBox para tipo de reporte
            Label lblTipoReporte = new Label();
            lblTipoReporte.Text = "Tipo de Reporte:";
            lblTipoReporte.Location = new System.Drawing.Point(20, 20);
            lblTipoReporte.Size = new System.Drawing.Size(120, 20);
            this.Controls.Add(lblTipoReporte);

            cboTipoReporte = new ComboBox();
            cboTipoReporte.Items.AddRange(new string[] { "Finanzas", "Inventario", "Producción" });
            cboTipoReporte.Location = new System.Drawing.Point(150, 20);
            cboTipoReporte.Size = new System.Drawing.Size(250, 25);
            cboTipoReporte.DropDownStyle = ComboBoxStyle.DropDownList;

            // Etiqueta y selector de fecha inicio
            Label lblFechaInicio = new Label();
            lblFechaInicio.Text = "Fecha Inicio:";
            lblFechaInicio.Location = new System.Drawing.Point(20, 60);
            lblFechaInicio.Size = new System.Drawing.Size(120, 20);
            this.Controls.Add(lblFechaInicio);

            fechaInicio = new DateTimePicker();
            fechaInicio.Location = new System.Drawing.Point(150, 60);
            fechaInicio.Size = new System.Drawing.Size(250, 25);
            fechaInicio.Value = DateTime.Now.AddMonths(-1); // Último mes por defecto

            // Etiqueta y selector de fecha fin
            Label lblFechaFin = new Label();
            lblFechaFin.Text = "Fecha Fin:";
            lblFechaFin.Location = new System.Drawing.Point(20, 100);
            lblFechaFin.Size = new System.Drawing.Size(120, 20);
            this.Controls.Add(lblFechaFin);

            fechaFin = new DateTimePicker();
            fechaFin.Location = new System.Drawing.Point(150, 100);
            fechaFin.Size = new System.Drawing.Size(250, 25);
            fechaFin.Value = DateTime.Now;

            // Botón generar
            btnGenerar = new Button();
            btnGenerar.Text = "📊 Generar Reporte";
            btnGenerar.Location = new System.Drawing.Point(150, 140);
            btnGenerar.Size = new System.Drawing.Size(150, 35);
            btnGenerar.BackColor = System.Drawing.Color.LightBlue;
            btnGenerar.Click += new EventHandler(BtnGenerar_Click);
            this.Controls.Add(btnGenerar);

            // Agregar controles al formulario
            this.Controls.AddRange(new Control[] { 
                cboTipoReporte
            });
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            if (cboTipoReporte.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione un tipo de reporte", "Advertencia", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (cboTipoReporte.SelectedItem.ToString())
            {
                case "Finanzas":
                    GenerarReporteFinanzasSimple();
                    break;
                case "Inventario":
                    GenerarReporteInventario();
                    break;
                case "Producción":
                    GenerarReporteProduccion();
                    break;
                default:
                    MessageBox.Show("Tipo de reporte no válido");
                    break;
            }
        }

        private void GenerarReporteFinanzasSimple()
        {
            try
            {
                // Crear contenido HTML del reporte
                string htmlContent = GenerarHTMLReporte();
                
                string tempPath = Path.GetTempPath();
                string fileName = $"Reporte_Finanzas_{DateTime.Now:yyyyMMdd_HHmmss}.html";
                string fullPath = Path.Combine(tempPath, fileName);
                
                // Guardar como HTML
                File.WriteAllText(fullPath, htmlContent);
                
                // Abrir en el navegador predeterminado (que puede imprimir a PDF)
                Process.Start(new ProcessStartInfo
                {
                    FileName = fullPath,
                    UseShellExecute = true
                });
                
                MessageBox.Show("Reporte generado y abierto en el navegador. Use Ctrl+P para imprimir como PDF.", 
                    "Reporte Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerarHTMLReporte()
        {
            var datos = ObtenerDatosParaReporte();
            decimal totalAportes = CalcularTotalAportes(datos);
            
            string html = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <title>Reporte de Finanzas - Cooperativa Costa Rica</title>
                    <style>
                        body {{ font-family: Arial, sans-serif; margin: 20px; }}
                        h1 {{ color: #2c3e50; text-align: center; }}
                        table {{ width: 100%; border-collapse: collapse; margin: 20px 0; }}
                        th, td {{ border: 1px solid #ddd; padding: 8px; text-align: left; }}
                        th {{ background-color: #f2f2f2; }}
                        .total {{ font-weight: bold; font-size: 1.2em; color: #27ae60; }}
                        .header-info {{ margin-bottom: 20px; background-color: #f8f9fa; padding: 15px; border-radius: 5px; }}
                        .fecha-rango {{ color: #666; }}
                    </style>
                </head>
                <body>
                    <h1>REPORTE DE FINANZAS</h1>
                    <div class='header-info'>
                        <p><strong>Cooperativa Costa Rica</strong></p>
                        <p>Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}</p>
                        <p class='fecha-rango'>Período: {fechaInicio.Value:dd/MM/yyyy} - {fechaFin.Value:dd/MM/yyyy}</p>
                        <p>Usuario: {userRole}</p>
                    </div>
                    
                    <table>
                        <thead>
                            <tr>
                                <th>ID Finanza</th>
                                <th>Aportes</th>
                                <th>Estado Financiero</th>
                                <th>Usuario</th>
                            </tr>
                        </thead>
                        <tbody>";

            if (datos.Rows.Count > 0)
            {
                foreach (DataRow row in datos.Rows)
                {
                    decimal aporte = Convert.ToDecimal(row["Aportes"]);
                    html += $@"
                            <tr>
                                <td>{row["IdFinanza"]}</td>
                                <td>₡{aporte:#,##0.00}</td>
                                <td>{row["Estado_Financiero"]}</td>
                                <td>{row["NombreUsuario"]?.ToString() ?? "N/A"}</td>
                            </tr>";
                }
            }
            else
            {
                html += $@"
                            <tr>
                                <td colspan='4' style='text-align: center;'>No hay datos financieros para el período seleccionado</td>
                            </tr>";
            }

            html += $@"
                        </tbody>
                    </table>
                    
                    <div class='total'>
                        TOTAL DE APORTES: ₡{totalAportes:#,##0.00}
                    </div>
                    
                    <p style='margin-top: 30px; text-align: center; font-style: italic; color: #666;'>
                        Generado automáticamente por el Sistema Cooperativa Costa Rica
                    </p>
                </body>
                </html>";

            return html;
        }

        private DataTable ObtenerDatosParaReporte()
        {
            DataTable dt = new DataTable();
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT 
                                f.IdFinanza, 
                                f.Aportes, 
                                f.Estado_Financiero,
                                u.Usuario as NombreUsuario
                            FROM Finanza f 
                            LEFT JOIN Usuario u ON f.IdUsuario = u.IdUsuario 
                            ORDER BY f.IdFinanza DESC";
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener datos para el reporte: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return dt;
        }

        private decimal CalcularTotalAportes(DataTable datos)
        {
            decimal total = 0;
            foreach (DataRow row in datos.Rows)
            {
                if (decimal.TryParse(row["Aportes"]?.ToString(), out decimal aporte))
                {
                    total += aporte;
                }
            }
            return total;
        }

        private void GenerarReporteInventario()
        {
            // Implementar lógica para reporte de inventario
            MessageBox.Show("Módulo de reporte de inventario - En desarrollo", "Información", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GenerarReporteProduccion()
        {
            // Implementar lógica para reporte de producción
            MessageBox.Show("Módulo de reporte de producción - En desarrollo", "Información", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}