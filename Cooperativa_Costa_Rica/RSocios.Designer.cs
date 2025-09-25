namespace SistemaCooperativa
{
    partial class RSocios
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNombreApellido = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.DGRSocios = new System.Windows.Forms.DataGridView();
            this.BottunGuardar = new System.Windows.Forms.Button();
            this.LabelIDUSUARIO = new System.Windows.Forms.Label();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGRSocios)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registro de socios";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(148, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(432, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "COOPERATIVA MINERA COSTA RICA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre y Apellido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Telefono";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(153, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fecha de registro";
            // 
            // txtNombreApellido
            // 
            this.txtNombreApellido.Location = new System.Drawing.Point(309, 162);
            this.txtNombreApellido.Name = "txtNombreApellido";
            this.txtNombreApellido.Size = new System.Drawing.Size(100, 20);
            this.txtNombreApellido.TabIndex = 6;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(309, 205);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 7;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(309, 240);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 8;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.Location = new System.Drawing.Point(309, 280);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(100, 20);
            this.txtFechaRegistro.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(309, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DGRSocios
            // 
            this.DGRSocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGRSocios.Location = new System.Drawing.Point(464, 108);
            this.DGRSocios.Name = "DGRSocios";
            this.DGRSocios.Size = new System.Drawing.Size(312, 228);
            this.DGRSocios.TabIndex = 12;
            this.DGRSocios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGRSocios_CellContentClick);
            // 
            // BottunGuardar
            // 
            this.BottunGuardar.Location = new System.Drawing.Point(191, 353);
            this.BottunGuardar.Name = "BottunGuardar";
            this.BottunGuardar.Size = new System.Drawing.Size(75, 23);
            this.BottunGuardar.TabIndex = 13;
            this.BottunGuardar.Text = "Guardar";
            this.BottunGuardar.UseVisualStyleBackColor = true;
            this.BottunGuardar.Click += new System.EventHandler(this.BottunGuardar_Click);
            // 
            // LabelIDUSUARIO
            // 
            this.LabelIDUSUARIO.AutoSize = true;
            this.LabelIDUSUARIO.Location = new System.Drawing.Point(153, 131);
            this.LabelIDUSUARIO.Name = "LabelIDUSUARIO";
            this.LabelIDUSUARIO.Size = new System.Drawing.Size(52, 13);
            this.LabelIDUSUARIO.TabIndex = 14;
            this.LabelIDUSUARIO.Text = "IdUsuario";
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Location = new System.Drawing.Point(309, 124);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(96, 20);
            this.txtIdUsuario.TabIndex = 15;
            // 
            // RSocios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtIdUsuario);
            this.Controls.Add(this.LabelIDUSUARIO);
            this.Controls.Add(this.BottunGuardar);
            this.Controls.Add(this.DGRSocios);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtFechaRegistro);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtNombreApellido);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RSocios";
            this.Text = "RSocios";
            this.Load += new System.EventHandler(this.RSocios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGRSocios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNombreApellido;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView DGRSocios;
        private System.Windows.Forms.Button BottunGuardar;
        private System.Windows.Forms.Label LabelIDUSUARIO;
        private System.Windows.Forms.TextBox txtIdUsuario;
    }
}