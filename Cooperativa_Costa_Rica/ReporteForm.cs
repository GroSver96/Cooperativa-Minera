using System;
using System.Windows.Forms;

public class ReporteForm : Form
{
    private ComboBox cboTipoReporte;
    private Button btnGenerar;
    private DateTimePicker fechaInicio;
    private DateTimePicker fechaFin;

    public ReporteForm()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        this.Text = "Generador de Reportes";
        this.Size = new System.Drawing.Size(400, 300);

        // ComboBox para tipo de reporte
        cboTipoReporte = new ComboBox();
        cboTipoReporte.Items.AddRange(new string[] { "Finanzas", "Inventario", "Producción" });
        cboTipoReporte.Location = new System.Drawing.Point(20, 20);
        cboTipoReporte.Size = new System.Drawing.Size(200, 25);

        // Selectores de fecha
        fechaInicio = new DateTimePicker();
        fechaInicio.Location = new System.Drawing.Point(20, 60);
        
        fechaFin = new DateTimePicker();
        fechaFin.Location = new System.Drawing.Point(20, 100);

        // Botón generar
        btnGenerar = new Button();
        btnGenerar.Text = "Generar Reporte";
        btnGenerar.Location = new System.Drawing.Point(20, 140);
        btnGenerar.Click += new EventHandler(BtnGenerar_Click);

        // Agregar controles al formulario
        this.Controls.AddRange(new Control[] { 
            cboTipoReporte, 
            fechaInicio, 
            fechaFin, 
            btnGenerar 
        });
    }

    private void BtnGenerar_Click(object sender, EventArgs e)
    {
        switch (cboTipoReporte.SelectedItem?.ToString())
        {
            case "Finanzas":
                GenerarReporteFinanzas();
                break;
            case "Inventario":
                GenerarReporteInventario();
                break;
            case "Producción":
                GenerarReporteProduccion();
                break;
            default:
                MessageBox.Show("Por favor seleccione un tipo de reporte");
                break;
        }
    }

    private void GenerarReporteFinanzas()
    {
        // Implementar lógica para reporte de finanzas
        MessageBox.Show("Generando reporte de finanzas...");
    }

    private void GenerarReporteInventario()
    {
        // Implementar lógica para reporte de inventario
        MessageBox.Show("Generando reporte de inventario...");
    }

    private void GenerarReporteProduccion()
    {
        // Implementar lógica para reporte de producción
        MessageBox.Show("Generando reporte de producción...");
    }
}