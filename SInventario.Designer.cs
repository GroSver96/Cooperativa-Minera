namespace SistemaCooperativa
{
    partial class SInventario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button1Finanza = new System.Windows.Forms.Button();
            this.button2Produccion = new System.Windows.Forms.Button();
            this.button3Inicio = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(598, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "INVENTARIO - COOPERATIVA MINERA COSTA RICA";
            // 
            // button1Finanza
            // 
            this.button1Finanza.Location = new System.Drawing.Point(129, 88);
            this.button1Finanza.Name = "button1Finanza";
            this.button1Finanza.Size = new System.Drawing.Size(75, 23);
            this.button1Finanza.TabIndex = 1;
            this.button1Finanza.Text = "Finanza";
            this.button1Finanza.UseVisualStyleBackColor = true;
            // 
            // button2Produccion
            // 
            this.button2Produccion.Location = new System.Drawing.Point(342, 88);
            this.button2Produccion.Name = "button2Produccion";
            this.button2Produccion.Size = new System.Drawing.Size(75, 23);
            this.button2Produccion.TabIndex = 2;
            this.button2Produccion.Text = "Produccion";
            this.button2Produccion.UseVisualStyleBackColor = true;
            this.button2Produccion.Click += new System.EventHandler(this.button2Produccion_Click);
            // 
            // button3Inicio
            // 
            this.button3Inicio.Location = new System.Drawing.Point(564, 88);
            this.button3Inicio.Name = "button3Inicio";
            this.button3Inicio.Size = new System.Drawing.Size(75, 23);
            this.button3Inicio.TabIndex = 3;
            this.button3Inicio.Text = "Salir";
            this.button3Inicio.UseVisualStyleBackColor = true;
            this.button3Inicio.Click += new System.EventHandler(this.button3Inicio_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(105, 142);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(546, 247);
            this.dataGridView1.TabIndex = 4;
            // 
            // SInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3Inicio);
            this.Controls.Add(this.button2Produccion);
            this.Controls.Add(this.button1Finanza);
            this.Controls.Add(this.label1);
            this.Name = "SInventario";
            this.Text = "SInventario";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1Finanza;
        private System.Windows.Forms.Button button2Produccion;
        private System.Windows.Forms.Button button3Inicio;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}